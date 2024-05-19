using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Bodychange : MonoBehaviour
{
    public GameObject girlskinny;
    public GameObject girl;
    public GameObject girlfat;
    [SerializeField] private TMP_InputField heightInput;
    [SerializeField] private TMP_InputField weightInput;
    public Button submitButton;

    private void Start()
    {
        submitButton.onClick.AddListener(CalculateBMI);
        SetActiveModel(girl);
    }

    void SetActiveModel(GameObject activeModel)
    {
        girlskinny.SetActive(false);
        girl.SetActive(false);
        girlfat.SetActive(false);
        activeModel.SetActive(true);
    }

    void CalculateBMI()
    {
        float height = float.Parse(heightInput.text) / 100.0f; // Convert cm to meters
        float weight = float.Parse(weightInput.text);
        float bmi = weight / (height * height);

        UpdateCharacter(bmi);
    }

    void UpdateCharacter(float bmi)
    {
        GameObject activeModel = girl;
        float baseYScale = 1.0f; // �⺻ y�� ������ ��
        float baseZScale = 1.0f; // �⺻ z�� ������ ��
        float xScale = 1.0f; // �ʱ� x�� ������ ��

        if (bmi < 18.5)
        {
            activeModel = girlskinny;
            // BMI�� ���� x�� ������ ����: 0.9 ~ 1.0 ������ ������ 2.2��� ����
            xScale *= 0.9f + (bmi - 16) / (18.5f - 16) * 0.1f;
        }
        else if (bmi < 25)
        {
            activeModel = girl;
            // BMI 18.5 ~ 25 ���̿��� x�� ������ 2.2 ~ 2.64 ���� (1.0 ~ 1.2��)
            xScale *= 1.0f + (bmi - 18.5f) / (25 - 18.5f) * 0.2f;
        }
        else
        {
            activeModel = girlfat;
            // BMI 25 �̻󿡼� x�� ������ 2.64 ~ 3.3 ���� (1.2 ~ 1.5��)
            xScale *= 1.2f + (bmi - 25) / (30 - 25) * 0.3f;
        }

        SetActiveModel(activeModel);
        activeModel.transform.localScale = new Vector3(xScale, baseYScale, baseZScale); // ��ü �� ������ ����

    }

}