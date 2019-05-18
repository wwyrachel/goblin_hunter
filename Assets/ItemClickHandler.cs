using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemClickHandler : MonoBehaviour {

    public Inventory _Inventory;

    public KeyCode _Key;

    private Button _button;

    void Awake() {

        _button = GetComponent<Button>();
    }
    void Update() {
        if (Input.GetKeyDown(_Key))
        {

            FadeToColour(_button.colors.pressedColor);
            _button.onClick.Invoke();
        }
        else if (Input.GetKeyUp(_Key)) {
            FadeToColour(_button.colors.normalColor);
        }

    }

    void FadeToColour(Color color) {

        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, _button.colors.fadeDuration, true, true);

    }


    private IInventoryItem Attacheditem
    {

        get
        {
            ItemDragHandler dragHandler = gameObject.transform.Find("ItemImage").GetComponent<ItemDragHandler>();

            return dragHandler.Item;

        }
    }

    public void OnItemClicked() {

        IInventoryItem item = Attacheditem;
        //ItemDragHandler dragHandler = gameObject.transform.Find("ItemImage").GetComponent<ItemDragHandler>();

        //IInventoryItem item = dragHandler.Item;

        if (item != null)
        {

            print(item.Name);

            _Inventory.UseItem(item);

            //item.OnUse();
        }
    }
    
}
