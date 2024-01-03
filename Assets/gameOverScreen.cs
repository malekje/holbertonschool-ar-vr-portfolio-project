using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class gameOverScreen : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitButton()
    {

    }

    internal static object Setup(bool v)
    {
        throw new NotImplementedException();
    }
}
