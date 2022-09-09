using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assigment3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform point;
    public Transform otherspace;
    public Vector3 localPosition;
    public Vector3 worldPosition;
    public Vector3 worldPositionv2;


    private void OnDrawGizmos()
    {

        DrawAxisOtherSpace();
        DrawAxisWorldSpace();
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(point.position, 0.2f);
      
        


         localPosition = World2OtherSpace(otherspace,point.position);
         worldPosition = OtherSpace2World(otherspace,localPosition);
            worldPositionv2 = OtherSpace2Worldv2(otherspace, localPosition);


    }

    void DrawAxisWorldSpace()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.left * 100, Vector3.right * 100);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.back * 100, Vector3.forward* 100);


    }

    void DrawAxisOtherSpace()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(otherspace.position - otherspace.forward * 100,
                        otherspace.position + otherspace.forward * 100);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(otherspace.position - otherspace.right * 100,
                        otherspace.position + otherspace.right * 100);
      
    }

    Vector3  World2OtherSpace(Transform otherspace,Vector3 point)
    {
        Vector3 directionPoint = point- otherspace.position;

        Vector3 localPosition = new Vector3(
            x: Vector3.Dot(otherspace.right, directionPoint),
            y:0,
            z: Vector3.Dot(otherspace.forward, directionPoint));
       
        return localPosition;
    }

    Vector3 OtherSpace2Worldv2(Transform otherSpace, Vector3 localPosition)
    {
        
 
        Vector3 worldPosition = otherSpace.position + otherSpace.forward * localPosition.z + otherSpace.right * localPosition.x;

        return worldPosition;
    }

    Vector3 OtherSpace2World(Transform otherSpace,Vector3 localPosition)
    {
        
        Vector3 center = World2OtherSpace(otherSpace,Vector3.zero);
        Vector3 direction = localPosition - center;


        Vector3 worldForward = World2OtherSpace(otherspace, otherspace.position+Vector3.forward).normalized;
        Vector3 worldRight = World2OtherSpace(otherspace, otherspace.position+Vector3.right).normalized;

        Vector3 worldPosition = Vector3.zero;
        
        worldPosition.x = Vector3.Dot(worldRight, direction);
        worldPosition.z = Vector3.Dot(worldForward, direction);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, worldPosition);
       //print(worldPosition);
        return worldPosition;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
