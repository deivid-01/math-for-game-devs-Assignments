using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignment4_bouncinglaser : MonoBehaviour
{
   [SerializeField] [Range(0,10)] private int maxBounceCount;
   [SerializeField] [Range(0,1)] private float  radius;
   public bool customReflect = true;
   private Rigidbody2D rb;
   private void OnDrawGizmos()
   {
      Gizmos.color = Color.red;
      Gizmos.DrawSphere(transform.position,radius);
     // RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
    //  if (Physics.Raycast(transform.position,transform.forward, out RaycastHit hit,1)) //3d 
    Vector2 origin = transform.position;
    Vector2 direction = transform.up;
    for (int i = 0; i < maxBounceCount; i++)
    {

       RaycastHit2D hit = Physics2D.Raycast(origin, direction);
       if (hit)
       {
          Gizmos.color = Color.green;
          Gizmos.DrawRay(origin,(hit.point-origin)); //to-from

          origin = hit.point;
          Vector3 inDirection = (Vector3)hit.point - transform.position;
          //DrawNormal
          //Gizmos.color = Color.cyan;
         // Gizmos.DrawRay(hit.point,hit.normal);
         // direction = (hit.normal+hit.point).normalized;
         if (customReflect)
            
         direction = GetReflect(inDirection, hit.normal);
         else
         //Built- int unity reflection                                                                                           
         direction=Vector2.Reflect((Vector3)hit.point - transform.position, hit.normal);
       }
       else
       {
          Gizmos.color = Color.red;
          
          Gizmos.DrawRay(origin,direction);
          break;
       }
    }
    
    
   }

    Vector3 GetReflect(Vector3 inDirection,Vector3 normal)
    {
       //Reflected ray by mirrors formula
         return  inDirection-2*Vector3.Dot(inDirection,normal)*normal;
         
      }
   

  void Start()
  {
     rb = GetComponent<Rigidbody2D>();

    // rb.velocity = transform.up * 1;


  }

  private void Update()
  {
   //  ctrController.Move(transform.up * Time.deltaTime * 1);
  }
}

