using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Status
{
    public static ulong _uuid = 0;

    //Dictionary<float, StatusType> GameStats = new Dictionary<float, StatusType>();

    public ulong UUID { get; protected set; }
    public float HP { get; protected set; }
    public float MP { get; protected set; }
    public float ATTACK_POWER { get; protected set; }
    public float MOVE_SPEED { get; protected set; }
    public float DISTANCE { get; protected set; }
    public float HEAL {  get; protected set; }
    public float CRITICAL_CHANCE { get; protected set; }
    public float CRITICAL_DAMAGE { get; protected set; }
}
public partial class Status
{
    public virtual void FinalStatus()
    {
        HP = Excel.TableData.Inst.normalStat.HP;
        MP = Excel.TableData.Inst.normalStat.MP;
        ATTACK_POWER = Excel.TableData.Inst.normalStat.ATTACK_POWER;
        MOVE_SPEED = Excel.TableData.Inst.normalStat.MOVE_SPEED;
        DISTANCE = Excel.TableData.Inst.normalStat.DISTANCE;
        HEAL = Excel.TableData.Inst.normalStat.HEAL;
        CRITICAL_CHANCE = Excel.TableData.Inst.normalStat.CRITICAL_CHANCE;
        CRITICAL_DAMAGE = Excel.TableData.Inst.normalStat.CRITICAL_DAMAGE;
    }
}

public class PlayerStatus : Status
{
    public override void FinalStatus()
    {
        _uuid = GameManager.Instance.SpawnUUID + 1;
        HP = Excel.TableData.Inst.normalStat.HP;
        MP = Excel.TableData.Inst.normalStat.MP;
        ATTACK_POWER = Excel.TableData.Inst.normalStat.ATTACK_POWER;
        MOVE_SPEED = Excel.TableData.Inst.normalStat.MOVE_SPEED;
        DISTANCE = Excel.TableData.Inst.normalStat.DISTANCE;
        HEAL = Excel.TableData.Inst.normalStat.HEAL;
        CRITICAL_CHANCE = Excel.TableData.Inst.normalStat.CRITICAL_CHANCE;
        CRITICAL_DAMAGE = Excel.TableData.Inst.normalStat.CRITICAL_DAMAGE;

        //ATTACK_POWER = FinalATK();
    }

    //float FinalATK()
    //{
    //    return 0;
    //}
}

public class EnemyStatus : Status
{
    public override void FinalStatus()
    {
        _uuid = GameManager.Instance.SpawnUUID + 1;
        HP = Excel.TableData.Inst.normalStat.HP;
        MP = Excel.TableData.Inst.normalStat.MP;
        ATTACK_POWER = Excel.TableData.Inst.normalStat.ATTACK_POWER;
        MOVE_SPEED = Excel.TableData.Inst.normalStat.MOVE_SPEED;
        DISTANCE = Excel.TableData.Inst.normalStat.DISTANCE;
        HEAL = Excel.TableData.Inst.normalStat.HEAL;
        CRITICAL_CHANCE = Excel.TableData.Inst.normalStat.CRITICAL_CHANCE;
        CRITICAL_DAMAGE = Excel.TableData.Inst.normalStat.CRITICAL_DAMAGE;
    }
}
