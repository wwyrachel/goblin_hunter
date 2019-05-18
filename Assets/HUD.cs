using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    public Inventory Inventory;
    public Key Key;

    public GameObject Message;
	// Use this for initialization
	void Start () {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
        Key.ItemAdded += KeyScript_ItemAdded;
	}

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e) {
        print("add");
        Transform InventoryPanel = transform.Find("InventoryPanel");

        

            print("panel");
        foreach (Transform slot in InventoryPanel)
        {
            print("slot");

            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            //string namee = slot.GetChild(0).GetChild(0).GetComponent<Image>().sprite.name;
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            //print(image.color);
            //print(namee);
            
            if (image.sprite== null)
            {
                print("image");
                image.enabled = true;
                image.sprite = e.Item.Image;

                itemDragHandler.Item = e.Item;

                break;
            }
        }

    }

    public void Inventory_ItemRemoved(object sender, InventoryEventArgs e) {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        
        foreach (Transform slot in inventoryPanel) {
            
            Transform imageTransform = slot.GetChild(0).GetChild(0);

            Image image = imageTransform.GetComponent<Image>();

            print("drag found");

            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();


            print("drag foun1");


            if (itemDragHandler.Item == e.Item) 
            {
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;
                break;

            }

            /*
            if (itemDragHandler.Item.Equals(e.Item)) {
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;
                break;
             
            }
            */

        }


    }

    private void KeyScript_ItemAdded(object sender, KeyEventArgs e)
    {
        //print("add");
        Transform KeyPanel = transform.Find("KeyCollected");



        print("panel");
        foreach (Transform slot in KeyPanel)
        {
            print("slot");

            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            //string namee = slot.GetChild(0).GetChild(0).GetComponent<Image>().sprite.name;
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            //print(image.color);
            //print(namee);

            if (image.sprite == null)
            {
                print("image");
                image.enabled = true;
                image.sprite = e.Item.Image;

              

                break;
            }
        }

    }

    public void OpenMessagePanel(string text)
    {
        Message.SetActive(true);
    }

    public void CloseMessagePanel(string text)
    {
        Message.SetActive(false);
    }



}
