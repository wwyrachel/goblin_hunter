using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin_test : MonoBehaviour {

    public Transform player;
    static Animator animate;

    public int Health;

    // Use this for initialization
    void Start()
    {

        //animate = GetComponent<Animator>();
    }


    void OnCollisionEnter(Collision other)
    {
        print("ys" + other.gameObject.name);


    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 20)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            //animate.SetBool("idle", false);


            if (direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 0.05f);
                //animate.SetBool("attacking", false);
                //animate.SetBool("idle", false);
                //animate.SetBool("walking", true);


            }
            else
            {
                //animate.SetBool("attacking", true);

                //animate.SetBool("walking", false);



            }



        }
        else
        {
            //animate.SetBool("idle", true);
            //animate.SetBool("walking", false);
            //animate.SetBool("attacking", false);
            //animate.SetBool("running", false);




        }


    }

}
