using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    [Range(-1.0f, 1.0f)]
    private float moveSpeed = 1;

    bool isStop = false;

    private void Awake()
    {
        isStop = true;
    }

    private void OnEnable()
    {
        StartCoroutine("CameraMoveCor");
        GameEventObserver.Subscribe(GameEventType.CameraIsStopStart, IsStop);
    }

    private void OnDisable()
    {
        StopCoroutine("CameraMoveCor");
        GameEventObserver.UnSubscribe(GameEventType.CameraIsStopStart, IsStop);
    }

    IEnumerator CameraMoveCor()
    {
        while (true)
        {
            yield return new WaitUntil(() => isStop == false);
            yield return null;
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }

    void IsStop(object obj)
    {
        isStop = bool.Parse(obj.ToString());
    }
}
