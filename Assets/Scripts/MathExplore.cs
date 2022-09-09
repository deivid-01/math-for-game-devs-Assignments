using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathExplore : MonoBehaviour
{
    public Transform aTr;
    public Transform bTr;

    public Vector2 proyectilePos;
    [Range (0,4)]
    public float speed;
    void Start()
    {
        proyectilePos = aTr.position;
    }

    // Update is called once per frame
    void Update()
    {
        


            
    
    }



    private void OnDrawGizmos()
    {

        
        Vector2 a = aTr.position;
        Vector2 b = bTr.position;
        Gizmos.color = Color.green;

        PointAlong(a, b); // Point another point
       // MiddlePoint(a, b);
        DrawBasicProyectile();


        
    }

    public void BasicProyectile()
    {
        Vector2 direction = (bTr.position - aTr.position).normalized;
        proyectilePos += direction * speed * Time.deltaTime;
    }

    void PointAlong(Vector2 a, Vector2 b)
    {
        Vector2 direction = (b - a);//.normalized;

        Gizmos.DrawLine(a, direction + a);
    }
    void MiddlePoint(Vector2 a, Vector2 b)
    {
        Vector2 middlePoint = (a-a) / 2;

        Gizmos.DrawSphere(b + middlePoint,0.07f);

    }

    void DrawBasicProyectile()
    {

       // Gizmos.DrawSphere(proyectilePos,0.1f);
    }

    
}
