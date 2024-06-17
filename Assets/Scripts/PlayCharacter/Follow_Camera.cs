using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Follow_Camera : MonoBehaviour
{
    bool isStop = false;
    Transform followTr = null;

    private void OnEnable()
    {
        isStop = true;
        GameEventObserver.Subscribe(GameEventType.CameraIsStopStart, IsStop);
    }

    private void OnDisable()
    {
        GameEventObserver.UnSubscribe(GameEventType.CameraIsStopStart, IsStop);
    }

    private void Update()
    {
        //���� ������ ���� �۾��� �� ĳ���ͺ��� �ٲ������.
        if (followTr == null)
        {
            if (PoolingManager.Instance.PoolingDic.TryGetValue(Common.PoolingType.Blue_Character, out var followChar))
            {
                followTr = followChar[0].GetComponent<Transform>();
                var followPos = new Vector3(followTr.transform.position.x - -3f, transform.position.y, transform.position.z);
                transform.position = followPos;
            }
        }
        else
        {
            if(!isStop)
            {
                var followPos = new Vector3(followTr.transform.position.x - -3f, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, followPos, Time.deltaTime * 3f);
            }
        }
    }

    void IsStop(object obj)
    {
        isStop = bool.Parse(obj.ToString());
    }
}
