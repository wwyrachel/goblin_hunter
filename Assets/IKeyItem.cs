using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKeyItem {

    string Name { get; }

    Sprite Image { get; }

    void OnPickup();
}

    
    public class KeyEventArgs : EventArgs
    {

        public KeyEventArgs(IKeyItem item)
        {
            Item = item;

        }

        public IKeyItem Item;


    }

