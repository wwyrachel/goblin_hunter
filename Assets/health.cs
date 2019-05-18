using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {
    private int minHealth = 1;
    public int maxHealth;

    void OnTriggerEnter(Collider other)
    {
        print("collide out"+ other.gameObject.name);
        if (other.gameObject.tag == "Player") {
            print("collide in");
        }
            //Destroy(gameObject);
    }

    // Use this for initialization
    public void takeDamage(int amount) {
        if (maxHealth < minHealth)
        {
            Destroy(this.gameObject);
        }
        else {
            maxHealth -= amount;
            print(maxHealth);
        }
    }
}
