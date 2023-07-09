using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavegationArea : MonoBehaviour
{
   private Mesh NavMesh;
   public List<NavNode> _navNodes = new List<NavNode>();

   private void Awake()
   {
      NavMesh = GetComponent<MeshFilter>().mesh;
   }
   
   [ContextMenu("Calculate NavegationNodes")]
   public List<NavNode> CalculateNodes()
   {
      var result = new List<NavNode>();
      var meshVertexs = NavMesh.vertices;
      foreach (var vertex in meshVertexs)
      {
         Vector3 worldPt = transform.TransformPoint(vertex);
         var node = new NavNode(worldPt);
         result.Add(node);
      }
      return result;
   }
}
