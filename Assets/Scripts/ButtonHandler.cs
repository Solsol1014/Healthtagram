using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public Shop popupWindow;

   public void OnButtonClick()
   {
        popupWindow.Show();
   }

}
