using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour {

    public float speed = 2f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float rotateSpeed = 3.0f;

    private Vector3 moveDirection = Vector3.zero;

    static Animator animate;

    private CharacterController controller;


    // Use this for initialization
    void Start () {
        speed = 2.0f;
        animate = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        // let the gameObject fall down
        gameObject.transform.position = new Vector3(396, 0, 60);

    }
	
	// Update is called once per frame
	void Update () {

        // CharacterController controller = GetComponent<CharacterController>();
        //Vector3 moveValues = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //controller.Move(moveValues);


        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (moveDirection.x == 0 && moveDirection.y == 0)
            {
                animate.SetBool("jumping", false);
                animate.SetBool("idle", true);
                animate.SetBool("walking", false);
            }
            else
            {

                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                    animate.SetBool("jumping", true);
                    animate.SetBool("idle", false);
                    animate.SetBool("walking", false);
                }

                moveDirection.y -= gravity * Time.deltaTime;
                controller.Move(moveDirection * Time.deltaTime);

                animate.SetBool("jumping", false);
                animate.SetBool("idle", false);
                animate.SetBool("walking", true);


                transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

            }
        }
        
    }
}
