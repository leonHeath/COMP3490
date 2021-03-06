﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;
using System;

public class gun : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	public float speed;
	public float ammo;
	public float capacity = 6f;
	public Text ammoDisplay;


	public AudioClip shotSound;
	public AudioClip reloadSound;

	public Camera fpsCam;
	public GameObject bullet;
	public GameObject bulletEmitter;

	private AudioSource source;
//	public Light flash;

	void Start()
	{
		source = GetComponent<AudioSource> ();
		ammo = capacity;
		SetAmmo ();
		//flash = GetComponent<Light>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && ammo > 0) 
		{
			source.PlayOneShot (shotSound,1F);
			Shoot ();
			//flash.enabled = !flash.enabled;
			//Flash ();
		}
		if (Input.GetKeyDown (KeyCode.R) && ammo < capacity) 
		{
			source.PlayOneShot (reloadSound,1F);
			Reload ();
		}
	}

	void Shoot()
	{
		//RaycastHit hit;
		//if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
		//	Debug.Log (hit.transform.name);
		//	if (hit.collider.tag == "Enemy") {
		//		Enemy enemy = hit.collider.GetComponent<Enemy> ();
		//		enemy.health -= 1;
		//	}
		//}

		GameObject temporaryBulletHandler;
		temporaryBulletHandler = Instantiate (bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

		temporaryBulletHandler.transform.Rotate (Vector3.left * 90);

		Rigidbody bulletClone;
		bulletClone = temporaryBulletHandler.GetComponent<Rigidbody> ();

		bulletClone.AddForce((transform.right*-1) * speed);

		Destroy (temporaryBulletHandler, 1.0f);

		ammo -= 1;
		SetAmmo ();
	}

	void Reload()
	{
		ammo = capacity;
		SetAmmo ();
	}

	void SetAmmo()
	{
		ammoDisplay.text = ammo.ToString () + "| " + capacity.ToString ();
	}

	//void Flash()
	//{
	//	Light.enabled = true;

//	}
			
	//	Ray ray = new Ray (barrel.position, transform.forward);

		//if(Physics.Raycast(ray, out hit, range))
		//{
		//	if (hit.collider.tag == "Enemy") 
		//	{
		//		Enemy enemy = hit.collider.GetComponent<Enemy> ();
		//		enemy.health -= 1;
		//	}
		//}
}
