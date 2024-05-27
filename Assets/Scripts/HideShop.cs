using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShop : MonoBehaviour
{
    private Animator m_animator;
    private GameObject m_gameobj;
    public GameObject showShopButton;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public void aniNextScene()
    {
        showShopButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
