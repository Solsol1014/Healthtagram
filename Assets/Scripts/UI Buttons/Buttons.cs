using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void Exercise()
    {
        SceneManager.LoadScene("Exercise");
    }

    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void SNS()
    {
        SceneManager.LoadScene("SNS");
    }
}
