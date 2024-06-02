using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class WebSocketClient : MonoBehaviour
{
    public static WebSocketClient instance { get; private set; }
    WebSocket ws;

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
        ws = new WebSocket("ws://localhost:8080");

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Got message from server : " + e.Data);
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
