using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceChange : MonoBehaviour
{
    public GameObject placeModel;
    public void SetSkin()
    {
        if (Inventory.instance.spaceSkin.realSpace != null)
        {
            Instantiate(Inventory.instance.spaceSkin.realSpace, placeModel.transform);
        }

        if (placeModel.transform.childCount > 1)
        {
            Destroy(placeModel.transform.GetChild(0).gameObject);
        }
    }
}
