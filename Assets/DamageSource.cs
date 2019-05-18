﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{

    private bool _isCausingDamage = false;

    public float DamageRepeatRate = 0.1f;

    public int DamageAmount = 1;

    public bool Repeating = true;


    private void OnTriggerEnter(Collider other)
    {

        _isCausingDamage = true;
        player_test player = other.gameObject.GetComponent<player_test>();

        if (player != null) {

            if (Repeating)
            {

                StartCoroutine(TakeDamage(player, DamageRepeatRate));
            }
            else {

                player.TakeDamage(DamageAmount);
            }
        }


    }

    IEnumerator TakeDamage(player_test player, float repeatRate) {

        while (_isCausingDamage) {
            player.TakeDamage(DamageAmount);
            TakeDamage(player, repeatRate);
            yield return new WaitForSeconds(repeatRate);

        }
    }

    private void OnTriggerExit(Collider other) {
        //print("exit");
        player_test player = other.gameObject.GetComponent<player_test>();

        if (player != null) {

            _isCausingDamage = false;
        }

    }

	   
    

    
}
