using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    public float jumpSpeed;

    public float gravity = 10;

    public CharacterController cc;

    private Vector3 movement;

    private int run;

    //public Camera cam;

    // Use this for initialization
    void Start () {
        cc.GetComponent<CharacterController>();
        run = 1;
    }
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (cc.isGrounded)
        {

            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);



            movement = transform.TransformDirection(movement);



            if (Input.GetButton("Jump"))
                movement.y = jumpSpeed;

            if (Input.GetButton("Run"))
                run = 2;
            else
                run = 1;
                
        }

        movement.y -= gravity * Time.deltaTime;

        cc.Move(movement * speed * run * Time.deltaTime);
        //rb.velocity = movement * speed;
    }
}
