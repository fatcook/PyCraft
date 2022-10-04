using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.AddressableAssets.HostingServices;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UpUtility.Runtime;

namespace PyCraft
{
    public class ResMgr : MonoSingleton<ResMgr>
    {
        /// <summary>
        /// 预制件缓存
        /// </summary>
        private Dictionary<string, GameObject> prefabCacheDic = new Dictionary<string, GameObject>();

        /// <summary>
        /// 预制件缓存
        /// </summary>
        public Dictionary<string, GameObject> PrefabCacheDic
        {
            get
            {
                if (prefabCacheDic == null)
                    prefabCacheDic = new Dictionary<string, GameObject>();
                return prefabCacheDic;
            }
            set => prefabCacheDic = value;
        }

        /// <summary>
        /// 加载Prefab
        /// </summary>
        /// <returns></returns>
        public async UniTask LoadPrefab()
        {
            var keys = new List<string>();
            keys.Add("Prefab");
            var asyncOperationHandle = Addressables.LoadAssetsAsync<GameObject>(keys, null, Addressables.MergeMode.Intersection);
            asyncOperationHandle.Completed += handle =>
            {
                if (handle.Result != null)
                {
                    foreach (var r in handle.Result)
                    {
                        if (!prefabCacheDic.ContainsKey(r.name))
                            prefabCacheDic.Add(r.name, r);
                    }
                }
                else
                {
                    Debug.Log("加载预制件失败!");
                }
            };
        }
    }
}

