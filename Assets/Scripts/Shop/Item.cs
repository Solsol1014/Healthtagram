using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    public string itemName;
    public int price;
    public Sprite icon;
    public bool isCharacter;
    public bool isSpace;
    public GameObject realSpace;
    public List<GameObject> realCharacters = new List<GameObject>(3);

    public Item(string name, int price, Sprite icon) {
        this.itemName = name;
        this.price = price;
        this.icon = icon;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Item other = (Item)obj;

        return itemName == other.itemName;
    }

    public override int GetHashCode()
    {
        return itemName.GetHashCode();
    }
}
