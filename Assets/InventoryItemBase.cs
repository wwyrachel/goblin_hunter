using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour, IInventoryItem {
    public Sprite _Image;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public  virtual string Name
    {
        get
        {
            return "_base item_";
        }
    }

    

    

    public virtual void OnDrop()
    {
        print("rayyy");
        RaycastHit hit = new RaycastHit();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        print("drop1");

        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
           gameObject.transform.eulerAngles = DropRotation;

        }
    }

    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnUse()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        transform.localPosition = PickPosition;
        transform.localEulerAngles = PickRotation;
    }

    public Vector3 DropRotation;

    public Vector3 PickPosition;

    public Vector3 PickRotation;

    //public bool UseItemAfterPickup = false;
}
