using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject database;
    public GameObject itemTemplate;
    
    void Start()
    {
        //Debug.Log("print");
        GridLayoutGroup gridGroup = gameObject.GetComponent<GridLayoutGroup>();
        ShopDatabase data = database.GetComponent<ShopDatabase>();
        List<Item> items = data.items;
        UpdateMoney.instance.Money();

        foreach (var item in items)
        {
            // Debug.Log("print");
            GameObject itemObj = Instantiate(itemTemplate, gameObject.transform);
            itemObj.SetActive(true);
            itemObj.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;
            itemObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.itemName;
            itemObj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + item.price;
            itemObj.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => { ShopManage.buy(item);
                UpdateMoney.instance.Money();
            });
        }
    }
}
