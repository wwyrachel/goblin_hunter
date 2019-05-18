using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class life_system : MonoBehaviour {
    public Transform player;
    

    public int DamageAmount = 20;


    // Use this for initialization
    void Start () {
		
	}

    

    // Update is called once per frame
    void Update () {

        //print(player.position);
        if (player.position.y < -30) {
            //print("fall");
            player.position = new Vector3(player.position.x - 30f, 0.4f, player.position.z - 30f);
            player_test player1 = player.GetComponent<player_test>();
            player1.TakeDamage(DamageAmount);
        }
		
	}
}
