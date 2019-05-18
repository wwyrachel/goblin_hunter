using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {

        transform.position = new Vector3(402f, -8f, 501f);
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(402+Mathf.PingPong(Time.time * speed, 250), -8f, 501 + Mathf.PingPong(Time.time * speed, 250));
		
	}
}
