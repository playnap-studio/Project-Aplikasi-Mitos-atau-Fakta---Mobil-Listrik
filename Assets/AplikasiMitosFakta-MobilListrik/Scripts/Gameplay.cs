using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{

    private LevelMenu _levelMenu;
    public TextMeshProUGUI answerResponseText;

    public void UnlockNextLevelButton()
    {
        //Get Next Level Index
        int nextLevelLoad = SceneManager.GetActiveScene().buildIndex + 1;

        //Load Main Menu
        SceneManager.LoadScene(0);
        
        //Unlock Next Level
        if (nextLevelLoad > PlayerPrefs.GetInt("_levelAt"))
        {
            PlayerPrefs.SetInt("_levelAt", nextLevelLoad);
            PlayerPrefs.SetInt("_sceneryButton", nextLevelLoad - 1);
        }
    }

    public void CorrectAnswer(string correctText)
    {
        answerResponseText.SetText(correctText);
    }

    public void WrongAnswer(string wrongText)
    {
        answerResponseText.SetText(wrongText);
    }

    public void SetAnswerLevel1(string answer1)
    {
        if (PlayerPrefs.GetInt("_levelAt") >= 1)
        {
            PlayerPrefs.SetString("_answer1", answer1);
        }
    }

    public void SetAnswerLevel2(string answer2)
    {
        if (PlayerPrefs.GetInt("_levelAt") >= 2)
        {
            PlayerPrefs.SetString("_answer2", answer2);
            //Reward Scene Salju
        }
    }

    public void SetAnswerLevel3(string answer3)
    {
        if (PlayerPrefs.GetInt("_levelAt") >= 3)
        {
            PlayerPrefs.SetString("_answer3", answer3);
        }
    }

}
