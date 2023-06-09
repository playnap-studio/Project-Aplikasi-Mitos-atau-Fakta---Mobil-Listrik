using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelMenu : MonoBehaviour
{
    public Button[] lvlButtons;
    public TextMeshProUGUI[] answerTexts;
    public int levelAt;

    void Start()
    {
        levelAt = PlayerPrefs.GetInt("_levelAt", 1);

        for (int i=0; i<lvlButtons.Length; i++)
        {
            if ((i+1) > levelAt)
            {
                lvlButtons[i].interactable = false;
                if (levelAt >= 1)
                {
                    answerTexts[i].gameObject.SetActive(false);
                }
            }
        }
        if (levelAt >= 1)
        {
            answerTexts[0].SetText(PlayerPrefs.GetString("_answer1"));
        }
        if (levelAt >= 2)
        {
            answerTexts[1].SetText(PlayerPrefs.GetString("_answer2"));
        }
        if (levelAt >= 3)
        {
            answerTexts[2].SetText(PlayerPrefs.GetString("_answer3"));
        }

        Debug.Log("Current Unlocked Level" + levelAt);
        Debug.Log("| Jawaban Lvl 1: " + PlayerPrefs.GetString("_answer1") + "| Jawaban Lvl 2: " + PlayerPrefs.GetString("_answer2") + "| Jawaban Lvl 3: " + PlayerPrefs.GetString("_answer3"));
    }

    public void LoadLevel(int levelIndex)
    {
        //Load Level based on level index number
        SceneManager.LoadScene(levelIndex);
    }

}