using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System.Linq;

public abstract partial class Unit : BaseUnit, CharacterHandle 
{
    public virtual void Init() 
    {
    }
}

//행동 관련 및 변수
public abstract partial class Unit
{
    protected ActionType unitActionType = ActionType.Idle;
    public UnitType unitType = default;

    protected bool isDie = false;
    protected bool isStop = false;
    protected bool isAttacking = false;

    public Animator mainAnim = null;
    public SpriteRenderer mainSpriteRender = null;
    public Sprite normalSprite = null;
    public Status statusData = null;

    public Status_Buff status_Buff { get; }

    protected float YPos => transform.position.y;
    protected float ZPos => transform.position.z;

    protected float NowHP { get; set; }

    public float RealHP
    {
        get
        {
            return NowHP;
        }

        set
        {
            if (NowHP == 0)
            {
                isDie = true;
                return;
            }

            NowHP -= value;
        }
    }

    private void OnEnable()
    {
        Init();
        StartCoroutine("UnitThread");
    }

    private void OnDisable()
    {
        StopCoroutine("UnitThread");
    }

    IEnumerator UnitThread()
    {
        while (true)
        {
            yield return null;
            UnitAction();
        }
    }

    //유닛 액션 스레드용 함수
    public virtual void UnitAction()
    {
        if (isDie)
            ChangeActionType(ActionType.Die);

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
                    isStop = true;
                    DieAnim();
                    PoolingManager.Instance.ClosePoolingObj(poolingType, gameObject);
                    GameHandle.Instance.CloseTargetUnit(this);
                }
                break;
            case ActionType.Skill:
                {
                    SkillAnim();
                }
                break;
        }
    }

    public void ChangeActionType(ActionType actionType)
    {
        if (unitActionType != actionType)
            unitActionType = actionType;
    }

    public void SetUnitType(UnitType unitType)
    {
        this.unitType = unitType;
        GameHandle.Instance.AddTargetUnit(this);
    }

    public virtual void Move()
    {
        if (!isStop)
        {
            if (targetUnit == null)
            {
                GetTarget(this, unitType);
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
                    if(!isAttacking)
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

    public void Damage(Unit from, Unit to)
    {
        to.RealHP -= from.statusData.ATTACK_POWER;
    }
}
