using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gun : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	public float speed;

	public Camera fpsCam;
	public GameObject bullet;
	public GameObject bulletEmitter;
//	public Light flash;

//	void Start()
//	{
		//flash = GetComponent<Light>();
//	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) 
		{
			Shoot ();
			//flash.enabled = !flash.enabled;
			//Flash ();
		}
	}

	void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
			Debug.Log (hit.transform.name);
			if (hit.collider.tag == "Enemy") {
				//Enemy enemy = hit.collider.GetComponent<Enemy> ();
				//enemy.health -= 1;
			}
		}

		GameObject temporaryBulletHandler;
		temporaryBulletHandler = Instantiate (bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

        //Performs rotation on bullet handler
		temporaryBulletHandler.transform.Rotate (Vector3.left * 90);

		Rigidbody bulletClone;
		bulletClone = temporaryBulletHandler.GetComponent<Rigidbody> ();

		bulletClone.AddForce(transform.right * speed * -1);

		Destroy (temporaryBulletHandler, 1.0f);
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
