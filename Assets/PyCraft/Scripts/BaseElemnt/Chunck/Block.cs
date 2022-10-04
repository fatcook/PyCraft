using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyCraft
{
    public class Block
    {
        /// <summary>
        /// 方块名字
        /// </summary>
        private string name;
        /// <summary>
        /// 方块名字
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// 当前平面使用的贴图uv索引
        /// </summary>
        private Dictionary<PanelType, List<int>> curPanelTextureUVDic = new Dictionary<PanelType, List<int>>();

        /// <summary>
        /// 当前平面使用的贴图uv索引
        /// </summary>
        public Dictionary<PanelType, List<int>> CurPanelTextureUVDic
        {
            get
            {
                if (curPanelTextureUVDic == null)
                    curPanelTextureUVDic = new Dictionary<PanelType, List<int>>();
                else if (curPanelTextureUVDic?.Count < 6)
                {
                    foreach (PanelType type in Enum.GetValues(typeof(PanelType)))
                    {
                        if (!curPanelTextureUVDic.ContainsKey(type))
                        {
                            curPanelTextureUVDic.Add(type, new List<int>());
                        }
                    }
                }
                return curPanelTextureUVDic;
            }
            set => curPanelTextureUVDic = value;
        }

        /// <summary>
        /// 创建前后一致，左右一致，上下不一致的方法
        /// </summary>
        /// <param name="name">方块名称</param>
        public Block(string name, int frontX, int frontY, int leftX, int leftY, int topX, int topY, int bottomX, int bottomY)
        {
            this.Name = name;
            //前后贴图一致
            CurPanelTextureUVDic[PanelType.Front].Add(frontX);
            CurPanelTextureUVDic[PanelType.Front].Add(frontY);
            CurPanelTextureUVDic[PanelType.Back].Add(frontX);
            CurPanelTextureUVDic[PanelType.Back].Add(frontY);
            //左右贴图一致
            CurPanelTextureUVDic[PanelType.Left].Add(leftX);
            CurPanelTextureUVDic[PanelType.Left].Add(leftY);
            CurPanelTextureUVDic[PanelType.Right].Add(leftX);
            CurPanelTextureUVDic[PanelType.Right].Add(leftY);
            //上方贴图
            CurPanelTextureUVDic[PanelType.Top].Add(topX);
            CurPanelTextureUVDic[PanelType.Top].Add(topY);
            //下方贴图
            CurPanelTextureUVDic[PanelType.Bottom].Add(bottomX);
            CurPanelTextureUVDic[PanelType.Bottom].Add(bottomY);
        }

        /// <summary>
        /// 创建前后左右上下均不一致的方块
        /// </summary>
        /// <param name="name">方块名称</param>
        public Block(string name, int frontX, int frontY, int leftX, int leftY, int rightX, int rightY, int topX, int topY, int bottomX, int bottomY)
        {

        }
    }
}

