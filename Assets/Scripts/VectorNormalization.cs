using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorNormalization : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform transformEnemy;
    public Transform transformPlayer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transformEnemy.position;
        Vector3 b = transformPlayer.position;

        Vector3 direction = (b - a);

        float angle = (Vector3.SignedAngle(direction, transform.forward, Vector3.up));
  

        transformEnemy.rotation = Quaternion.Euler(0, -angle, 0);
    }

    private void OnDrawGizmos()
    {
        Vector3 a = transformEnemy.position;
        Vector3 b = transformPlayer.position;

        Vector3 direction = (b - a).normalized;

        Gizmos.DrawLine(a,a+direction);
    }
}
