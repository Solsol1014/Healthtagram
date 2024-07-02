using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutModel : MonoBehaviour
{
    public GameObject people;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(WebSocketClient.instance.isput)
        {
            WebSocketClient.instance.isput = false;
            PutFunc();
            //WebSocketClient.instance.isput = false;
        }

        if(WebSocketClient.instance.ispop)
        {
            WebSocketClient.instance.ispop = false;
            Pop(WebSocketClient.instance.popId);
        }
    }

    public void PutFunc()
    {
        
        SkinDatabase skinDatabase = FindObjectOfType<SkinDatabase>();
        Debug.Log("Real put");

        foreach(Put i in WebSocketClient.instance.putInfos)
        {
            int index = skinDatabase.itemNames.IndexOf(i.body.skin);
            Debug.Log("skinDataabse index: " + index);
            GameObject person = Instantiate(skinDatabase.items[index], people.transform);
            person.AddComponent<PId>();
            PId personid = person.GetComponent<PId>();
            personid.pid = i.id;

            float xScale = 0.9f;
            if (i.body.scale != 0)
            {
                xScale *= i.body.scale;
            }
            person.transform.localScale = new Vector3(xScale, 0.9f, 0.9f);
            person.transform.localPosition = new Vector3(Random.Range(-2.5f, 2.5f), 0, Random.Range(-5.0f, 5.0f));
        }
    }

    public void Pop(string id)
    {
        PId[] components = people.GetComponentsInChildren<PId>();
        Debug.Log("pop");
        foreach (PId person in components)
        {
            if (person.pid == id)
            {
                Destroy(person.gameObject);
            }
        }
    }
}
