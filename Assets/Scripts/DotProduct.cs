using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DotProduct : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform tr_target;
    [SerializeField] private Transform tr_player;

    [Range(0, 1)] [SerializeField] private float threshold;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector3 playerPosition = tr_player.position;
        Vector3 targetPosition = tr_target.position;
        Vector3 targetNormalized = targetPosition.normalized;


        //Draw player and target
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPosition, 0.1f);
        Gizmos.color = Color.green;
        //Gizmos.DraI(playerPosition, 1);

        //Draw direction
        Gizmos.DrawLine(transform.position, tr_player.position);

        float result = Vector3.Dot(tr_player.position.normalized, targetNormalized);

        
        Handles.color = (result>= threshold) ?Color.red: Color.green;
        Gizmos.color = (result>= threshold) ?Color.red: Color.green;



        //Draw look range
        Gizmos.DrawLine(transform.position, targetNormalized);

        float rangeView=180-threshold * 180;
  
        
        Handles.DrawWireArc(transform.position, Vector3.up,playerPosition.normalized, rangeView/2, 3);
        Handles.DrawWireArc(transform.position, Vector3.up,playerPosition.normalized,-rangeView/2 , 3);


        //Debug.Log(result);
    }

    #endif


}
