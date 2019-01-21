using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPointClamp : MonoBehaviour {
    public GameObject teleporterBounds; // Visual zone around the teleporter object that determines how far away the teleporter point can be placed
    public bool isInHand; //The ball can't be teleported if the teleporter point is being moved to prevent uninteded teleportation behavior
    private float zOffset; //The bounds need to be centered around the teleporter point starting spot, not the teleporter itself
    private float boundSize; //Determined by the size of the teleporterBounds variable
    // Use this for initialization
    void Start () {
        boundSize = teleporterBounds.transform.localScale.x / 2 ;
        zOffset = transform.localPosition.z;
	}

    public void ShowBounds() //The boundary is only visible when moving the teleporter point
    {
        teleporterBounds.gameObject.SetActive(true);
        isInHand = true;
    }
    public void HandDetatch() // Move the teleporter point back within the boundary if it was moved outside of it
    {
        isInHand = false;
        teleporterBounds.gameObject.SetActive(false);
        float x = transform.localPosition.x;
        float y = transform.localPosition.y;
        float z = transform.localPosition.z;
        if (x > boundSize)
        {
            x = boundSize;
        } else if (x < -boundSize)
        {
            x = -boundSize;
        }
        if (y > boundSize)
        {
            y = boundSize;
        }
        else if (y < -boundSize)
        {
            y = -boundSize;
        }
            if (z > boundSize + zOffset)
        {
            z = boundSize + zOffset;
        }
        else if (z < -boundSize + zOffset)
        {
            z = -boundSize + zOffset;
        }
            transform.localPosition = new Vector3(x, y, z);
    }
}
