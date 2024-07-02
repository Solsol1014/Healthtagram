using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class Trigger
{
    public string type;
    public string id;
    public string state;
    public string exercise;
    public Body body;
}

[Serializable]
public class Body
{
    public float bmi;
    public string skin;
    public float scale;
}

public class StartExercise : MonoBehaviour
{
    public GameObject canvas;
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(Exercise);
    }

    void Exercise()
    {
        canvas.SetActive(false);
        Trigger start = new Trigger();
        start.type = "Trigger";
        start.id = WebSocketClient.instance.clientID;
        start.state = "exercise";
        start.exercise = "running";

        Body body = new Body();
        body.bmi = Inventory.instance.bmiN;
        body.scale = Inventory.instance.scale;
        switch (Inventory.instance.bmi)
        {
            case "skinny":
                body.skin = Inventory.instance.characSkin.realCharacters[0].name;
                break;

            case "normal":
                body.skin = Inventory.instance.characSkin.realCharacters[1].name;
                break;

            case "fat":
                body.skin = Inventory.instance.characSkin.realCharacters[2].name;
                break;

            default:
                Debug.Log("BMI string error");
                break;
        }

        start.body = body;

        //Debug.Log(JsonUtility.ToJson(start));

        WebSocketClient.instance.SendMessage(JsonUtility.ToJson(start));
        Inventory.instance.isExercise = true;
    }
}
