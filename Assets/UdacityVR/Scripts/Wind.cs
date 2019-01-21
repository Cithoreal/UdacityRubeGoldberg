using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {
    public float windPower;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Throwable")
        {
            other.GetComponent<Rigidbody>().AddForce(transform.up * windPower, ForceMode.Force);
        }
    }
}
