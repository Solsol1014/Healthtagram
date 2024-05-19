using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShop : MonoBehaviour
{
    private Animator m_animator;
    private GameObject m_gameobj;
    public GameObject showShopButton;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_gameobj = GetComponent<GameObject>();
    }

    public void aniNextScene()
    {
        showShopButton.SetActive(true);
        m_gameobj.SetActive(false);
    }
}
