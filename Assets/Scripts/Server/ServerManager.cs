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
        string url = "http://localhost:4000/api/data"; // Express.js ������ �ּҿ� ��Ʈ�� ���⿡ �Է��ϼ���

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
                // ���� �����͸� ���⿡�� ó���մϴ�
            }
        }
    }
}
