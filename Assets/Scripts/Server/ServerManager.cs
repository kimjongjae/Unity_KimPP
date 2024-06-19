using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class ServerManager : MonoBehaviour
{
    public void GetSeverData(int port)
    {
        StartCoroutine(GetDataFromServer(port));
    }

    public IEnumerator GetDataFromServer(int port)
    {
        string url = "http://localhost:4000/api/data"; // Express.js 서버의 주소와 포트를 여기에 입력하세요

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("HTTP Error: " + www.error);
            }
            else
            {
                var jsonData = JsonUtility.FromJson<StageDataObject>(www.downloadHandler.text);
                Debug.Log("Received: " + www.downloadHandler.text);
                // 받은 데이터를 여기에서 처리합니다
            }
        }
    }
}
