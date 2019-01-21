using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenuManager : MonoBehaviour {
    public List<GameObject> objectList; //handled automatically at start
    public List<GameObject> objectPrefabList; //set manually in inspector and MUST match order
                                              //of scene menu objects
    public GameObject parentObject;
    public int currentObject = 0;
    public bool isActive;

    private StructureManager structureManager;
    private BallReset ballReset;
	// Use this for initialization
	void Start () {
        ballReset = FindObjectOfType<BallReset>();
		foreach(Transform child in transform)
        {
            objectList.Add(child.gameObject);
        }
        structureManager = objectList[currentObject].GetComponent<StructureManager>();

    }

    public void MenuLeft()
    {
        if (isActive)
        {
            objectList[currentObject].SetActive(false);
            currentObject--;
            if (currentObject < 0)
            {
                currentObject = objectList.Count - 1;
            }
            objectList[currentObject].SetActive(true);
            structureManager = objectList[currentObject].GetComponent<StructureManager>();
        }
    }
    public void MenuRight()
    {
        if (isActive)
        {
            objectList[currentObject].SetActive(false);
            currentObject++;
            if (currentObject > objectList.Count - 1)
            {
                currentObject = 0;
            }
            objectList[currentObject].SetActive(true);
            structureManager = objectList[currentObject].GetComponent<StructureManager>();
        }
    }
    public void SpawnCurrentObject()
    {
        if (isActive && structureManager.canSpawn)
        {
            GameObject structure = Instantiate(objectPrefabList[currentObject],
                objectList[currentObject].transform.position,
                objectList[currentObject].transform.rotation);
            structure.transform.Rotate(structureManager.xRotationOffset,
                structure.transform.rotation.y,
                structure.transform.rotation.z);
            structureManager.SpawnStructure(structure);
            if (parentObject != null) {
                structure.transform.SetParent(parentObject.transform);
            }
            ballReset.SetInvalidRun();
        }
    }

    public void DeleteObject(GameObject selectedObject)
    {
        foreach (GameObject thisObject in objectList)
        {
            if (thisObject.GetComponent<StructureManager>().spawnedStructureList.Contains(selectedObject))
            {
                thisObject.GetComponent<StructureManager>().DeleteStructure(selectedObject);
                Destroy(selectedObject);
            }
        }
    }

    public void EnableObjectMenu()
    {
        gameObject.SetActive(true);
        isActive = true;
    }

    public void DisableObjectMenu()
    {
        gameObject.SetActive(false);
        isActive = false;
    }
    
}
