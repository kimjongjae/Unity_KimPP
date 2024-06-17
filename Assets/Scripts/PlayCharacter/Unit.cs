using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System.Linq;
using System.Diagnostics.Tracing;

public abstract partial class Unit : MonoBehaviour, CharacterHandle 
{
    public virtual void Init() 
    {
        isDie = false;
    }
}

//행동 관련 및 변수
public abstract partial class Unit
{
    Coroutine unitThread = null;

    //유닛 현재 활동 타입
    protected ActionType unitActionType = ActionType.Idle;
    //유닛 타입 ex)캐릭터, 적, 보스
    public UnitType unitType = default;

    //죽었는지 체크
    protected bool isDie = false;
    //어택 딜레이 주기위함
    protected bool isAttacking = false;

    public Animator mainAnim = null;
    public SpriteRenderer mainSpriteRender = null;
    public Sprite normalSprite = null;

    //유닛 스탯
    public Status statusData = null;

    //유닛 버프
    public Status_Buff status_Buff { get; }

    protected float YPos => transform.position.y;
    protected float ZPos => transform.position.z;

    //유닛 풀링 타입
    public PoolingType poolingType = default;

    //현재 피
    protected float NowHP { get; set; }

    //피계산 위함
    public float RealHP
    {
        get
        {
            return NowHP;
        }

        set
        {
            NowHP = value;

            if (NowHP == 0)
            {
                isDie = true;
                DieAnim();
                ChangeActionType(ActionType.Die);
                return;
            }
        }
    }

    private void OnEnable()
    {
        Init();
        GameEvent_Observer();
        unitThread = StartCoroutine(UnitThread());
    }

    private void OnDisable()
    {
        GameEvent_UnObserver();
        StopCoroutine(unitThread);
        unitThread = null;
    }

    public virtual void GameEvent_Observer()
    {
    }

    public virtual void GameEvent_UnObserver()
    {

    }

    IEnumerator UnitThread()
    {
        //최적화 변수 선언
        var waitUntil = new WaitUntil(() => isDie == false);
        while (true)
        {
            yield return waitUntil;
            yield return null;
            UnitAction();
        }
    }

    //유닛 액션 스레드용 함수
    public virtual void UnitAction()
    {
        Move();
        switch (unitActionType)
        {
            case ActionType.Idle:
                {
                    IdleAnim();
                }
                break;
            case ActionType.Attack:
                {
                }
                break;
            case ActionType.Hit:
                {
                    HitAnim();
                }
                break;
            case ActionType.Run:
                {
                    RunAnim();
                }
                break;
            case ActionType.Walk:
                {
                    WalkAnim();
                }
                break;
            case ActionType.Die:
                {
                    DieAnim();
                }
                break;
            case ActionType.Skill:
                {
                    SkillAnim();
                }
                break;
        }
    }

    //현재 유닛 행동 타입 변경
    public void ChangeActionType(ActionType actionType)
    {
        if (unitActionType != actionType)
            unitActionType = actionType;
    }

    //현재 유닛 타입 Set
    public void SetUnitType(UnitType unitType)
    {
        this.unitType = unitType;
        GameHandle.Instance.AddTargetUnit(this);
    }

    //유닛 행동 관련
    public virtual void Move()
    {
        if (!isDie)
        {
            if (targetUnit == null)
            {
                ChangeActionType(ActionType.Idle);
                GetTarget(this, unitType);
            }
            else
            {
                if (targetUnit.isDie)
                {
                    targetUnit = null;
                }
                else
                {
                    var TargetPos = new Vector3(targetUnit.transform.position.x, YPos, ZPos);
                    var Dis = Vector3.Distance(transform.position, TargetPos);

                    if (Dis > statusData.DISTANCE)
                    {
                        ChangeActionType(ActionType.Run);
                        transform.position = Vector3.MoveTowards(transform.position, TargetPos, Time.deltaTime * statusData.MOVE_SPEED);
                    }
                    else
                    {
                        if (!isAttacking)
                        {
                            ChangeActionType(ActionType.Attack);
                            AttackAnim();
                            isAttacking = true;
                        }
                    }
                }
            }
        }
    }
}

//애니메이션 관련 컨트롤
public abstract partial class Unit
{
    public abstract void IdleAnim();
    public abstract void AttackAnim();
    public abstract void HitAnim();
    public abstract void RunAnim();
    public abstract void WalkAnim();
    public abstract void DieAnim();
    public abstract void SkillAnim();
    public abstract void AnimEnd_Override();
    public abstract void AnimStart_Override();
    public abstract void AnimDie_Override();
    void AnimEnd()
    {
        switch (unitActionType)
        {
            case ActionType.Idle:
                {
                }
                break;
            case ActionType.Attack:
                {
                    isAttacking = false;
                }
                break;
            case ActionType.Hit:
                {
                }
                break;
            case ActionType.Run:
                {
                }
                break;
            case ActionType.Walk:
                {
                }
                break;
            case ActionType.Die:
                {
                }
                break;
            case ActionType.Skill:
                {
                }
                break;
        }

        AnimEnd_Override();
    }

    void AnimStart()
    {
        switch (unitActionType)
        {
            case ActionType.Idle:
                {
                }
                break;
            case ActionType.Attack:
                {
                }
                break;
            case ActionType.Hit:
                {
                }
                break;
            case ActionType.Run:
                {
                }
                break;
            case ActionType.Walk:
                {
                }
                break;
            case ActionType.Die:
                {
                }
                break;
            case ActionType.Skill:
                {
                }
                break;
        }

        AnimStart_Override();
    }

    void AnimDie()
    {
        PoolingManager.Instance.ClosePoolingObj(poolingType, gameObject);
        GameHandle.Instance.CloseTargetUnit(this);
        GameEventObserver.Publish(GameEventType.UnitDie, null);
        AnimDie_Override();
    }
}

//유닛 공격 및 타겟 설정
public partial class Unit
{
    protected Unit targetUnit;

    public void GetTarget(Unit thisUnit, UnitType unitType)
    {
        Unit unit = null;

        var targetUnits = GameHandle.Instance.GlobalUnits.FindAll((a) => 
        {
            switch (unitType)
            {
                case UnitType.Player:
                    {
                        if (a.unitType == UnitType.Enemy || a.unitType == UnitType.Boss)
                        {
                            unit = a;
                            return true;
                        }
                    }
                    break;
                case UnitType.Enemy:
                case UnitType.Boss:
                    {
                        if (a.unitType == UnitType.Player)
                        {
                            unit = a;
                            return true;
                        }
                    }
                    break;
            }

            return false;
        });

        targetUnit = unit;
    }

    //유닛 데미지 주기위함
    public void Damage(Unit from, Unit to)
    {
        to.RealHP -= from.statusData.ATTACK_POWER;
    }
}
