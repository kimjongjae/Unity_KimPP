using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class GameHandle : Singleton<GameHandle>
{
    List<Unit> _globalUnits = new List<Unit>();
    public List<Unit> GlobalUnits => _globalUnits;

    private void OnEnable()
    {
        GameEventObserver.Subscribe(GameEventType.GameStart, CharacterSpawn);
        GameEventObserver.Subscribe(GameEventType.UnitDie, EnemySpawn);
    }

    private void OnDisable()
    {
        GameEventObserver.UnSubscribe(GameEventType.GameStart, CharacterSpawn);
        GameEventObserver.UnSubscribe(GameEventType.UnitDie, EnemySpawn);
    }

    void CharacterSpawn(object obj)
    {
        GameObject charGo = null;
        ResourceManager.Instance.LoadResourceFromChche_Go(ResourcePath.char_BluePath, out charGo);

        if ((ReferenceEquals(charGo, null)))
        {
#if UNITY_EDITOR
            Debug.Log("캐릭터가 없습니다.");
#endif
            return;
        }
        else
        {
            var spawnGo = Instantiate(charGo);
            PoolingManager.Instance.AddPoolingObj(PoolingType.Blue_Character, spawnGo);
            var charUnit = spawnGo.GetComponent<Unit>();
            charUnit.poolingType = PoolingType.Blue_Character;
            charUnit.transform.position = GameManager.Instance.character_InitPosTr.position;
        }

        GameObject EnemyGo = null;
        ResourceManager.Instance.LoadResourceFromChche_Go(ResourcePath.enemy_GhostPath, out EnemyGo);

        if ((ReferenceEquals(EnemyGo, null)))
        {
#if UNITY_EDITOR
            Debug.Log("캐릭터가 없습니다.");
#endif
            return;
        }
        else
        {
            var spawnGo = Instantiate(EnemyGo);
            PoolingManager.Instance.AddPoolingObj(PoolingType.Ghost_Enemy, spawnGo);
            var enemyUnit = spawnGo.GetComponent<Unit>();
            enemyUnit.poolingType = PoolingType.Ghost_Enemy;
            enemyUnit.transform.position = GameManager.Instance.enemy_InitPosTr.position;
        }
    }

    void EnemySpawn(object obj)
    {
        var enemyObj = PoolingManager.Instance.OpenPoolingObj(PoolingType.Ghost_Enemy);

        if(enemyObj == null)
        {
            GameObject EnemyGo = null;
            ResourceManager.Instance.LoadResourceFromChche_Go(ResourcePath.enemy_GhostPath, out EnemyGo);

            if ((ReferenceEquals(EnemyGo, null)))
            {
#if UNITY_EDITOR
                Debug.Log("캐릭터가 없습니다.");
#endif
                return;
            }
            else
            {
                var spawnGo = Instantiate(EnemyGo);
                PoolingManager.Instance.AddPoolingObj(PoolingType.Ghost_Enemy, spawnGo);
                var enemyUnit = spawnGo.GetComponent<Unit>();
                enemyUnit.poolingType = PoolingType.Ghost_Enemy;
                enemyUnit.transform.position = GameManager.Instance.enemy_InitPosTr.position;
            }
        }
        else
            enemyObj.transform.position = GameManager.Instance.enemy_InitPosTr.position;
    }

    public void AddTargetUnit(Unit unit)
    {
        _globalUnits.Add(unit);
    }

    public void CloseTargetUnit(Unit unit)
    {
        _globalUnits.Remove(unit);
    }
}
