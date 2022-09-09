using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class RadialTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform objTf;

    [Range(0f, 4f)]
    public float radius = 1f;

 
    
    // Update is called once per frame
    void Update()
    {
        
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Vector2 origin = transform.position;
        Vector2 target = objTf.position;

        Handles.DrawWireDisc( origin , Vector3.forward, radius);

        Vector2 disp = target - origin;

        float distSq = disp.sqrMagnitude;  //disp.x * disp.x + disp.y * disp.y;


        
        if (distSq < radius*radius)
        {
           
            Handles.color = Color.red;
            Handles.DrawSolidDisc(origin, Vector3.forward, radius);
        }


    }

#endif
}
