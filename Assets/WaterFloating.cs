using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterFloating : MonoBehaviour {

    public float speed;





    // Use this for initialization
    void Start () {

        
        transform.position = new Vector3(960f, 47f, 860f);

    }

    void Update()
    {
        transform.position = new Vector3(960f, 47f + Mathf.PingPong(Time.time * speed, 2), 860f);

    }

}
