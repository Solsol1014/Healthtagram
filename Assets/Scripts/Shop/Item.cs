using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    public string itemName;
    public int price;
    public Sprite icon;

    public Item(string name, int price, Sprite icon) {
        this.itemName = name;
        this.price = price;
        this.icon = icon;
    }
}
