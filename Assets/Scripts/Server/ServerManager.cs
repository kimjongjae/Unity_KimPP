using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class ServerManager
{
    public IEnumerator GetDataFromServer()
    {
        string url = "http://localhost:3000/api/data"; // Express.js ������ �ּҿ� ��Ʈ�� ���⿡ �Է��ϼ���

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("HTTP Error: " + www.error);
            }
            else
            {
                Debug.Log("Received: " + www.downloadHandler.text);
                // ���� �����͸� ���⿡�� ó���մϴ�
            }
        }
    }
}
