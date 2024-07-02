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

    public static bool Buy(Item item)
    {
        if (!Inventory.instance.items.Contains(item))
        {
            if (item.price < Inventory.instance.GetMoney())
            {
                Inventory.instance.EditMoney(-item.price);
                Inventory.instance.items.Add(item);
                return true;
            }
            else
            {
                Debug.Log("No money");
                return false;
            }
        }
        else
        {
            Debug.Log("Already Exist");
            return false;
        }
    }
}
