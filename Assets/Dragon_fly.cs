using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_fly : MonoBehaviour {
    public float speed;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(1184f, 116f, 900f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(1184 , 116f + Mathf.PingPong(Time.time * speed, 500), 900f);

    }
}
