using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bullet : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Enemy")) 
		{
            //other.gameObject.SetActive (false);
            //Physics.IgnoreCollision(this.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);
            if (!other.gameObject.GetComponent<Collider>().isTrigger)
            {
                other.gameObject.GetComponent<MonsterController>().monsterDead = true;
            }
            //gameObject.SetActive (false);

        }
	}
}
