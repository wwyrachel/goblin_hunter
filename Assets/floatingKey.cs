using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingKey : MonoBehaviour {

    public float speed =2;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        //transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        
        posOffset.y = posOffset.y+ Mathf.PingPong(Time.time * speed, 10);

        //transform.position = tempPos;
    }
}
