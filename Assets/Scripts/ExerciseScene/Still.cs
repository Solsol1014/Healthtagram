using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Still : MonoBehaviour
{
    public static Still instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
