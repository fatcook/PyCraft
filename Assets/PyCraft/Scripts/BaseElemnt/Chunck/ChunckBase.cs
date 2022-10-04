using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

namespace PyCraft
{
    public class ChunckBase : MonoBehaviour
    {
        /// <summary>
        /// 顶点列表
        /// </summary>
        private List<Vector3> vertices = new List<Vector3>();

        /// <summary>
        /// 顶点索引列表
        /// </summary>
        private List<int> triangleIndex = new List<int>();

        /// <summary>
        /// 方块记录
        /// </summary>
        private Block[,,] truncksMap;

        /// <summary>
        /// 地形宽度
        /// </summary>
        private int width;
        /// <summary>
        /// 地形宽度
        /// </summary>
        public int Width
        {
            get => width;
            set => width = value;
        }

        /// <summary>
        /// 地形长度
        /// </summary>
        private int length;
        /// <summary>
        /// 地形长度
        /// </summary>
        public int Length
        {
            get => length;
            set => length = value;
        }

        /// <summary>
        /// 地形高度
        /// </summary>
        private int height;
        /// <summary>
        /// 地形高度
        /// </summary>
        public int Height
        {
            get => height;
            set => height = value;
        }

        /// <summary>
        /// MeshCollider
        /// </summary>
        private MeshCollider meshCollider;
        /// <summary>
        /// MeshCollider
        /// </summary>
        private MeshFilter meshFilter;

        /// <summary>
        /// uv列表
        /// </summary>
        private List<Vector2> uvs = new List<Vector2>();
        /// <summary>
        /// 贴图偏移，16 x 16
        /// </summary>
        private float offset = 1f / 16f;

        /// <summary>
        /// 构造方法
        /// </summary>
        public ChunckBase()
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            meshCollider = GetComponent<MeshCollider>();
            meshFilter = GetComponent<MeshFilter>();
        }

        /// <summary>
        /// 添加立方体面
        /// </summary>
        /// <param name="type">立方体面类型</param>
        public void AddPanel(PanelType type, int x, int y, int z, int curPanelTextureX, int curPanelTextureY)
        {
            var tmpBasePosList = GameMgr.Instance().BaseVerticesPosDic[type];
            //顶点序列
            triangleIndex.Add(0 + vertices.Count);
            triangleIndex.Add(1 + vertices.Count);
            triangleIndex.Add(2 + vertices.Count);
            triangleIndex.Add(2 + vertices.Count);
            triangleIndex.Add(3 + vertices.Count);
            triangleIndex.Add(0 + vertices.Count);
            //顶点坐标
            for (int i = 0; i < tmpBasePosList.Count; i++)
            {
                var tmpVertic = new Vector3(tmpBasePosList[i].x + x, tmpBasePosList[i].y + y, tmpBasePosList[i].z + z);
                vertices.Add(tmpVertic);
            }
            //UV坐标，要和Vertices顶点对应
            switch (type)
            {
                case PanelType.Front:
                case PanelType.Left:
                case PanelType.Top:
                    uvs.Add(new Vector2(0 + curPanelTextureX * offset, 0 + curPanelTextureY * offset));
                    uvs.Add(new Vector2(0 + curPanelTextureX * offset, offset + curPanelTextureY * offset));
                    uvs.Add(new Vector2(offset + curPanelTextureX * offset, offset + curPanelTextureY * offset));
                    uvs.Add(new Vector2(offset + curPanelTextureX * offset, curPanelTextureY * offset));
                    break;
                case PanelType.Back:
                case PanelType.Right:
                case PanelType.Bottom:
                    uvs.Add(new Vector2(0 + curPanelTextureX * offset, 0 + curPanelTextureY * offset));
                    uvs.Add(new Vector2(offset + curPanelTextureX * offset, curPanelTextureY * offset));
                    uvs.Add(new Vector2(offset + curPanelTextureX * offset, offset + curPanelTextureY * offset));
                    uvs.Add(new Vector2(0 + curPanelTextureX * offset, offset + curPanelTextureY * offset));
                    break;
            }
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <param name="height"></param>
        public void CreateTerrain(int width, int length, int height)
        {
            Width = width;
            Length = length;
            Height = height;
            truncksMap = new Block[Width, Length, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Length; y++)
                {
                    for (int z = 0; z < Height; z++)
                    {
                        if (y == Length - 1)
                        {
                            truncksMap[x, y, z] = new Block("Grass", 3, 15, 3, 15, 0, 15, 2, 15);
                        }
                        else
                            truncksMap[x, y, z] = new Block("Dirt", 2, 15, 2, 15, 2, 15, 2, 15);
                    }
                }
            }

            //渲染贴图
            RenderChunckPanel();
        }

        /// <summary>
        /// 渲染方块面
        /// </summary>
        public void RenderChunckPanel()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Length; y++)
                {
                    for (int z = 0; z < Height; z++)
                    {
                        var mesh = new Mesh();
                        mesh.name = "ChunckBase";
                        if (truncksMap[x, y, z] != null)
                        {
                            //生成方块六个面
                            foreach (PanelType type in Enum.GetValues(typeof(PanelType)))
                            {
                                var tmpCurPanelTextrueX = truncksMap[x, y, z].CurPanelTextureUVDic[type][0];
                                var tmpCurPanelTextrueY = truncksMap[x, y, z].CurPanelTextureUVDic[type][1];
                                switch (type)
                                {
                                    case PanelType.Front:
                                        if (JudgeIsEdgeChunck(x + 1, y, z))
                                            AddPanel(type, x, y, z, tmpCurPanelTextrueX, tmpCurPanelTextrueY);
                                        break;
                                    case PanelType.Back:
                                        if (JudgeIsEdgeChunck(x - 1, y, z))
                                            AddPanel(type, x, y, z, tmpCurPanelTextrueX, tmpCurPanelTextrueY);
                                        break;
                                    case PanelType.Left:
                                        if (JudgeIsEdgeChunck(x, y, z - 1))
                                            AddPanel(type, x, y, z, tmpCurPanelTextrueX, tmpCurPanelTextrueY);
                                        break;
                                    case PanelType.Right:
                                        if (JudgeIsEdgeChunck(x, y, z + 1))
                                            AddPanel(type, x, y, z, tmpCurPanelTextrueX, tmpCurPanelTextrueY);
                                        break;
                                    case PanelType.Top:
                                        if (JudgeIsEdgeChunck(x, y + 1, z))
                                            AddPanel(type, x, y, z, tmpCurPanelTextrueX, tmpCurPanelTextrueY);
                                        break;
                                    case PanelType.Bottom:
                                        if (JudgeIsEdgeChunck(x, y - 1, z))
                                            AddPanel(type, x, y, z, tmpCurPanelTextrueX, tmpCurPanelTextrueY);
                                        break;
                                }
                            }
                        }

                        mesh.vertices = vertices.ToArray();
                        mesh.triangles = triangleIndex.ToArray();
                        mesh.uv = uvs.ToArray();
                        mesh.RecalculateBounds();
                        mesh.RecalculateNormals();
                        meshCollider.sharedMesh = mesh;
                        meshFilter.mesh = mesh;
                    }
                }
            }
        }

        /// <summary>
        /// 判断是否是最外面的方块
        /// </summary>
        /// <param name="posX">方块x轴序号</param>
        /// <param name="posY">方块y轴序号</param>
        /// <param name="posZ">方块z轴序号</param>
        /// <returns></returns>
        public bool JudgeIsEdgeChunck(int posX, int posY, int posZ)
        {
            if (posX >= Width || posY >= Length || posZ >= Height || posX < 0 || posY < 0 || posZ < 0)
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// 立方体面类型枚举
    /// </summary>
    public enum PanelType
    {
        Front,
        Back,
        Left,
        Right,
        Top,
        Bottom
    }
}

