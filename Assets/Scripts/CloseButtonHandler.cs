using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CloseButtonHandler : MonoBehaviour
{
    public Shop popupWindow;
    public GameObject characterPanel;
    public GameObject spacePanel;
    public GameObject gotoSpaceBtn;
    public GameObject gotoCharBtn;


   public void OnButtonClick()
   {
         characterPanel.SetActive(false);
         spacePanel.SetActive(false);
         gotoSpaceBtn.SetActive(false);
         gotoCharBtn.SetActive(false);
      popupWindow.Hide();

   }
      
}
