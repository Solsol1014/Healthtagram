using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private void Awake()
    {
        instance = this;
    }

    public int money;
    public List<Item> items = new List<Item>();
}
