using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneryMenu : MonoBehaviour
{
    public GameObject[] sceneryLandscapes;
    public Button[] sceneryButtons;
    public int sceneryAt;

    void Start()
    {
        PlayerPrefs.GetInt("_scenery", 0);
        sceneryAt = PlayerPrefs.GetInt("_sceneryButton", 0);
        for (int i=1; i<sceneryButtons.Length; i++)
        {
            if ((i+2) > sceneryAt)
            {
                sceneryButtons[i].interactable = false;
            }
        }
        Debug.Log("Current Unlocked Scenery = " + sceneryAt);
    }

    void Update()
    {
        for (int i=0; i<sceneryLandscapes.Length; i++)
        {
            sceneryLandscapes[i].SetActive(false);
            if (i == PlayerPrefs.GetInt("_scenery"))
            {
                sceneryLandscapes[i].SetActive(true);
            }
        }
    }

    public void ChangeScenery(int sceneryObjectIndex)
    {
        PlayerPrefs.SetInt("_scenery", sceneryObjectIndex);
    }
}
