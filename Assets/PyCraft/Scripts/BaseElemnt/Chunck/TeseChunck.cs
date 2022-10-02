using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyCraft
{
    public class TeseChunck : ChunckBase
    {
        /// <summary>
        /// 顶点信息
        /// </summary>
        private List<Vector3> vertices = new List<Vector3>();
        /// <summary>
        /// 三角形顶点索引数组(顺时针表示正面，逆时针表示背面)
        /// </summary>
        private List<int> triangles = new List<int>();


    }
}

