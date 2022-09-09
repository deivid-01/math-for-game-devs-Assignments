using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform trPlayer;
    [SerializeField] private Transform trGround;
    [SerializeField] private LayerMask layerGround;


    private void OnDrawGizmos()
    {
        //Draw Ray
        if (Physics.Raycast(trPlayer.position, trPlayer.forward, out RaycastHit hit, layerGround))
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(trPlayer.position,hit.point);
            
            Gizmos.color = Color.green;
            
            Gizmos.DrawLine(hit.point,hit.point+hit.normal);

          //  Gizmos.color = Color.red;
            Vector3 directionPlayer = (hit.point - trPlayer.position).normalized;
          //  Gizmos.DrawLine(hit.point,hit.point+directionPlayer);

            Vector3 cross = Vector3.Cross(hit.normal, directionPlayer);
            
            Gizmos.color = Color.red;
            Gizmos.DrawLine(hit.point,hit.point+cross);

            Vector3 torretDirection = Vector3.Cross(cross, hit.normal);


            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(hit.point,hit.point+torretDirection);
            
            


        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(trPlayer.position,trPlayer.forward*20);
        }
        //Draw axis vectors
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
