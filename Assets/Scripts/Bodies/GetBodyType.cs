using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBodyType : MonoBehaviour
{
    public GameObject parentObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateSkin()
    {
        foreach (Transform child in parentObject.transform)
        {
            if (child.gameObject.activeSelf)
            {
                Inventory.instance.skin = child.gameObject;
                break;
            }
        }

        Debug.Log(Inventory.instance.skin.name);
    }
}
