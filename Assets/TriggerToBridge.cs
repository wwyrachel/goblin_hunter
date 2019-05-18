using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToBridge : MonoBehaviour {

    public HUD hud;

    public GameObject target;
    bool touch = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitF());
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            
            hud.OpenMessagePanel("");
            print("beforewait");
            WaitF();

            target.transform.position = new Vector3(660f, 0f, 172f);
            touch = true;



        }
    }

    void OnTriggerExit()
    {
        hud.CloseMessagePanel("");
        touch = false;


    }

    IEnumerator WaitF()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);
        print(Time.time);
    }
}
