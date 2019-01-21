using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour {

    private BallReset ballReset;

    private void Start() {
        ballReset = FindObjectOfType<BallReset>();
    }

    public void OnPickUp() //Prevents cheating by the player moving objects during a valid run
    {
        GetComponent<Collider>().enabled = false;
        if (transform.childCount > 0)
        {
            foreach (Collider collider in transform.GetComponentsInChildren<Collider>())
            {
                collider.enabled = false;
            }
        }
        ballReset.SetInvalidRun();
    }

    public void OnHandDetatch()
    {
        GetComponent<Collider>().enabled = true;
        if (transform.childCount > 0)
        {
            foreach (Collider collider in transform.GetComponentsInChildren<Collider>())
            {
                collider.enabled = true;
            }
        }
    }
}
