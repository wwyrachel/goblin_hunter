using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin_npc_new : MonoBehaviour {
    public Transform player;
   
    
    // Use this for initialization
    void Start()
    {

        //animate = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 20)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        }
    }
           


          
    
}
