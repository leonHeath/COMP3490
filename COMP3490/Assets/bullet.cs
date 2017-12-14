using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bullet : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			other.gameObject.SetActive (false);
			//gameObject.SetActive (false);

		}
	}
}
