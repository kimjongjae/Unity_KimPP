using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class PoolingManager : Singleton<PoolingManager>
{
    private Dictionary<PoolingType, GameObject> poolingDic = new Dictionary<PoolingType, GameObject>();
    public Dictionary<PoolingType, GameObject> PoolingDic => poolingDic;

    public void AddPoolingObj(PoolingType pType,GameObject pObj)
    {
        if(poolingDic.TryGetValue(pType, out var checkObj))
            return;
        else
        {
            poolingDic.Add(pType, pObj);
        }
    }

    public GameObject OpenPoolingObj(PoolingType pType, GameObject pObj)
    {
        if (poolingDic.TryGetValue(pType, out var checkObj))
            return null;
        else
        {
            poolingDic[pType].SetActive(true);
            return poolingDic[pType];
        }
    }

    public void ClosePoolingObj(PoolingType pType, GameObject pObj)
    {
        if (poolingDic.TryGetValue(pType, out var checkObj))
            return;
        else
        {
            poolingDic[pType].SetActive(false);
            poolingDic[pType].transform.position = Vector3.one;
        }
    }
}
