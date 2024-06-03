using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    private Dictionary<string, GameObject> _resourceCache;

    public GameObject LoadResourceFromChche(string Path)
    {
        GameObject resourceObj = null;
        _resourceCache.TryGetValue(Path, out resourceObj);

        if(!ReferenceEquals(resourceObj, null))
        {
            resourceObj = Resources.Load<GameObject>(Path);
            _resourceCache.Add(Path, resourceObj);
        }

        return resourceObj;
    }

    //public Sprite LoadResourceFromChche(string Path)
    //{
    //    GameObject resourceObj = null;
    //    _resourceCache.TryGetValue(Path, out resourceObj);

    //    if (!ReferenceEquals(resourceObj, null))
    //    {
    //        resourceObj = Resources.Load<GameObject>(Path);
    //        _resourceCache.Add(Path, resourceObj);
    //    }

    //    return resourceObj;
    //}

    public void ClearChache()
    {
        _resourceCache.Clear();
        Resources.UnloadUnusedAssets();
    }
}
