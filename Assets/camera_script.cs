using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_script : MonoBehaviour {
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    bool start = false;

    private void Start() {
        //delete later
        //start = true;
        
    }

    private void caminit()
    {
        //print("st");
        transform.position = new Vector3(352f, 185f, -263f);

    }

    public void enable() {
        start = true;
        print("start true");
    }

    private void Update()
    {
       if (start == true)
        {
            Refresh();
        }
    }

    private void Enable(){
        this.enabled = true;
        }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}
