using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

	public int health;

	// Update is called once per frame
	void Update () 
	{

		if (health <= 0) 
		{
			//gameOver
		}
		
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			health -= 1;

		}
	}
}