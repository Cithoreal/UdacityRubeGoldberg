using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureManager : MonoBehaviour {
    public int structureAmount; // Determines how many of the particular structure can be used in the level
    public List<GameObject> spawnedStructureList;
    public bool canSpawn;

    public Material activeMaterial;
    public Material deactiveMaterial;
    public Color activeTextColor;
    public Color deactiveTextColor;
    public float xRotationOffset; // spawns the object at the correct rotation indicated by the object menu
    public Text titleText;
    public Text remainingText;


	// Use this for initialization
	void Start () {
        if (spawnedStructureList.Count < structureAmount)
        {
            ActivateStructure();
        }
        else
        {
            DeactivateStructure();
        }
	}

    public void SpawnStructure(GameObject structure)
    {
        spawnedStructureList.Add(structure);
        remainingText.text = (structureAmount - spawnedStructureList.Count).ToString();
        if (spawnedStructureList.Count >= structureAmount)
        {
            DeactivateStructure();
        }
    }

    public void DeleteStructure(GameObject structure)
    {
        spawnedStructureList.Remove(structure);
        ActivateStructure();
    }

    public void ActivateStructure() 
    {
        canSpawn = true;
        GetComponentInChildren<Renderer>().material = activeMaterial;
        titleText.color = activeTextColor;
        remainingText.text = (structureAmount - spawnedStructureList.Count).ToString();
    }

    public void DeactivateStructure()
    {
        canSpawn = false;
        GetComponentInChildren<Renderer>().material = deactiveMaterial;
        titleText.color = deactiveTextColor;
        remainingText.text = "";
    }
    
}
