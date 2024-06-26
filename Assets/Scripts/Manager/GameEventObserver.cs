using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public enum GameEventType
{
   //초기 게임 실행
   GameStart,
   //배경, 카메라 이동 제어
   CameraIsStopStart,
   //유닛 죽음
   UnitDie,
   //캐릭터 스킬 사용 가능 시 리스트에 추가
   Character_SkillAdd,
}

public class GameEventObserver : MonoBehaviour
{
    private static readonly IDictionary<GameEventType, UnityEvent<object>>
        Events = new Dictionary<GameEventType, UnityEvent<object>>();


    //이벤트 등록
    public static void Subscribe(GameEventType eventType, UnityAction<object> listener)
    {
        UnityEvent<object> thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent<object>();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    //이벤트 해제
    public static void UnSubscribe(GameEventType eventType, UnityAction<object> listener)
    {
        UnityEvent<object> thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    //등록된 이벤트 실행
    public static void Publish(GameEventType eventType, object Data)
    {
        UnityEvent<object> thisEvent;
        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.Invoke(Data);
        }
    }
}
