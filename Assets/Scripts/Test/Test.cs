using System.Collections;using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static UnityEngine.GraphicsBuffer;

public class Test : MonoBehaviour
{
    public Transform posTr = null;
    public Transform target = null;

    public float length = 0f;
    public float speed = 5f;
    float runingTime = 0f;
    Vector2 pos;

    public float m_timerCurrent;
    public float m_timerMax;

    private void Start()
    {
        StartCoroutine(GetDataFromServer());
    }

    IEnumerator GetDataFromServer()
    {
        string url = "http://localhost:3000/api/data"; // Express.js 서버의 주소와 포트를 여기에 입력하세요

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
                // 받은 데이터를 여기에서 처리합니다
            }
        }
    }

    private void Update()
    {
        //runingTime += Time.deltaTime * speed;
        //posTr.transform.position = new Vector3(posTr.transform.position.x, Mathf.Sin(runingTime * length));
        //pos.x = Mathf.Cos(Time.time * 360 * Mathf.Deg2Rad);
        //pos.y = Mathf.Sin(Time.time * 360 * Mathf.Deg2Rad);
        //posTr.transform.position = pos;

        //deg = deg - Time.deltaTime * speed;
        //float rad = deg * Mathf.Deg2Rad;
        //posTr.transform.position = new Vector2(Mathf.Cos(rad)
        //    , Mathf.Sin(rad));
        //posTr.transform.eulerAngles = new Vector3(0, 0, deg);

        //var dis = Vector3.Distance(transform.position, target.position);

        //var theta = 90 + target.eulerAngles.y;
        //var posx = Mathf.Cos(theta * Mathf.Deg2Rad) * (dis * 0.5f);
        //var posy = Mathf.Sin(theta * Mathf.Deg2Rad);

        //Debug.Log($"{posx},{posy}");
    }

    private float CubicBezierCurve(float a, float b, float c, float d)
    {
        float t = m_timerCurrent / m_timerMax;

        // 이해한대로 편하게 쓰면.
        float ab = Mathf.Lerp(a, b, t);
        float bc = Mathf.Lerp(b, c, t);
        float cd = Mathf.Lerp(c, d, t);

        float abbc = Mathf.Lerp(ab, bc, t);
        float bccd = Mathf.Lerp(bc, cd, t);

        return Mathf.Lerp(abbc, bccd, t);
    }

    IEnumerator Q()
    {
        yield return null;
    }
}
