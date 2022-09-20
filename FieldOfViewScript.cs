using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfViewScript : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject targetRef;
    public LayerMask targetMaskRed;
    public LayerMask enemyBlue;
    public LayerMask targetMaskBlue;
    public LayerMask enemyRed;


    public bool canSeePlayer;

    private void Start()
    {

        targetRef = GameObject.FindGameObjectWithTag("agentBlue");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(1.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        //Collider[] rangeChecksRed = Physics.OverlapSphere(transform.position, radius, targetMaskRed);
        Collider[] rangeChecksRed = Physics.OverlapSphere(transform.position, radius, enemyBlue);
        Collider[] rangeChecksBlue = Physics.OverlapSphere(transform.position, radius, targetMaskBlue);

        if (rangeChecksRed.Length != 0)
        {
            
            Transform target = rangeChecksRed[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                
                if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget))
                {
                    canSeePlayer = true;
                }
                else
                    canSeePlayer = false;
                    
            }
            //else
            //    canSeePlayer = false;
        }
    }
}
