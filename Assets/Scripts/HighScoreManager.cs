using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;

    internal static string currentPlayer { get; set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance);
        }
        currentPlayer = null;    
    }

    public void UpdateHighscore(int highscore)
    {
        if (PlayerPrefs.HasKey(currentPlayer))
        {
            if (PlayerPrefs.GetInt(currentPlayer) < highscore)
            {
                PlayerPrefs.SetInt(currentPlayer, highscore);
                PlayerPrefs.Save();
            }
        }
    }
    public void SetPlayer(string player)
    {
        currentPlayer = player;
        if (!PlayerPrefs.HasKey(player))
        {
            PlayerPrefs.SetInt(player, 0);
            PlayerPrefs.Save();
        }
    }

    public string GetPlayer()
    {
        return currentPlayer;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(currentPlayer);
    }


}
