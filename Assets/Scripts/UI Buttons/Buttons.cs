using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public class Finish
{
    public string type;
    public string id;
}

public class Buttons : MonoBehaviour
{
    public void Exercise()
    {
        SceneManager.LoadScene("Exercise");
    }

    public void MainScene()
    {
        SendFinish();
        SceneManager.LoadScene("MainScene");
        Inventory.instance.isExercise = false;
    }

    public void SNS()
    {
        Inventory.instance.isExercise = false;
        SendFinish();
        SceneManager.LoadScene("SNS");
    }

    private void SendFinish()
    {
        Finish finish = new Finish();
        finish.type = "Finish";
        finish.id = WebSocketClient.instance.clientID;
        Debug.Log(JsonUtility.ToJson(finish));
        WebSocketClient.instance.SendMessage(JsonUtility.ToJson(finish));
    }
}
