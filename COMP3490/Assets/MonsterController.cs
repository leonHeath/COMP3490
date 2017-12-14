using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    //New
    public int health;
    public AudioClip hitSound;
    public AudioClip dieSound;
    private AudioSource source;

    public Animator anim;

    public int monsterSpeed;

    public Transform Player;

    private Transform monsterTransform;

    //These are set by child scripts
    public bool followPlayer;
    public bool inRange;
    public bool monsterDead;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

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
        if(health <= 0)
        {
            monsterDead = true;
        }
        if (monsterDead)
        {
            GetComponent<CharacterController>().enabled = false;
            anim.SetBool("Dead", true); 
        }
        if (inRange)
        {
            anim.SetBool("HitPlayer", true);
            if (!monsterDead)
            {
                damagePlayer();
            }
            anim.SetFloat("Speed", 0);
        }
        else
        {
            anim.SetBool("HitPlayer", false);
        }

	}

    void damagePlayer()
    {
        Player.GetComponent<PlayerController>().takeDamage();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Monster SHot");
            source.PlayOneShot(hitSound, 1f);
            health -= 1;
        }
    }

    void OnAnimatorMove()
    {
        Vector3 newPosition = monsterTransform.position;
        newPosition += monsterTransform.forward * anim.GetFloat("Speed") * Time.deltaTime;
        transform.position = newPosition;
    }
}
