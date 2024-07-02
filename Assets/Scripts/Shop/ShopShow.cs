using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopShow : MonoBehaviour
{
    public Button showShopButton;
    public Button hideShopButton;
    public GameObject setShowButton;
    public GameObject Shop;
    public GameObject characterPanel;
    public GameObject SpacePanel;

    public Animator shopAni;
    public Animator cameraAni;

    private bool isShopOpen = false;

    // Start is called before the first frame update
    void Awake()
    {
        showShopButton.onClick.AddListener(ToggleShop);
        hideShopButton.onClick.AddListener(ToggleShop);
        setShowButton.SetActive(true);
        Shop.SetActive(false);
    }

    private void ToggleShop()
    {
        isShopOpen = !isShopOpen;

        if (isShopOpen)
        {
            ShowShop();
            setShowButton.SetActive(false);
            shopAni.SetBool("ButtonPush", true);
            cameraAni.SetBool("ButtonPush", true);
        }
        else
        {
            shopAni.SetBool("ButtonPush", false);
            cameraAni.SetBool("ButtonPush", false);
        }
    }

    private void ShowShop()
    {
        Shop.SetActive(true);
        SpacePanel.SetActive(false);
        characterPanel.SetActive(true);
    }
}
