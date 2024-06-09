using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Common
{
    //풀링 타입
    public enum PoolingType
    {
        //블루 캐릭터 타입
        Blue_Character,
        
        //몬스터 고스트 타입
        Ghost_Enemy,
    }

    //캐릭터 무기 타입 
    public enum CharacterWeaponType
    {
        Sword,
        Gun,
        Sickle,
        Boom,
        Hammer,
        Bow,
    }

    //스탯 타입
    public enum StatusType
    {
        /// <summary>
        /// 기본 공격
        /// </summary>
        BaseATK,
        /// <summary>
        /// 기본 마나
        /// </summary>
        BaseMP,
        /// <summary>
        /// 기본 공격력
        /// </summary>
        Base_ATKPower,
    }

    //유닛 액션 타입
    public enum ActionType
    {
        Idle,
        Attack,
        Hit,
        Run,
        Walk,
        Die,
        Skill,
        Sword,
    }

    //유닛 타입
    public enum UnitType
    {
        Player,
        Enemy,
        Boss,
    }

    //리소스 경로
    public class ResourcePath
    {
        public const string char_BluePath = "Character/Blue_Character";

        public const string enemy_GhostPath = "Enemy/Prefab/Enemy_Ghost";
    }

    public class Common
    {
       
    }
}
