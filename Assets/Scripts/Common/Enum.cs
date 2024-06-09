using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Common
{
    //Ǯ�� Ÿ��
    public enum PoolingType
    {
        //��� ĳ���� Ÿ��
        Blue_Character,
        
        //���� ��Ʈ Ÿ��
        Ghost_Enemy,
    }

    //ĳ���� ���� Ÿ�� 
    public enum CharacterWeaponType
    {
        Sword,
        Gun,
        Sickle,
        Boom,
        Hammer,
        Bow,
    }

    //���� Ÿ��
    public enum StatusType
    {
        /// <summary>
        /// �⺻ ����
        /// </summary>
        BaseATK,
        /// <summary>
        /// �⺻ ����
        /// </summary>
        BaseMP,
        /// <summary>
        /// �⺻ ���ݷ�
        /// </summary>
        Base_ATKPower,
    }

    //���� �׼� Ÿ��
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

    //���� Ÿ��
    public enum UnitType
    {
        Player,
        Enemy,
        Boss,
    }

    //���ҽ� ���
    public class ResourcePath
    {
        public const string char_BluePath = "Character/Blue_Character";

        public const string enemy_GhostPath = "Enemy/Prefab/Enemy_Ghost";
    }

    public class Common
    {
       
    }
}
