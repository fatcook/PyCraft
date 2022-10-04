using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UpUtility.Runtime;

namespace PyCraft
{
    public class DebugMgr : MonoSingleton<DebugMgr>
    {
        /// <summary>
        /// Debug初始化
        /// </summary>
        public void Init()
        {
            InitTestRelative();
        }

        #region Test
        /// <summary>
        /// 测试物体trans 
        /// </summary>
        private Transform debugPanel;
        /// <summary>
        /// 初始化测试相关
        /// </summary>
        public async void InitTestRelative()
        {
            //动态获取预制件
            var tmpGo = await Addressables.InstantiateAsync("ChunckBase", transform).Task;
            var chunckBase = tmpGo.GetComponent<ChunckBase>();
            chunckBase.Init();
            chunckBase.CreateTerrain(10, 10, 10);
        }
        #endregion
    }
}

