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
        /// ������������((0,0,0)��ʼ˳ʱ�뵽(0,1,0)���ĸ���)
        /// </summary>
        private Dictionary<PanelType, List<Vector3>> baseVerticesPosDic = new Dictionary<PanelType, List<Vector3>>();


        /// <summary>
        /// ������������((0,0,0)��ʼ˳ʱ�뵽(0,1,0)���ĸ���)
        /// </summary>
        public Dictionary<PanelType, List<Vector3>> BaseVerticesPosDic
        {
            get
            {
                if (baseVerticesPosDic == null)
                    baseVerticesPosDic = new Dictionary<PanelType, List<Vector3>>();
                else if (baseVerticesPosDic?.Count < 6)
                {
                    baseVerticesPosDic.Clear();
                    if (!baseVerticesPosDic.ContainsKey(PanelType.Front))
                    {
                        baseVerticesPosDic.Add(PanelType.Front, new List<Vector3>());
                        baseVerticesPosDic[PanelType.Front].Add(new Vector3(1, 0, 0));
                        baseVerticesPosDic[PanelType.Front].Add(new Vector3(1, 1, 0));
                        baseVerticesPosDic[PanelType.Front].Add(new Vector3(1, 1, 1));
                        baseVerticesPosDic[PanelType.Front].Add(new Vector3(1, 0, 1));
                    }
                    if (!baseVerticesPosDic.ContainsKey(PanelType.Back))
                    {
                        baseVerticesPosDic.Add(PanelType.Back, new List<Vector3>());
                        baseVerticesPosDic[PanelType.Back].Add(new Vector3(0, 0, 0));
                        baseVerticesPosDic[PanelType.Back].Add(new Vector3(0, 0, 1));
                        baseVerticesPosDic[PanelType.Back].Add(new Vector3(0, 1, 1));
                        baseVerticesPosDic[PanelType.Back].Add(new Vector3(0, 1, 0));
                    }
                    if (!baseVerticesPosDic.ContainsKey(PanelType.Left))
                    {
                        baseVerticesPosDic.Add(PanelType.Left, new List<Vector3>());
                        baseVerticesPosDic[PanelType.Left].Add(new Vector3(0, 0, 0));
                        baseVerticesPosDic[PanelType.Left].Add(new Vector3(0, 1, 0));
                        baseVerticesPosDic[PanelType.Left].Add(new Vector3(1, 1, 0));
                        baseVerticesPosDic[PanelType.Left].Add(new Vector3(1, 0, 0));
                    }
                    if (!baseVerticesPosDic.ContainsKey(PanelType.Right))
                    {
                        baseVerticesPosDic.Add(PanelType.Right, new List<Vector3>());
                        baseVerticesPosDic[PanelType.Right].Add(new Vector3(0, 0, 1));
                        baseVerticesPosDic[PanelType.Right].Add(new Vector3(1, 0, 1));
                        baseVerticesPosDic[PanelType.Right].Add(new Vector3(1, 1, 1));
                        baseVerticesPosDic[PanelType.Right].Add(new Vector3(0, 1, 1));
                    }
                    if (!baseVerticesPosDic.ContainsKey(PanelType.Top))
                    {
                        baseVerticesPosDic.Add(PanelType.Top, new List<Vector3>());
                        baseVerticesPosDic[PanelType.Top].Add(new Vector3(0, 1, 0));
                        baseVerticesPosDic[PanelType.Top].Add(new Vector3(0, 1, 1));
                        baseVerticesPosDic[PanelType.Top].Add(new Vector3(1, 1, 1));
                        baseVerticesPosDic[PanelType.Top].Add(new Vector3(1, 1, 0));
                    }
                    if (!baseVerticesPosDic.ContainsKey(PanelType.Bottom))
                    {
                        baseVerticesPosDic.Add(PanelType.Bottom, new List<Vector3>());
                        baseVerticesPosDic[PanelType.Bottom].Add(new Vector3(0, 0, 0));
                        baseVerticesPosDic[PanelType.Bottom].Add(new Vector3(1, 0, 0));
                        baseVerticesPosDic[PanelType.Bottom].Add(new Vector3(1, 0, 1));
                        baseVerticesPosDic[PanelType.Bottom].Add(new Vector3(0, 0, 1));
                    }
                }
                return baseVerticesPosDic;
            }
            set => baseVerticesPosDic = value;
        }
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

