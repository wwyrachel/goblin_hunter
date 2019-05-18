using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin2_collide : MonoBehaviour {

    public int health;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        print("col");
        if (col.gameObject.tag == "Player")
        {
            health = health - 10;
            print(health);

            if (health <= 0) {
                Destroy(gameObject);
            }
            
        }
    }
}
