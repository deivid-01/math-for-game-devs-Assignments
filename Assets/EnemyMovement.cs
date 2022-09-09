using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speed;
    [SerializeField] private Transform tr_target;

 

    // Update is called once per frame
    void Update()
    {


        //Get direction
        Vector3 direction = ( tr_target.position - this.transform.position).normalized;

        //Translate enemy
        this.transform.position += direction * _speed * Time.deltaTime;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(this.transform.position, tr_target.position);
    }
}
