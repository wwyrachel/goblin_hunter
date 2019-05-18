using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageHealth : MonoBehaviour {

    private int damageAmount = 10;

    void OnCollisionEnter(Collision collision) {
        print("collision");
        if (collision.gameObject.tag == "enemy" || collision.gameObject.tag == "goblin") {
            
            health _health = collision.gameObject.GetComponent<health>();
            _health.takeDamage(damageAmount);
        }

    }
}
