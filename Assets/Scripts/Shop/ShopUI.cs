using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject database;
    public GameObject itemTemplate;
    SkinChange skinChange;
    SpaceChange spaceChange;
    
    void Start()
    {
        //Debug.Log("print");
        skinChange = FindObjectOfType<SkinChange>();
        spaceChange = FindObjectOfType<SpaceChange>();
        GridLayoutGroup gridGroup = gameObject.GetComponent<GridLayoutGroup>();
        ShopDatabase data = database.GetComponent<ShopDatabase>();
        List<Item> items = data.items;
        UpdateMoney.instance.Money();

        foreach (var item in items)
        {
            // Debug.Log("print");
            GameObject itemObj = Instantiate(itemTemplate, gameObject.transform);

            //itemObj.SetActive(true);

            Transform itemTrans = itemObj.transform;
            //itemTrans.GetChild(0).gameObject.SetActive(false);
            itemTrans.GetChild(0).GetComponent<Image>().sprite = item.icon;
            itemTrans.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.itemName;
            itemTrans.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + item.price;
            //itemTrans.GetChild(4).gameObject.SetActive(false);

            if (Inventory.instance.items.Contains(item))
            {
                itemTrans.GetChild(3).gameObject.SetActive(false);
                itemTrans.GetChild(4).GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (item.isCharacter)
                    {
                        Inventory.instance.characSkin = item;
                        skinChange.SetSkin();
                    }
                    else if (item.isSpace)
                    {
                        Inventory.instance.spaceSkin = item;
                        spaceChange.SetSkin();
                    }
                    else
                    {
                        Debug.Log("Item type error");
                    }
                });
            }
            else
            {
                itemTrans.GetChild(4).gameObject.SetActive(false);
                itemTrans.GetChild(3).GetComponent<Button>().onClick.AddListener(() =>
                {
                    bool buySuccess = ShopManage.Buy(item);
                    if (buySuccess)
                    {
                        itemTrans.GetChild(3).gameObject.SetActive(false);
                        itemTrans.GetChild(4).gameObject.SetActive(true);
                        UpdateMoney.instance.Money();
                    }
                });
                itemTrans.GetChild(4).GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (item.isCharacter)
                    {
                        Inventory.instance.characSkin = item;
                        skinChange.SetSkin();
                    }
                    else if (item.isSpace)
                    {
                        Inventory.instance.spaceSkin = item;
                        spaceChange.SetSkin();
                    }
                    else
                    {
                        Debug.Log("Item type error");
                    }
                });
            }
        }
    }

    public void Inven()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }

        ShopDatabase data = database.GetComponent<ShopDatabase>();

        foreach (Item item in Inventory.instance.items)
        {
            if (data.items.Contains(item))
            {
                GameObject itemObj = Instantiate(itemTemplate, gameObject.transform);
                itemObj.SetActive(true);
                itemObj.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;
                itemObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.itemName;
                itemObj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + item.price;
                itemObj.transform.GetChild(3).gameObject.SetActive(false);
                itemObj.transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (item.isCharacter)
                    {
                        Inventory.instance.characSkin = item;
                        skinChange.SetSkin();
                    }
                    else if (item.isSpace)
                    {
                        Inventory.instance.spaceSkin = item;
                        spaceChange.SetSkin();
                    }
                    else
                    {
                        Debug.Log("Item type error");
                    }
                });
            }
        }
    }

    public void All()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }

        Start();
    }
}
