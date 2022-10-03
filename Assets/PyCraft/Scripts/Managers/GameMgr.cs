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
        /// ��ʼ��
        /// </summary>
        public async void Init()
        {
            //����Ԥ�Ƽ�
            var prefabTask = ResMgr.Instance().LoadPrefab().ContinueWith(() =>
            {
                Debug.Log("Ԥ�Ƽ����سɹ�!");
            });
            await UniTask.WhenAll(prefabTask);
        }
    }
}

