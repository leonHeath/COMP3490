using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    public Animator anim;

    private bool followPlayer;

    // Use this for initialization
    void Start () {
        anim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (followPlayer)
        {
            anim.SetFloat("Speed", 3);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == Player.tag)
            followPlayer = true;

    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().tag == Player.tag)
            followPlayer = false;
    }

    void OnAnimatorMove()
    {
        Vector3 newPosition = transform.position;
        newPosition.z -= anim.GetFloat("Speed") * Time.deltaTime;
        transform.position = newPosition;
       
    }

}
