using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    BossAttackScript bossAttackScript;
    PlayerMovement playerMovement;

    [SerializeField] GameObject Boss;
    [SerializeField] float attackDelayTime;

    Vector2 initialPosition;
    BoxCollider2D boxCollider2D;

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    // Flag to check if the enemy is moving in reverse direction
    private bool isReversing = false;

    // Use this for initialization
    private void Start()
    {
        bossAttackScript = Boss.GetComponent<BossAttackScript>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        initialPosition = transform.position;

        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (bossAttackScript.isAttacking)
        {
            Invoke("Move", attackDelayTime);
        }
        else
        {
            transform.position = initialPosition;
            waypointIndex = 0;
            isReversing = false;
        }
    }

    // Method that actually makes the enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex >= 0 && waypointIndex < waypoints.Length)
        {
            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].position,
                moveSpeed * Time.deltaTime);

            // Check if Enemy reaches the current waypoint
            if (transform.position == waypoints[waypointIndex].position)
            {
                // If enemy reached the last waypoint, start reversing
                if (!isReversing && waypointIndex == waypoints.Length - 1)
                {
                    isReversing = true;
                }
                // If enemy reached the first waypoint while reversing, stop reversing
                else if (isReversing && waypointIndex == 0)
                {
                    isReversing = false;
                }

                // Update waypoint index based on direction
                waypointIndex += isReversing ? -1 : 1;
            }
        }
    }
}
