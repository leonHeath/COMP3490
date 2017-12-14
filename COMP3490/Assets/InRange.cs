using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRange : MonoBehaviour {

    //private bool attackPlayer;

    public Animator anim;

    // Use this for initialization
    void Start () {
        //anim.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            Debug.Log("Player in range");
            this.transform.parent.GetComponent<MonsterController>().followPlayer = false;
            this.transform.parent.GetComponent<MonsterController>().inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            Debug.Log("Player out of range");
            this.transform.parent.GetComponent<MonsterController>().followPlayer = true;
            this.transform.parent.GetComponent<MonsterController>().inRange = false;
        }
    }
}
