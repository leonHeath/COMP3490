using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    public Animator anim;

    public int monsterSpeed;

    public Transform Player;

    private Transform monsterTransform;

    //These are set by child scripts
    public bool followPlayer;
    public bool inRange;
    public bool monsterDead;

    // Use this for initialization
    void Start () {
        anim.GetComponent<Animator>();
        monsterTransform = transform;
        Player = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (followPlayer && !monsterDead)
        {
            //Look at player leaving x and z values stationary
            transform.LookAt(Player);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            anim.SetFloat("Speed", monsterSpeed);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
        if (monsterDead)
        {
            anim.SetBool("Dead", true);
        }
        if (inRange)
        {
            anim.SetBool("HitPlayer", true);
            anim.SetFloat("Speed", 0);
        }
        else
        {
            anim.SetBool("HitPlayer", false);
        }

	}

    void OnAnimatorMove()
    {
        Vector3 newPosition = monsterTransform.position;
        newPosition += monsterTransform.forward * anim.GetFloat("Speed") * Time.deltaTime;
        transform.position = newPosition;
    }
}
