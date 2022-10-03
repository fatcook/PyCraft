using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UpUtility.Runtime;

namespace PyCraft
{
    public class GameMgr : MonoSingleton<GameMgr>
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public async void Init()
        {
            //加载预制件
            var prefabTask = ResMgr.Instance().LoadPrefab().ContinueWith(() =>
            {
                Debug.Log("预制件加载成功!");
            });
            await UniTask.WhenAll(prefabTask);
        }
    }
}

