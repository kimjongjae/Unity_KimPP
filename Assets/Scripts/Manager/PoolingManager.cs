using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class PoolingManager : Singleton<PoolingManager>
{
    private Dictionary<PoolingType, List<GameObject>> poolingDic = new Dictionary<PoolingType, List<GameObject>>();
    public Dictionary<PoolingType, List<GameObject>> PoolingDic => poolingDic;

    //Ǯ�� ���
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

    //��ϵ� Ǯ�� Ȱ��ȭ
    public void OpenPoolingObj(PoolingType pType, GameObject pObj)
    {
        if (poolingDic.TryGetValue(pType, out var checkObj))
        {
            poolingDic[pType].Find((a) => a == pObj).SetActive(true);
            pObj.transform.parent = null;
        }
    }

    //��ϵ� Ǯ�� ��Ȱ��ȭ
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
