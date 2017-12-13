using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour {

	private Light myLight;

	//myLight.enabled = !myLight.enabled;

	// Use this for initialization
	void Start () {
		myLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.F)) 
		{
			myLight.enabled = !myLight.enabled;
		}
	}
}
