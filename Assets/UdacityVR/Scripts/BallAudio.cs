using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour {
    private AudioSource audioSource;

    public AudioClip teleport;
    public AudioClip reset;
    public AudioClip rollOnWood;
    public AudioClip rollOnMetal;
    public AudioClip bounce;
    public AudioClip switchState;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MetalPlank")
        {
            audioSource.clip = rollOnMetal;
            audioSource.Play();
        }

        if (collision.gameObject.tag == "WoodPlank")
        {
            audioSource.clip = rollOnWood;
            audioSource.Play();
        }

        if (collision.gameObject.tag == "Trampoline")
        {
            audioSource.clip = bounce;
            audioSource.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Teleporter")
        {
            audioSource.clip = teleport;
            audioSource.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "WoodPlank" && audioSource.clip != rollOnMetal)
        {
            audioSource.Stop();
        }

        if (collision.gameObject.tag == "MetalPlank" && audioSource.clip != rollOnWood)
        {
            audioSource.Stop();
        }
    }

    public void PlayReset()
    {
        audioSource.clip = reset;
        audioSource.Play();
    }

    public void PlaySwitchState()
    {
        audioSource.clip = switchState;
        audioSource.Play();
    }
}
