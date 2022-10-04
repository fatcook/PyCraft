using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyCraft
{
    public class Block
    {
        /// <summary>
        /// ��������
        /// </summary>
        private string name;
        /// <summary>
        /// ��������
        /// </summary>
        public string Name
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// ��ǰƽ��ʹ�õ���ͼuv����
        /// </summary>
        private Dictionary<PanelType, List<int>> curPanelTextureUVDic = new Dictionary<PanelType, List<int>>();

        /// <summary>
        /// ��ǰƽ��ʹ�õ���ͼuv����
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
        /// ����ǰ��һ�£�����һ�£����²�һ�µķ���
        /// </summary>
        /// <param name="name">��������</param>
        public Block(string name, int frontX, int frontY, int leftX, int leftY, int topX, int topY, int bottomX, int bottomY)
        {
            this.Name = name;
            //ǰ����ͼһ��
            CurPanelTextureUVDic[PanelType.Front].Add(frontX);
            CurPanelTextureUVDic[PanelType.Front].Add(frontY);
            CurPanelTextureUVDic[PanelType.Back].Add(frontX);
            CurPanelTextureUVDic[PanelType.Back].Add(frontY);
            //������ͼһ��
            CurPanelTextureUVDic[PanelType.Left].Add(leftX);
            CurPanelTextureUVDic[PanelType.Left].Add(leftY);
            CurPanelTextureUVDic[PanelType.Right].Add(leftX);
            CurPanelTextureUVDic[PanelType.Right].Add(leftY);
            //�Ϸ���ͼ
            CurPanelTextureUVDic[PanelType.Top].Add(topX);
            CurPanelTextureUVDic[PanelType.Top].Add(topY);
            //�·���ͼ
            CurPanelTextureUVDic[PanelType.Bottom].Add(bottomX);
            CurPanelTextureUVDic[PanelType.Bottom].Add(bottomY);
        }

        /// <summary>
        /// ����ǰ���������¾���һ�µķ���
        /// </summary>
        /// <param name="name">��������</param>
        public Block(string name, int frontX, int frontY, int leftX, int leftY, int rightX, int rightY, int topX, int topY, int bottomX, int bottomY)
        {

        }
    }
}

