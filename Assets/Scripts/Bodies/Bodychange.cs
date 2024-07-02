using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Bodychange : MonoBehaviour
{
    [SerializeField] private TMP_InputField heightInput;
    [SerializeField] private TMP_InputField weightInput;
    public Button submitButton;
    public GameObject placeModel;
    public SpaceChange spaceChange;

    private void Start()
    {
        submitButton.onClick.AddListener(CalculateBMI);
        if (Inventory.instance.bmiN<1)
        {
            SetActiveModel(Inventory.instance.characSkin.realCharacters[1]);
        }
        else
        {
            UpdateCharacter(Inventory.instance.bmiN);
        }

        spaceChange.SetSkin();
    }

    void SetActiveModel(GameObject activeModel)
    {
        Instantiate(activeModel, placeModel.transform);
        if (placeModel.transform.childCount>1)
        {
            Destroy(placeModel.transform.GetChild(0).gameObject);
        }
        //placeModel.SetActive(true);
    }

    void CalculateBMI()
    {
        float height = float.Parse(heightInput.text) / 100.0f; // Convert cm to meters
        float weight = float.Parse(weightInput.text);
        float bmi = weight / (height * height);
        Inventory.instance.bmiN = bmi;

        UpdateCharacter(bmi);
    }

    void UpdateCharacter(float bmi)
    {
        GameObject activeModel = Inventory.instance.characSkin.realCharacters[1];
        float baseYScale = 0.9f; // �⺻ y�� ������ ��
        float baseZScale = 0.9f; // �⺻ z�� ������ ��
        float xScale = 0.9f; // �ʱ� x�� ������ ��

        if (bmi < 18.5)
        {
            activeModel = Inventory.instance.characSkin.realCharacters[0];
            // BMI�� ���� x�� ������ ����: 0.9 ~ 1.0 ������ ������ 2.2��� ����
            float scale = 0.9f + (bmi - 16) / (18.5f - 16) * 0.1f;
            xScale *= scale;
            Inventory.instance.scale = scale;
            Inventory.instance.bmi = "skinny";
        }
        else if (bmi < 25)
        {
            activeModel = Inventory.instance.characSkin.realCharacters[1];
            // BMI 18.5 ~ 25 ���̿��� x�� ������ 2.2 ~ 2.64 ���� (1.0 ~ 1.2��)
            float scale = 1.0f + (bmi - 18.5f) / (25 - 18.5f) * 0.2f;
            xScale *= scale;
            //xScale *= 1.0f;
            Inventory.instance.scale = scale;
            Inventory.instance.bmi = "normal";
        }
        else
        {
            activeModel = Inventory.instance.characSkin.realCharacters[2];
            // BMI 25 �̻󿡼� x�� ������ 2.64 ~ 3.3 ���� (1.2 ~ 1.5��)
            float scale = 1.2f + (bmi - 25) / (30 - 25) * 0.3f;
            xScale *= scale;
            Inventory.instance.scale = scale;
            Inventory.instance.bmi = "fat";
        }

        SetActiveModel(activeModel);
        placeModel.transform.localScale = new Vector3(xScale, baseYScale, baseZScale); // ��ü �� ������ ����

    }

}