using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public partial class Enemy : Unit
{
    Status enemyStatus = null;

    public override void Init()
    {
        base.Init();
        enemyStatus = new EnemyStatus();
        enemyStatus.FinalStatus();
        Distance = enemyStatus.DISTANCE;
        MoveSpeed = enemyStatus.MOVE_SPEED;
        SetUnitType(UnitType.Enemy);
    }
}

//�� �׼� ����
public partial class Enemy
{
    public override void AttackAnim()
    {
    }

    public override void DieAnim()
    {
    }

    public override void HitAnim()
    {
    }

    public override void IdleAnim()
    {
    }

    public override void RunAnim()
    {
    }

    public override void SkillAnim()
    {
    }

    public override void WalkAnim()
    {
    }

    public override void UnitAction()
    {
        base.UnitAction();
    }
}

//�� �̵� ����
public partial class Enemy
{
   
}
