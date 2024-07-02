using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public Button characterBtn;
    public Button spaceBtn;
    public Toggle inven;
    private GameObject characterPanel;
    private GameObject spacePanel;
    private bool charac;
    private bool space = false;

    // Start is called before the first frame update
    void Start()
    {
        inven.isOn = false;
        characterPanel = gameObject.transform.GetChild(0).gameObject;
        spacePanel = gameObject.transform.GetChild(1).gameObject;
        characterBtn.onClick.AddListener(Character);
        spaceBtn.onClick.AddListener(Space);
        inven.onValueChanged.AddListener(Inven);
    }

    private void Character()
    {
        characterPanel.SetActive(true);
        spacePanel.SetActive(false);
        OnOff();
        
    }

    private void Space()
    {
        characterPanel.SetActive(false);
        spacePanel.SetActive(true);
        if (space)
        {
            OnOff();
        }
        else
        {
            space = !space;
        }
    }

    private void Inven(bool isOn)
    {
        if (isOn)
        {
            if(characterPanel.activeSelf)
            {
                ShopUI ui = characterPanel.GetComponent<ShopUI>();
                ui.Inven();
            }
            else
            {
                ShopUI ui = spacePanel.GetComponent<ShopUI>();
                ui.Inven();
            }
        }
        else
        {
            if (characterPanel.activeSelf)
            {
                ShopUI ui = characterPanel.GetComponent<ShopUI>();
                ui.All();
            }
            else
            {
                ShopUI ui = spacePanel.GetComponent<ShopUI>();
                ui.All();
            }
        }
    }

    private void OnOff()
    {
        if(inven.isOn)
        {
            inven.isOn = false;
            inven.isOn = true;
        }
        else
        {
            inven.isOn = true;
            inven.isOn = false;
        }
    }
}
