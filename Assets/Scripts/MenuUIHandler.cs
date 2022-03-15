using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DisplayHiScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        TMP_InputField nameInput = GameObject.Find("NameInputField").GetComponent<TMP_InputField>();
        if (!string.IsNullOrEmpty(nameInput.text))
        {
            DataManager.Instance.CurrentPlayerName = nameInput.text;
            SceneManager.LoadScene("main");
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void DisplayHiScore()
    {
        TextMeshProUGUI hiScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        hiScoreText.text = $"HiScore: {DataManager.Instance.HiScore} By: {DataManager.Instance.HiScorePlayerName}";
    }
}
