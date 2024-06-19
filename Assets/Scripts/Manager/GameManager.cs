using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public ulong SpawnUUID { get; private set; }
    public Transform character_InitPosTr = null;
    public Transform enemy_InitPosTr = null;

    ServerManager serverManager = null;

    private void Awake()
    {
        serverManager = GetComponent<ServerManager>();
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        if (Excel.TableData.Inst == null)
        {
            new Excel.TableData();
        }

        GameEventObserver.Publish(GameEventType.GameStart, null);
        GameEventObserver.Publish(GameEventType.CameraIsStopStart, false);

        //serverManager.GetSeverData(4000);
    }
}
