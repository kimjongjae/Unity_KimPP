using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Follow_Camera : MonoBehaviour
{
    bool isStop = false;
    Transform followTr = null;

    private void Update()
    {
        //추후 데이터 관련 작업할 때 캐릭터별로 바꿔줘야함.
        if (followTr == null)
        {
            if (PoolingManager.Instance.PoolingDic.TryGetValue(Common.PoolingType.Blue_Character, out var followChar))
            {
                followTr = followChar[0].GetComponent<Transform>();
            }
        }
        else
        {
            var followPos = new Vector3(followTr.transform.position.x - -8f, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, followPos, Time.deltaTime * 3f);
        }
    }
}
