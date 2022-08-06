using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ErrorMessage;
    public Slider volumeSlider;
    private void Start()
    {
        if (ErrorMessage != null)
        {
            ErrorMessage.gameObject.SetActive(false);
        }
        if (volumeSlider != null)
        {
            SetSlider();
        }
    }
    public void StartGame()
    {
        if (HighScoreManager.Instance.GetPlayer() != null)
        {
            LoadGame();
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

    public void MainMenu()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("highScore");
    }

    public void LoadGame()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("main");
    }
    public void SetVolume(float f)
    {
        PlayerPrefs.SetFloat(HighScoreManager.Instance.GetPlayer()+"Volume", f);
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("settings");
    }
    private void SetSlider()
    {
        volumeSlider.value = PlayerPrefs.GetFloat(HighScoreManager.Instance.GetPlayer() + "Volume");
    }
}
