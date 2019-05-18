using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube2 : MonoBehaviour {
    public float speed;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(544f, -3f, 173f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(544 + Mathf.PingPong(Time.time * speed, 76), -3f, 173);

    }
}
