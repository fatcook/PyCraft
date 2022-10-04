using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyCraft
{
    public class StartGame : MonoBehaviour
    {
        /// <summary>
        /// 开始游戏
        /// </summary>
        void Start()
        {
            GameMgr.Instance().Init();
            DebugMgr.Instance().Init();

        }
    }
}

