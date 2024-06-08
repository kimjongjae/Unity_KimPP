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
    }
}

//利 咀记 包府
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

    public override void AnimEnd_Override()
    {
    }

    public override void AnimStart_Override()
    {
    }

}

//利 捞悼 包府
public partial class Enemy
{
   
}
