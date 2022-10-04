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
        /// 基础顶点坐标((0,0,0)开始顺时针到(0,1,0)共四个点)
        /// </summary>
        private Dictionary<PanelType, List<Vector3>> baseVerticesPosDic = new Dictionary<PanelType, List<Vector3>>();


        /// <summary>
        /// 基础顶点坐标((0,0,0)开始顺时针到(0,1,0)共四个点)
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

