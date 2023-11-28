using System.Collections;
using System.Collections.Generic;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        if (GameManager.Instance.highScore != null)
        {
            highScoreText.text = highScoreText.text = "Best Score: " + GameManager.Instance.highScore.name + " : " + GameManager.Instance.highScore.points;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetPlayerName(string input)
    {
        GameManager.Instance.playerName = input;
    }
}
