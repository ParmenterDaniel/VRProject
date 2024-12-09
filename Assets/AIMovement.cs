using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;

    Vector3 destPoint;
    bool walkPointset;
    public float walkRange;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkPointset) SearchForDestination();
        if (walkPointset)
        {
            agent.SetDestination(destPoint);
            GetComponent<Animation>().Play("Walk");
        }
        if (Vector3.Distance(transform.position, destPoint) < 10) walkPointset = false;

    }

    void SearchForDestination()
    {
        float z = Random.Range(-walkRange, walkRange);
        float x = Random.Range(-walkRange, walkRange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, layer))
        {
            walkPointset = true;
        }


    }
}