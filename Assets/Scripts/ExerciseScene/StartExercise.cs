using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartExercise : MonoBehaviour
{
    public GameObject canvas;
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(vanishCanvas);
    }

    void vanishCanvas()
    {
        canvas.SetActive(false);
    }
}
