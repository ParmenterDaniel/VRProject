using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public GameObject playerLoc;
    public GameObject player;
    private NavMeshAgent agent;

    private Vector3 destPoint;
    private bool walkPointSet;
    public float walkRange;
    public LayerMask layer;
    public float sampleRadius = 2.0f;  // Radius to check for valid NavMesh points
    public float chaseRange = 5.0f;
    public float attackRange = 2f;
    public float playerRespawnRange = 0.1f;
    public GameObject playerRespawn;
    private AudioSource audioSource;
    public AudioSource playerAudio;

    public PlayerController playerController;

    bool isWaiting = false;
    private bool playMusic = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isWaiting)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerLoc.transform.position);
            if (distanceToPlayer <= playerRespawnRange && !playerController.hidden)
            {
                playerAudio.Play();
                player.transform.position = playerRespawn.transform.position;
            }
            else if (distanceToPlayer < attackRange && !playerController.hidden) { AttackPlayer(); }
            else if (distanceToPlayer < chaseRange && !playerController.hidden) { ChasePlayer(); }
            else { Patrol(); }
        }
    }

    void Patrol()
    {
        audioSource.Stop();
        playMusic = true;
        agent.speed = 1.05f;
        if (!walkPointSet) SearchForDestination();

        if (walkPointSet)
        {
            agent.SetDestination(destPoint);
            GetComponent<Animation>().Play("Walk");
        }

        // Reset the destination when close to the current destination
        if (Vector3.Distance(transform.position, destPoint) < 0.1f)
        {
            walkPointSet = false;
            StartCoroutine(Wait2Seconds());
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

    IEnumerator Wait2Seconds()
    {
        walkPointSet = true;
        isWaiting = true;
        GetComponent<Animation>().Play("Idle");
        yield return new WaitForSeconds(1);
        isWaiting = false;
        walkPointSet = false;
        //Patrol();
    }

    void AttackPlayer()
    {
        //TODO
        agent.SetDestination(player.transform.position);
        int attackAnim = Random.Range(1, 3);
        switch (attackAnim)
        {
            case 1:
                GetComponent<Animation>().Play("Attack1");
                break;
            case 2:
                GetComponent<Animation>().Play("Attack2");
                break;
            default:
                GetComponent<Animation>().Play("Attack1");
                break;
        }
        
    }
    void ChasePlayer()
    {
        //TODO
        agent.SetDestination(player.transform.position);
        GetComponent<Animation>().Play("Run");
        if(playMusic)
            audioSource.Play();
        playMusic = false;
        agent.speed = 1.35f;
    }
}
