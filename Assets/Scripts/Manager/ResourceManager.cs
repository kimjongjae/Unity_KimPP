using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class ResourceManager : Singleton<ResourceManager>
{
    private Dictionary<string, GameObject> _resourceCache = new Dictionary<string, GameObject>();
    private Dictionary<string, SpriteAtlas> _resourceCacheAtals = new Dictionary<string, SpriteAtlas>();

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

    public SpriteAtlas LoadResourceFromChche_Atlas(string Path)
    {
        SpriteAtlas getAtlas = null;
        if (_resourceCacheAtals.TryGetValue(Path, out getAtlas))
            return getAtlas;
        else
        {
            getAtlas = Resources.Load<SpriteAtlas>("Skill_Icon");
            return getAtlas;
        }
    }

    public void ClearChache()
    {
        _resourceCache.Clear();
        Resources.UnloadUnusedAssets();
    }
}
