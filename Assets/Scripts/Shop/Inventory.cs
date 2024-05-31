using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateSkin();
    }

    public void UpdateSkin()
    {
        foreach (Transform child in parentObject.transform)
        {
            if (child.gameObject.activeSelf)
            {
                skin = child.gameObject;
                break;
            }
        }

        Debug.Log(skin.name);
    }

    public int GetMoney()
    {
        return money;
    }

    public void EditMoney(int amount)
    {
        money += amount;
    }

    int money = 10000;
    public List<Item> items = new List<Item>();
    GameObject skin;
    public GameObject parentObject;
}
