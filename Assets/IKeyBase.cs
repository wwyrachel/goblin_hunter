using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKeyBase : MonoBehaviour, IKeyItem {
    public Sprite _Image;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public virtual string Name {
        get {
            return "Key";
        }
    }

    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

}
