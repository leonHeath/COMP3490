using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float speed;
    public float ammo;
    public float capacity = 6f;
    public Text ammoDisplay;

    private AudioSource source;
    public AudioClip shotSound;
    public AudioClip reloadSound;

    public Camera fpsCam;
	public GameObject bullet;
	public GameObject bulletEmitter;

	void Start()
    {
        source = GetComponent<AudioSource>();
        ammo = capacity;
        SetAmmo();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            source.PlayOneShot(shotSound, 1F);
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && ammo < capacity)
        {
            source.PlayOneShot(reloadSound, 1F);
            Reload();
        }
    }

	void Shoot()
	{
        GameObject temporaryBulletHandler;
        temporaryBulletHandler = Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;

        temporaryBulletHandler.transform.Rotate(Vector3.left * 90);

        Rigidbody bulletClone;
        bulletClone = temporaryBulletHandler.GetComponent<Rigidbody>();

        bulletClone.AddForce((transform.right * -1) * speed);

        Destroy(temporaryBulletHandler, 1.0f);

        ammo -= 1;
        SetAmmo();
    }

    void Reload()
    {
        ammo = capacity;
        SetAmmo();
    }

    void SetAmmo()
    {
        ammoDisplay.text = ammo.ToString() + "| " + capacity.ToString();
    }
}
