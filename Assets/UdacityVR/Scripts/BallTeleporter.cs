using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTeleporter : MonoBehaviour {
    public GameObject teleportPoint;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Throwable" && !other.GetComponent<BallReset>().isInHand && !teleportPoint.GetComponent<TeleportPointClamp>().isInHand)
        { // Changes the direction of the velocity of the ball to the direction indicated by the teleporter
            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            float speed = rigidbody.velocity.magnitude;
            Vector3 newDirection = teleportPoint.transform.forward;
            Vector3 newVelocity = newDirection.normalized * speed;

            rigidbody.velocity = newVelocity;
            other.transform.position = teleportPoint.transform.position;
        }
    }

}
