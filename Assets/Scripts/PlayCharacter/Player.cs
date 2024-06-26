using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System;

public partial class Player : Unit
{
    public UnitAnimtor[] unitAnimtors = null;
    bool _isAttacking = false;
    CharacterWeaponType weaponType = default;
    List<int> UseOnSkillList = new List<int>();

    public override void Init()
    {
        base.Init();
        statusData = new PlayerStatus();
        statusData.FinalStatus();
        SetUnitType(UnitType.Player);
        weaponType = CharacterWeaponType.Sword;
        NowHP = statusData.HP;
    }

    public override void GameEvent_Observer()
    {
        GameEventObserver.Subscribe(GameEventType.UnitDie, UnitDieEvent);
        GameEventObserver.Subscribe(GameEventType.Character_SkillAdd, CharacterSkillAdd);
    }

    public override void GameEvent_UnObserver()
    {
        GameEventObserver.UnSubscribe(GameEventType.UnitDie, UnitDieEvent);
        GameEventObserver.UnSubscribe(GameEventType.Character_SkillAdd, CharacterSkillAdd);
    }

    #region 이벤트 등록 함수
    void UnitDieEvent(object obj)
    {
        unitAnimtors[(int)weaponType].WeaponGo.SetActive(false);
    }

    void CharacterSkillAdd(object obj)
    {
        var skillIdx = int.Parse(obj.ToString());

        if (!UseOnSkillList.Contains(skillIdx))
            UseOnSkillList.Add(skillIdx);
    }
    #endregion
}

//캐릭터 액션 관리
public partial class Player
{
    public override void AttackAnim()
    {
        //bomb_hold_side
        //bomb_throw_side
        //sword_attack_side
        //scythe_attack_side
        //hammer_attack_side
        //vanish

        switch (weaponType)
        {
            case CharacterWeaponType.Sword:
                {
                    if (!_isAttacking)
                    {
                        mainAnim.Play("sword_attack_side");
                        _isAttacking = true;
                    }
                }
                break;
            case CharacterWeaponType.Bow:
                break;
            case CharacterWeaponType.Gun:
                break;
            case CharacterWeaponType.Sickle:
                break;
            case CharacterWeaponType.Boom:
                break;
            case CharacterWeaponType.Hammer:
                break;
        }
    }

    public override void DieAnim()
    {
        mainAnim.Play("hit_A_die");
    }

    public override void HitAnim()
    {
    }

    public override void IdleAnim()
    {
        mainAnim.Play("idle_side");
    }

    public override void RunAnim()
    {
        mainAnim.Play("run_side");
    }

    public override void WalkAnim()
    {
        mainAnim.Play("walk_side");
    }

    public override void SkillAnim()
    {
    }

    public override void UnitAction()
    {
        base.UnitAction();
    }

    public override void AnimEnd_Override()
    {
        _isAttacking = false;
        GameEventObserver.Publish(GameEventType.CameraIsStopStart, false);
        ProjectileObj.CreateProjectObj(true, this, targetUnit);
    }

    public override void AnimStart_Override()
    {
        unitAnimtors[(int)weaponType].WeaponGo.SetActive(true);
    }

    public override void AnimDie_Override()
    {
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
