using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float health;
    private float maxHealth;

    public float walkSpeed;
    public float runSpeed;
    private float speed;

    public float jumpSpeed;
    public float gravity = 10;

    public CharacterController cc;

    private Vector3 movement;

    public Image healthBar;

    // Use this for initialization
    void Start () {
        cc.GetComponent<CharacterController>();
        speed = walkSpeed;
        maxHealth = health;
        setHealthBar();
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
                speed = runSpeed;
            else
                speed = walkSpeed;
                
        }

        movement.y -= gravity * Time.deltaTime;

        cc.Move(movement * speed * Time.deltaTime);
    }

    public void takeDamage()
    {
        health--;
        setHealthBar();

		if (health <= 0.0) {
			SceneManager.LoadScene (3); //quit scene
		}
    }

    void setHealthBar()
    {
        healthBar.fillAmount = health / maxHealth;
    }
}
