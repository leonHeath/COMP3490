using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;

	void Update ()
	{
		Debug.Log (health.ToString ());

		if (health <= 0) {
			Destroy (gameObject);
		}
	}


}
