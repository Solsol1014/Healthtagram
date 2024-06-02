using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmojiSend : MonoBehaviour
{
    public Button cry;
    public Button hot;
    public Button green;
    public Button happy;

    // Start is called before the first frame update
    void Start()
    {
        cry.onClick.AddListener(Cry);
        hot.onClick.AddListener(Hot);
        green.onClick.AddListener(Green);
        happy.onClick.AddListener(Happy);
    }

    void Cry()
    {
        WebSocketClient.instance.SendMessage("Cry");
    }

    void Hot()
    {
        WebSocketClient.instance.SendMessage("Hot");
    }

    void Green()
    {
        WebSocketClient.instance.SendMessage("Green");
    }

    void Happy()
    {
        WebSocketClient.instance.SendMessage("Happy");
    }
}
