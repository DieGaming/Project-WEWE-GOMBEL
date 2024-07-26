using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] waypoints;
    public float idleTime = 2f;
    public float walkSpeed = 2f;
    public float chaseSpeed = 4f;
    public float sightDistance = 10f;

    private int currentWaypointIndex = 0;
    private NavMeshAgent agent;
    private float idleTimer = 0f;
    private Transform player;
    private PlayerUI playerUI; // Reference to PlayerUI script
    private LightFlicker lightFlicker; // Reference to LightFlicker script

    private enum EnemyState
    {
        Idle,
        Walk,
        Chase
    }
    private EnemyState currentState = EnemyState.Idle;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            playerUI = playerObject.GetComponent<PlayerUI>();
        }

        lightFlicker = GetComponent<LightFlicker>(); // Get LightFlicker component
        if (lightFlicker != null)
        {
            lightFlicker.enabled = false; // Start with LightFlicker disabled
        }

        SetDestinationToWaypoint();
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                idleTimer += Time.deltaTime;
                if (idleTimer >= idleTime)
                {
                    NextWaypoint();
                }
                CheckForPlayerDetection();
                break;
            case EnemyState.Walk:
                idleTimer = 0f;
                if (agent.remainingDistance <= 0.1f)
                {
                    currentState = EnemyState.Idle;
                }
                CheckForPlayerDetection();
                break;
            case EnemyState.Chase:
                idleTimer = 0f;
                agent.speed = chaseSpeed;
                agent.SetDestination(player.position);
                if (Vector3.Distance(transform.position, player.position) > sightDistance)
                {
                    currentState = EnemyState.Walk;
                    agent.speed = walkSpeed;
                    playerUI.HideDetectionUI(); // Hide the UI when player is out of sight
                    if (lightFlicker != null)
                    {
                        lightFlicker.enabled = false; // Disable LightFlicker script
                    }
                }
                break;
        }
    }

    private void CheckForPlayerDetection()
    {
        RaycastHit hit;
        Vector3 playerDirection = player.position - transform.position;

        if (Physics.Raycast(transform.position, playerDirection, out hit, sightDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                currentState = EnemyState.Chase;
                playerUI.ShowDetectionUI(); // Show the UI when player is detected
                if (lightFlicker != null)
                {
                    lightFlicker.enabled = true; // Enable LightFlicker script
                }
                Debug.Log("Player detected!");
            }
        }
    }

    private void NextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        SetDestinationToWaypoint();
    }

    private void SetDestinationToWaypoint()
    {
        agent.SetDestination(waypoints[currentWaypointIndex].position);
        currentState = EnemyState.Walk;
        agent.speed = walkSpeed; // Set the walking speed
    }

    private void OnDrawGizmos()
    {
        if (player != null)
        {
            Gizmos.color = currentState == EnemyState.Chase ? Color.red : Color.green;
            Gizmos.DrawLine(transform.position, player.position);
        }
    }
}
