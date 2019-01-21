using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;


public class BallReset : MonoBehaviour {
    public SteamVR_LoadLevel loadLevel;
    public GameObject startPoint;
    public List<GameObject> collectableList;
    public int collectedCount = 0;

    public Material validMaterial;
    public Material invalidMaterial;

    public GoalAudio goalAudio;

    public bool levelComplete;
    public bool isInHand;
    private bool validRun;
    private Rigidbody rigidBody;
    private Renderer ballRenderer;
    private BallAudio ballAudio;

	// Use this for initialization
	void Start () {
        validRun = true;
        levelComplete = false;
        collectedCount = 0;
        rigidBody = GetComponent<Rigidbody>();
        ballRenderer = GetComponent<Renderer>();
        ballAudio = GetComponent<BallAudio>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" && !levelComplete)
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            transform.position = startPoint.transform.position;
            Reset();
            ballAudio.PlayReset();
        }

        if (collision.gameObject.tag == "Goal")
        {
            CheckWin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collectableList.Contains(other.gameObject))
        {
            collectedCount++;
            other.gameObject.GetComponent<StarCollect>().AnimateCollectable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "StartZone" && isInHand)
        {
            SetInvalidRun();
        }
    }

    void Reset() {
        collectedCount = 0;
        foreach (GameObject collectable in collectableList) {
            collectable.SetActive(false);
            collectable.SetActive(true);

        }
        validRun = true;
        ballRenderer.material = validMaterial;
    }

    public void OnPickUp()
    {
        isInHand = true;
    }

    public void OnHandDetatch()
    {
        isInHand = false;
    }

    public void SetInvalidRun() 
    {
        if (validRun)
            ballAudio.PlaySwitchState();
        validRun = false;
        ballRenderer.material = invalidMaterial;
    }

    void CheckWin() 
    {
        if (validRun && collectedCount == collectableList.Count) {
            levelComplete = true;
            goalAudio.PlayWinSound();
            Invoke("LoadNextLevel", 1.5f);
        }
    }

    void LoadNextLevel() {
        loadLevel.Trigger();
    }

}
