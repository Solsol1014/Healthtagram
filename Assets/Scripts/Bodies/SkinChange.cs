using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChange : MonoBehaviour
{
    public GameObject placeModel;
    public void SetSkin()
    {
        int i = 0;
        switch (Inventory.instance.bmi)
        {
            case "skinny":
                i = 0;
                break;

            case "normal":
                i = 1;
                break;

            case "fat":
                i = 2;
                break;

            default:
                Debug.Log("set skin error");
                break;
        }
        Instantiate(Inventory.instance.characSkin.realCharacters[i], placeModel.transform);

        if(placeModel.transform.childCount>1)
        {
            Destroy(placeModel.transform.GetChild(0).gameObject);
        }
    }
}
