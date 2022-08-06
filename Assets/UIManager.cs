using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ErrorMessage;
    private void Start()
    {
        if (ErrorMessage != null)
        {
            ErrorMessage.gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
        if (HighScoreManager.Instance.GetPlayer() != null)
        {
            SceneManager.LoadScene("main");
        }
        else
        {
            EmptyPlayerError();
        }
    }
    public void Quit()
    {
        Application.Quit();
    }

    private void EmptyPlayerError()
    {
        if (ErrorMessage != null)
        {
            ErrorMessage.gameObject.SetActive(true);
            ErrorMessage.text = "Enter your name to play!";
        }
    }
    public void EnterName(string s)
    {
        HighScoreManager.Instance.SetPlayer(s);
    }
}
