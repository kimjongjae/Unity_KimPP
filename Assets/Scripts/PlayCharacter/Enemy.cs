using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public partial class Enemy : Unit
{
    public override void Init()
    {
        base.Init();
        statusData = new EnemyStatus();
        statusData.FinalStatus();
        SetUnitType(UnitType.Enemy);
        NowHP = statusData.HP;
    }
}

//利 咀记 包府
public partial class Enemy
{
    public override void AttackAnim()
    {
        mainAnim.Play("Ghost_Attack");
    }

    public override void DieAnim()
    {
        mainAnim.Play("Ghost_Desappear");
    }

    public override void HitAnim()
    {
        //mainAnim.Play("Ghost_Hit");
    }

    public override void IdleAnim()
    {
        mainAnim.Play("Ghost_Idle");
    }

    public override void RunAnim()
    {
        mainAnim.Play("Ghost_Idle");
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

    public override void AnimEnd_Override()
    {
    }

    public override void AnimStart_Override()
    {
    }

    public override void AnimDie_Override()
    {
    }
}

//利 捞悼 包府
public partial class Enemy
{
   
}
