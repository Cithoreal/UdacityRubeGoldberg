using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour {
    private Animator animator;
    private AudioSource audioSource;
    private bool animationTriggered;
    private void Start()
    {
        animationTriggered = false;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void AnimateCollectable()
    {
        if (!animationTriggered) {
            animationTriggered = true;
            audioSource.Play();
            animator.SetTrigger("starCollectTrigger");
        }
    }

    public void DisableStar()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable() {
        animationTriggered = false;
    }
}
