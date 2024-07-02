using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;

[Serializable]
public class Id
{
    public string type;
    public string id;
}

[Serializable]
public class LogMessage
{
    public string type;
    public string id;
    public string message;
}

[Serializable]
public class Puts
{
    public string type;
    public List<Put> infos;
}

[Serializable]
public class Put
{
    public string id;
    public string exercise;
    public Body body;
}

[Serializable]
public class Pop
{
    public string type;
    public string id;
}


public class WebSocketClient : MonoBehaviour
{
    public static WebSocketClient instance { get; private set; }
    WebSocket ws;
    public string clientID;
    public bool isput;
    public bool ispop;
    public string popId;
    public List<Put> putInfos;
    public bool isEmoji;
    public Emoji emoji;

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

    void Start()
    {
        ws = new WebSocket("ws://13.60.33.46:8080");
        isput = false;
        ispop = false;
        isEmoji = false;

        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("Connected");
        };

        ws.OnMessage += (sender, e) =>
        {
            string messageType = JsonUtility.FromJson<Id>(e.Data).type;
            switch (messageType)
            {
                case "ID":
                    clientID = JsonUtility.FromJson<Id>(e.Data).id;
                    Debug.Log("Got ID : " + clientID);
                    LogMessage log = new LogMessage();
                    log.type = "LogMessage";
                    log.id = clientID;
                    log.message = "Got ID : " + clientID;
                    SendMessage(JsonUtility.ToJson(log));
                    break;

                case "Put":
                    //Debug.Log(e.Data);
                    Puts puts = JsonUtility.FromJson<Puts>(e.Data);
                    if (Inventory.instance.isExercise)
                    {
                        Debug.Log("Got put");
                        putInfos = puts.infos;
                        isput = true;
                    }
                    break;


                case "Pop":
                    Pop pop = JsonUtility.FromJson<Pop>(e.Data);
                    Debug.Log("PoP");
                    if (Inventory.instance.isExercise)
                    {
                        popId = pop.id;
                        ispop = true;
                    }
                    break;

                case "Emoji":
                    emoji = JsonUtility.FromJson<Emoji>(e.Data);
                    Debug.Log("Emoji");
                    isEmoji = true;
                    break;

                default:
                    Debug.Log("Got message from server : " + e.Data);
                    break;
            }
        };

        ws.Connect();
    }

    void OnApplicationQuit()
    {
        ws.Close();
    }

    public void SendMessage(string message)
    {
        if (ws.ReadyState == WebSocketState.Open)
        {
            ws.Send(message);
        }
    }
}
