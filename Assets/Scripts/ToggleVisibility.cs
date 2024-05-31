using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    public GameObject targetObject;

    public void HideObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    public void ShowObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }
}
