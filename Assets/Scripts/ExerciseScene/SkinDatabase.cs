using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinDatabase : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<string> itemNames;

    void Start()
    {
        foreach (GameObject item in items)
        {
            itemNames.Add(item.name);
        }

        Debug.Log(itemNames);
    }

}
