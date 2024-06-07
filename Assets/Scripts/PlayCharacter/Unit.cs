using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System.Linq;
using static UnityEditor.Progress;

public abstract partial class Unit : BaseUnit, CharacterHandle 
{
    public virtual void Init() { }
}

//행동 관련 및 변수
public abstract partial class Unit
{
    public enum ActionType
    {
        Idle,
        Attack,
        Hit,
        Run,
        Walk,
        Die,
        Skill,
    }

    protected ActionType unitActionType = ActionType.Idle;
    public UnitType unitType = default;

    protected bool isDie = false;
    protected bool isStop = false;

    protected float Distance = 0f;
    protected float MoveSpeed = 0f;

    public Animator mainAnim = null;
    public SpriteRenderer mainSpriteRender = null;
    public Sprite normalSprite = null;

    public Status_Buff status_Buff { get; }

    protected float YPos => transform.position.y;
    protected float ZPos => transform.position.z;

    private void OnEnable()
    {
        Init();
    }

    private void Update()
    {
        UnitAction();
    }

    //유닛 액션 스레드용 함수
    public virtual void UnitAction()
    {
        Move();
        switch (unitActionType)
        {
            case ActionType.Idle:
                IdleAnim();
                break;
            case ActionType.Attack:
                AttackAnim();
                break;
            case ActionType.Hit:
                HitAnim();
                break;
            case ActionType.Run:
                RunAnim();
                break;
            case ActionType.Walk:
                WalkAnim();
                break;
            case ActionType.Die:
                {
                    DieAnim();
                    PoolingManager.Instance.ClosePoolingObj(poolingType, gameObject);
                    GameHandle.Instance.CloseTargetUnit(this);
                }
                break;
            case ActionType.Skill:
                SkillAnim();
                break;
        }
    }
    public void ChangeActionType(ActionType actionType)
    {
        if(unitActionType != actionType)
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

                if (Dis > Distance)
                {
                    ChangeActionType(ActionType.Run);
                    transform.position = Vector3.MoveTowards(transform.position, TargetPos, Time.deltaTime * MoveSpeed);
                }
                else
                {
                    ChangeActionType(ActionType.Idle);
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
}
