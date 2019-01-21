using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ControllerInputManager : MonoBehaviour {

    [SteamVR_DefaultAction("ObjectMenu", "default")]
    public SteamVR_Action_Boolean objectMenu;

    [SteamVR_DefaultAction("CycleMenu", "default")]
    public SteamVR_Action_Vector2 cycleMenu;

    [SteamVR_DefaultAction("GrabPinch", "default")]
    public SteamVR_Action_Boolean spawnObject;

    [SteamVR_DefaultAction("DeleteObject","default")]
    public SteamVR_Action_Boolean deleteObject;

    public ObjectMenuManager objectMenuManager;
    public float menuMoveAmount = .8f;
    private bool menuCycled = false;

	// Update is called once per frame
	void Update () {

        Vector2 moveMenu = cycleMenu.GetAxis(SteamVR_Input_Sources.RightHand);
        if (!menuCycled) {
            menuCycled = true;
            if (moveMenu.x < -menuMoveAmount) {
                objectMenuManager.MenuLeft();
            }

            if (moveMenu.x > menuMoveAmount) {
                objectMenuManager.MenuRight();
            }
        }
         if (Mathf.Abs(moveMenu.x) < menuMoveAmount) {
                menuCycled = false;
            }

		if (objectMenu.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            objectMenuManager.EnableObjectMenu();
        }

        if (objectMenu.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            objectMenuManager.DisableObjectMenu();
        }

        if (spawnObject.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            objectMenuManager.SpawnCurrentObject();
        }

        if (GetComponent<Hand>().currentAttachedObject && deleteObject.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
            objectMenuManager.DeleteObject(GetComponent<Hand>().currentAttachedObject);
        }
	}


}
