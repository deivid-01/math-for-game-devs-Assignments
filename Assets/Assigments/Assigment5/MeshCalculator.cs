using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class MeshCalculator : MonoBehaviour
{
   //[SerializeField] private MeshFilter meshFilter;
   [SerializeField] private float  meshArea;
   [SerializeField] private bool   startOver;
   //[SerializeField] private int    numTrianglesToShow;

   private void OnDrawGizmos()
   {
       Mesh mesh = GetComponent<MeshFilter>().mesh;
      // if (startOver)
       {
           meshArea =  CalculateMeshArea ( mesh );
           startOver = false;  
       }

      

   }

   
   float  CalculateMeshArea(Mesh mesh )
   {
      
      
       float area = 0;
    /*
       int numTriangles = (numTrianglesToShow < 0 || numTrianglesToShow*3 > mesh.triangles.Length)
           ? mesh.triangles.Length
           : numTrianglesToShow*3;
           */
    int numTriangles = mesh.triangles.Length;
      
       for (int i = 0; i < numTriangles;i+=3)
       {
           //Get vertexs
           int indexVertex1 = mesh.triangles[i];
           int indexVertex2 = mesh.triangles[i+1];
           int indexVertex3 = mesh.triangles[i+2];
            //Get vectors from vertexs
           Vector3 vertex1 = mesh.vertices[indexVertex1];
           Vector3 middle = mesh.vertices[indexVertex2];
           Vector3 vertex3 = mesh.vertices[indexVertex3];
           
        
            
           Vector3 side1 = vertex1 - middle;
           
           Vector3 side2 = vertex3 - middle;

           Vector3 crossres = Vector3.Cross(side2, side1);

           Vector3 offset = transform.position + middle;
           
           //Draw basis vectors
           //x axis
           
           
           Gizmos.color = Color.red;
           Gizmos.DrawLine(offset,offset+side1);

           //y axis 
           Gizmos.color = Color.green;
           Gizmos.DrawLine(offset,offset+side2);
           
           //z axis
           Gizmos.color = Color.cyan;
           Gizmos.DrawLine(offset,offset+crossres);

           
           area += crossres.magnitude/2; 
       }

       return area;
   }

   


}
