using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System;

public partial class Player : Unit
{
    Status playerStatus = null;
    public UnitAnimtor[] unitAnimtors = null;

    public override void Init()
    {
        base.Init();
        playerStatus = new PlayerStatus();
        playerStatus.FinalStatus();
        Distance = playerStatus.DISTANCE;
        MoveSpeed = playerStatus.MOVE_SPEED;
        SetUnitType(UnitType.Player);
    }
}

//캐릭터 액션 관리
public partial class Player
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
        mainAnim.SetTrigger("Idle");
    }

    public override void RunAnim()
    {
        mainAnim.SetTrigger("Run");
    }

    public override void WalkAnim()
    {
    }

    public override void SkillAnim()
    {
    }

    public override void UnitAction()
    {
        base.UnitAction();
    }
}

//유닛 이동관련 함수
public partial class Player
{
   
}

[Serializable]
public class UnitAnimtor
{
    public CharacterWeaponType characterWeaponType = default;
    public Animator[] AnimArray = null;
    public GameObject WeaponGo = null;
}
