using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class Emoji
{
    public string type;
    public string id;
    public string state;
}

public class EmojiSend : MonoBehaviour
{
    public Button cry;
    public Button hot;
    public Button green;
    public Button happy;
    public GameObject people;
    public Sprite crySprite;
    public Sprite hotSprite;
    public Sprite greenSprite;
    public Sprite happySprite;
    public Sprite thinkSprite;

    // Start is called before the first frame update
    void Start()
    {
        cry.onClick.AddListener(Cry);
        hot.onClick.AddListener(Hot);
        green.onClick.AddListener(Green);
        happy.onClick.AddListener(Happy);
    }

    private void Update()
    {
        if(WebSocketClient.instance.isEmoji)
        {
            WebSocketClient.instance.isEmoji = false;
            List<GameObject> destroyers = showEmoji();
            StartCoroutine(DestroyEmojis(destroyers));
        }
    }

    IEnumerator DestroyEmojis(List<GameObject> lists)
    {
        yield return new WaitForSeconds(3f);

        foreach (GameObject i in lists)
        {
            Destroy(i);
        }
    }

    List<GameObject> showEmoji()
    {
        GameObject person;
        PId[] components = people.GetComponentsInChildren<PId>();
        GameObject thinkRenderer = new GameObject("ThinkRenderer");
        GameObject emojiRenderer = new GameObject("EmojiRenderer");
        foreach (PId i in components)
        {
            if(i.pid == WebSocketClient.instance.emoji.id)
            {
                person = i.gameObject;
                thinkRenderer.transform.SetParent(person.transform);
                emojiRenderer.transform.SetParent(person.transform);
            }
        }

        thinkRenderer.AddComponent<SpriteRenderer>();
        emojiRenderer.AddComponent<SpriteRenderer>();

        SpriteRenderer thinkRender = thinkRenderer.GetComponent<SpriteRenderer>();
        SpriteRenderer emojiRender = emojiRenderer.GetComponent<SpriteRenderer>();

        thinkRender.sprite = thinkSprite;

        switch (WebSocketClient.instance.emoji.state)
        {
            case "cry":
                emojiRender.sprite = crySprite;
                break;

            case "hot":
                emojiRender.sprite = hotSprite;
                break;

            case "green":
                emojiRender.sprite = greenSprite;
                break;

            case "happy":
                emojiRender.sprite = happySprite;
                break;

            default:
                break;
        }

        thinkRender.transform.localPosition = new Vector3(0.5f, 1.6f, 0);
        emojiRender.transform.localPosition = new Vector3(0.5f, 1.7f, 0.1f);

        thinkRender.transform.localScale = new Vector3(0.13f, 0.13f, 0.13f);
        emojiRender.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);

        List<GameObject> destroyers = new List<GameObject>();
        destroyers.Add(thinkRenderer);
        destroyers.Add(emojiRenderer);

        return destroyers;
    }

    void Cry()
    {
        Emoji cry = new Emoji();
        cry.type = "Emoji";
        cry.id = WebSocketClient.instance.clientID;
        cry.state = "cry";
        WebSocketClient.instance.SendMessage(JsonUtility.ToJson(cry));
    }

    void Hot()
    {
        Emoji hot = new Emoji();
        hot.type = "Emoji";
        hot.id = WebSocketClient.instance.clientID;
        hot.state = "hot";
        WebSocketClient.instance.SendMessage(JsonUtility.ToJson(hot));
    }

    void Green()
    {
        Emoji green = new Emoji();
        green.type = "Emoji";
        green.id = WebSocketClient.instance.clientID;
        green.state = "green";
        WebSocketClient.instance.SendMessage(JsonUtility.ToJson(green));
    }

    void Happy()
    {
        Emoji happy = new Emoji();
        happy.type = "Emoji";
        happy.id = WebSocketClient.instance.clientID;
        happy.state = "happy";
        WebSocketClient.instance.SendMessage(JsonUtility.ToJson(happy));
    }
}
