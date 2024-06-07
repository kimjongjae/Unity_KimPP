using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    private Dictionary<string, GameObject> _resourceCache = new Dictionary<string, GameObject>();
    private Dictionary<string, Sprite> _resourceCacheSpr = new Dictionary<string, Sprite>();

    public void LoadResourceFromChche_Go(string Path, out GameObject outGetGo)
    {
        _resourceCache.TryGetValue(Path, out var resourceObj);

        if(ReferenceEquals(resourceObj, null))
        {
            resourceObj = Resources.Load<GameObject>(Path);
            _resourceCache.Add(Path, resourceObj);
        }

        outGetGo = resourceObj;
    }

    public void LoadResourceFromChche_Spr(string Path, out Sprite outGetSpr)
    {
        _resourceCacheSpr.TryGetValue(Path, out var resourceObj);

        if (ReferenceEquals(resourceObj, null))
        {
            resourceObj = (Sprite)Resources.Load(Path, typeof(Sprite));
            _resourceCacheSpr.Add(Path, resourceObj);
        }

        outGetSpr = resourceObj;
    }

    public void ClearChache()
    {
        _resourceCache.Clear();
        Resources.UnloadUnusedAssets();
    }
}
