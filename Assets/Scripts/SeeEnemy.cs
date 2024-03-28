using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class SeeEnemy : MonoBehaviour
{
    public GameObject currentHitObject;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;
    private Vector3 origin;
    private Vector3 direction;

    private float currentHitDistance;

    public NavMeshAgent ai;
    public GameObject enemy;
    Vector3 dest;
    public float aiSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.activeInHierarchy)
        {
            origin = transform.position;
            direction = transform.forward;

            RaycastHit hit;

            if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
            {
                currentHitObject = hit.transform.gameObject;
                currentHitDistance = hit.distance;

                Debug.Log("not moveing");
                ai.speed = 0;
                ai.SetDestination(enemy.transform.position);
                ai.transform.LookAt(transform.position);
            }
            else
            {
                ai.speed = aiSpeed;
                dest = transform.position;
                ai.destination = dest;
                Debug.Log("moveing");
                currentHitObject = null;
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
}
