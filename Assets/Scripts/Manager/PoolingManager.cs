using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class PoolingManager : Singleton<PoolingManager>
{
    private Dictionary<PoolingType, List<GameObject>> poolingDic = new Dictionary<PoolingType, List<GameObject>>();
    public Dictionary<PoolingType, List<GameObject>> PoolingDic => poolingDic;

    //풀링 등록
    public void AddPoolingObj(PoolingType pType,GameObject pObj)
    {
        if(poolingDic.TryGetValue(pType, out var checkObj))
            return;
        else
        {
            poolingDic.Add(pType, new List<GameObject>() { pObj });
            pObj.transform.parent = transform;
        }
    }

    //등록된 풀링 활성화
    public GameObject OpenPoolingObj(PoolingType pType)
    {
        if (poolingDic.TryGetValue(pType, out var checkObj))
        {
            checkObj[0].SetActive(true);
            checkObj[0].transform.parent = null;
            return checkObj[0];
        }

        return null;
    }

    //등록된 풀링 비활성화
    public void ClosePoolingObj(PoolingType pType, GameObject pObj)
    {
        if (poolingDic.TryGetValue(pType, out var checkObj))
        {
            var findObj = poolingDic[pType].Find((a) => a ==pObj);
            findObj.SetActive(false);
            findObj.transform.position = Vector3.one;
            pObj.transform.parent = transform;
        }
    }
}
