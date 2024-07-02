using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private List<string> itemname;

    public bool isCharacter;
    public bool isSpace;

    private void Start()
    {
        foreach (var item in items)
        {
            item.isCharacter = isCharacter;
            item.isSpace = isSpace;
        }
    }

    public int Price(string name)
    {
        int index = itemname.IndexOf(name);

        int price = items[index].price;

        return price;
    }
}
