using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;

    private Vector3 destPoint;
    private bool walkPointSet;
    public float walkRange;
    public LayerMask layer;
    public float sampleRadius = 2.0f;  // Radius to check for valid NavMesh points

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkPointSet) SearchForDestination();

        if (walkPointSet)
        {
            agent.SetDestination(destPoint);
            GetComponent<Animation>().Play("Walk");
        }

        // Reset the destination when close to the current destination
        if (Vector3.Distance(transform.position, destPoint) < 1)
        {
            walkPointSet = false;
        }
    }

    void SearchForDestination()
    {
        // Generate a random point within the defined walk range
        float z = Random.Range(-walkRange, walkRange);
        float x = Random.Range(-walkRange, walkRange);

        Vector3 randomPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        // Validate that the random point is on the NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, sampleRadius, NavMesh.AllAreas))
        {
            destPoint = hit.position;  // Set the valid NavMesh point as the destination
            walkPointSet = true;
        }
    }
}
