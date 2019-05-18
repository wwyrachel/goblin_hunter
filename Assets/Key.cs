using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    private const int SLOTS = 7;

    private List<IKeyItem> kItems = new List<IKeyItem>();

    public event EventHandler<KeyEventArgs> ItemAdded;

    public void AddItem(IKeyItem item) {
        if (kItems.Count < SLOTS) {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if (collider.enabled) {
                collider.enabled = false;
                kItems.Add(item);

                item.OnPickup();

                if (ItemAdded != null) {
                    ItemAdded(this, new KeyEventArgs(item));
                }
            }
        }

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
