using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health;
	public AudioClip hitSound;
	public AudioClip dieSound;

	private AudioSource source;

	void Awake ()
	{
		source = GetComponent<AudioSource> ();
	}

	void Update ()
	{
		Debug.Log (health.ToString ());

		if (health <= 0) 
		{
			//source.PlayOneShot (dieSound);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		//if (health > 1) 
		//{
			source.PlayOneShot (hitSound, 1f);
		//}
		health -= 1;
	}


}
