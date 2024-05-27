using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManage : MonoBehaviour
{
    public static ShopManage instance;
    private void Awake()
    {
        instance = this;
    }

    public static void buy(Item item)
    {
        if (!Inventory.instance.items.Contains(item))
        {
            if (item.price < Inventory.instance.money)
            {
                Inventory.instance.money -= item.price;
                Inventory.instance.items.Add(item);
            }
            else
                Debug.Log("No money");
        }
        else
            Debug.Log("Already Exist");
    }
}
