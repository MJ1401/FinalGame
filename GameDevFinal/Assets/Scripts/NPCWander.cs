using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWander : MonoBehaviour {
    public Waypoint[] waypoints;
    public float moveSpeed = 2f;

    private int currentWaypointIndex = 0;
    private Coroutine moveToWaypointCoroutine;

    void Start() {
        moveToWaypointCoroutine = StartCoroutine(MoveToWaypoint());    
    }

    private IEnumerator MoveToWaypoint(){
        while (true)
        {
            Waypoint currentWaypoint = waypoints[currentWaypointIndex];
            Vector3 targetPosition = currentWaypoint.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.forward);

            // Move towards the waypoint
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f) {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // Wait at the waypoint if specified
            if (currentWaypoint.waitTime > 0) {
                yield return new WaitForSeconds(currentWaypoint.waitTime);
            }

            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            if (moveToWaypointCoroutine != null) {
                StopCoroutine(moveToWaypointCoroutine);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            if (moveToWaypointCoroutine == null) {
                moveToWaypointCoroutine = StartCoroutine(MoveToWaypoint());
            }
        }
    }

}
