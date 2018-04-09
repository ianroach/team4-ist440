﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SelectOnInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObject;

    private bool buttonSelected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Vertical") !=0  && buttonSelected == false) /* Reads inputs from both keyboard or gamepad */
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true; /*Sets inputs entered to true in the boolean */
        }
	}

    private void OnDisable()
    {
        buttonSelected = false; /* Any button selected will disable any other inputs*/
    }
}
