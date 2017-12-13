using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    public Animator anim;

    // Use this for initialization
    void Start () {
        anim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Speed", 3);
	}

    void OnAnimatorMove()
    {
        Vector3 newPosition = transform.position;
        newPosition.z -= anim.GetFloat("Speed") * Time.deltaTime;
        transform.position = newPosition;
       
    }

}
