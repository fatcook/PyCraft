using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PyCraft
{
    //[RequireComponent(typeof(MeshFilter))]
    //[RequireComponent(typeof(MeshRenderer))]
    //[RequireComponent(typeof(BoxCollider))]
    public class ChunckBase : MonoBehaviour
    {
        public ChunckBase()
        {
            this.gameObject.AddComponent<MeshFilter>();
            this.gameObject.AddComponent<MeshRenderer>();
            this.gameObject.AddComponent<BoxCollider>();
        }
    }
}

