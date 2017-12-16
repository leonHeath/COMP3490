using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //new
using UnityEngine;

public class character : MonoBehaviour {

	public float health;
	private float max;
	//public Text healthBar;
	//public string heart;
	public Image healthBar;

	void Start()
	{
		//heart = "";
		max = health;
		SetHealthBar ();

	}

	// Update is called once per frame
	void Update () 
	{
		if (health <= 0) 
		{
			//source.PlayOneShot (dieSound);
			//Destroy (gameObject);
		}
	}



	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			health -= 1;
			//heart = "";
			SetHealthBar ();
		}
	}

	void SetHealthBar ()
	{
		//for(int i = 0; i <= health-1; i++)
		//{
		//	heart += "<3";
		//}
		//healthBar.text = "Health: "+ heart;
		healthBar.fillAmount = health/max;
	}



}