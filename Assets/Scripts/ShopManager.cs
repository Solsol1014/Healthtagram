using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopManager : MonoBehaviour {
    public List<Item> itemsAvailable = new List<Item>{
        new Item("Image1", 100, null),
        new Item("Image2", 200, null),
        new Item("Image3", 300, null),
        new Item("Image4", 400, null),
        new Item("Image5", 100, null),
        new Item("Image6", 200, null),
        new Item("Image7", 300, null),
        new Item("Image8", 400, null),
        new Item("Image9", 500, null)
    };
    public GameObject characterPanel;
    public GameObject spacePanel;
    public GameObject shopPanel;
    public GameObject itemTemplate;
    public TextMeshProUGUI moneyText;
    private int playerMoney = 10000;
    public GameObject gotoSpaceBtn;
    public GameObject gotoCharBtn;

    public void ShowCharacterPanel() {
        spacePanel.SetActive(false);
        characterPanel.SetActive(true);
        gotoSpaceBtn.SetActive(true);
        gotoCharBtn.SetActive(false);
    }

    public void ShowSpacePanel() {
        characterPanel.SetActive(false);
        spacePanel.SetActive(true);
        gotoSpaceBtn.SetActive(false);
        gotoCharBtn.SetActive(true);
    }

    void Start() {
        characterPanel.SetActive(true);
        spacePanel.SetActive(false);
        shopPanel.SetActive(false);
        gotoSpaceBtn.SetActive(true);
        gotoCharBtn.SetActive(false);

        GridLayoutGroup gridLayoutGroup = shopPanel.AddComponent<GridLayoutGroup>();
        gridLayoutGroup.padding = new RectOffset(130, 200, 10, 10); 
        gridLayoutGroup.cellSize = new Vector2(220, 100);  
        gridLayoutGroup.spacing = new Vector2(50, 50);     
        gridLayoutGroup.startCorner = GridLayoutGroup.Corner.UpperLeft;  
        gridLayoutGroup.startAxis = GridLayoutGroup.Axis.Horizontal; 
        gridLayoutGroup.childAlignment = TextAnchor.UpperLeft;  
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = 3;  

        PopulateShop();
        UpdateMoneyText();
    }

    public void PopulateShop() {
        foreach (var item in itemsAvailable) {
            GameObject itemObj = Instantiate(itemTemplate, shopPanel.transform);
            itemObj.SetActive(true);
            itemObj.transform.GetChild(0).GetComponent<Image>().sprite = item.icon;
            itemObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.itemName;
            itemObj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "$" + item.price;
            itemObj.transform.GetChild(3).GetComponent<Button>().onClick.AddListener(() => BuyItem(item));
        }
    }

    public void BuyItem(Item item) {
        if (playerMoney >= item.price) {
            playerMoney -= item.price;
            UpdateMoneyText();
            Debug.Log(item.itemName + " purchased!");
        } else {
            Debug.Log("Not enough money.");
        }
    }

    void UpdateMoneyText() {
        moneyText.text = "$" + playerMoney;
    }
}