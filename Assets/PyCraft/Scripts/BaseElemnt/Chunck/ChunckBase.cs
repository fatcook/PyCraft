using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
        /// MeshCollider
        /// </summary>
        private MeshCollider meshCollider;
        /// <summary>
        /// MeshCollider
        /// </summary>
        private MeshFilter meshFilter;

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
        public void AddPanel(PanelType type, int x, int y, int z)
        {
            var tmpBasePosList = GameMgr.Instance().BaseVerticesPosDic[type];
            triangleIndex.Add(0 + vertices.Count);
            triangleIndex.Add(1 + vertices.Count);
            triangleIndex.Add(2 + vertices.Count);
            triangleIndex.Add(2 + vertices.Count);
            triangleIndex.Add(3 + vertices.Count);
            triangleIndex.Add(0 + vertices.Count);
            for (int i = 0; i < tmpBasePosList.Count; i++)
            {
                var tmpVertic = new Vector3(tmpBasePosList[i].x + x, tmpBasePosList[i].y + y, tmpBasePosList[i].z + z);
                vertices.Add(tmpVertic);
            }
        }

        /// <summary>
        /// 渲染方块面
        /// </summary>
        public void RenderChunckPanel()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    for (int z = 0; z < 10; z++)
                    {
                        var mesh = new Mesh();
                        mesh.name = "ChunckBase";
                        //生成方块六个面
                        foreach (PanelType type in Enum.GetValues(typeof(PanelType)))
                            AddPanel(type, x, y, z);
                        mesh.vertices = vertices.ToArray();
                        mesh.triangles = triangleIndex.ToArray();
                        mesh.RecalculateBounds();
                        mesh.RecalculateNormals();
                        meshCollider.sharedMesh = mesh;
                        meshFilter.mesh = mesh;
                    }
                }
            }
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
        Down
    }
}

