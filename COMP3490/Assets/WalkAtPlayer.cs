using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAtPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            this.transform.parent.GetComponent<MonsterController>().followPlayer = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            this.transform.parent.GetComponent<MonsterController>().followPlayer = false;
        }
    }
}
