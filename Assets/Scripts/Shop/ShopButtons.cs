using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public Button characterBtn;
    public Button spaceBtn;
    private GameObject characterPanel;
    private GameObject spacePanel;

    // Start is called before the first frame update
    void Start()
    {
        characterPanel = gameObject.transform.GetChild(0).gameObject;
        spacePanel = gameObject.transform.GetChild(1).gameObject;
        characterBtn.onClick.AddListener(Character);
        spaceBtn.onClick.AddListener(Space);
    }

    private void Character()
    {
        characterPanel.SetActive(true);
        spacePanel.SetActive(false);
    }

    private void Space()
    {
        characterPanel.SetActive(false);
        spacePanel.SetActive(true);
    }
}
