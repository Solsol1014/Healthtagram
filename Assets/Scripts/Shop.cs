using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject characterPanel;
    public GameObject spacePanel;
    public GameObject gotoSpaceBtn;
    public GameObject gotoCharBtn;

    public void Awake()
    {
    }

    public void Show()
    {
        gameObject.SetActive(true);
        showPanel();
    }

    public void showPanel()
    {
        characterPanel.SetActive(true);
        spacePanel.SetActive(false);
        gotoSpaceBtn.SetActive(true);
        gotoCharBtn.SetActive(false);
    }

    public void Hide()
    {
       gameObject.SetActive(false);
    }
}
