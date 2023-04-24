using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWander : MonoBehaviour {
    public Waypoint[] waypoints;
    public float moveSpeed = 2f;
    public float rotationSpeed = 5f;

    private int currentWaypointIndex = 0;

    void Start() {
        StartCoroutine(MoveToWaypoint());
    }

    private IEnumerator MoveToWaypoint(){
        while (true)
        {
            Waypoint currentWaypoint = waypoints[currentWaypointIndex];
            Vector3 targetPosition = currentWaypoint.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.forward);

            // Rotate towards the waypoint
            while (Quaternion.Angle(transform.rotation, targetRotation) > 1f) {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w); // Lock rotation on the z-axis
                yield return null;
            }

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
}
