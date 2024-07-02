using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance { get; private set; }
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

    private void Start()
    {

    }

    public int GetMoney()
    {
        return money;
    }

    public void EditMoney(int amount)
    {
        money += amount;
    }

    int money = 10000;
    public List<Item> items = new List<Item>();
    public Item characSkin;
    public Item spaceSkin;
    public string bmi = "normal";
    public float scale;
    public float bmiN = 0;
    public bool isExercise = false;
    public string exercise = "running";
}
