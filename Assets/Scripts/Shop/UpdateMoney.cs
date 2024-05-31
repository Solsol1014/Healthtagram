using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateMoney : MonoBehaviour
{
    public static UpdateMoney instance;
    public TextMeshProUGUI money;
    private void Awake()
    {
        instance = this;
    }

    public void Money()
    {
        money.text = "$" + Inventory.instance.GetMoney();
    }
}
