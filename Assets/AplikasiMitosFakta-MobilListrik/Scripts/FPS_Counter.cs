using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS_Counter : MonoBehaviour
{
    private int lastFrameIndex;
    private float[] frameDeltaTimeArray;
    [SerializeField]
    private float pollingTime;
    private float timer;
    
    [SerializeField]
    private Text uiText;

    void Awake()
    {
        frameDeltaTimeArray = new float[50];
    }

    void Update()
    {
        //pollingTime *= 10f;
        timer = Time.unscaledDeltaTime;
        // Insert fps float value into the element of array
        frameDeltaTimeArray[lastFrameIndex] = timer;
        // Check if next is the last index, if yes then back to index 0
            lastFrameIndex = (lastFrameIndex + 1) % frameDeltaTimeArray.Length;

        if (((lastFrameIndex + 1) % pollingTime) == 0) 
        {

            uiText.text = Mathf.RoundToInt(CalculateFPS()).ToString();

            //timer -= pollingTime;
            // foreach (float deltaTime in frameDeltaTimeArray)
            // {
            //     deltaTime[lastFrameIndex] = Mathf.RoundToInt(0f).ToString();
            // }
        }

        // if(Input.GetKeyDown(KeyCode.Escape))
        // {
        //     if(Time.timeScale == 1)
        //     {
        //         PauseGame();
        //     }
            
        //     else if(Time.timeScale == 0)
        //     {
        //         Continue();
        //     }
        // }
    }

    // Calculate the average of the fps
    private float CalculateFPS()
    {
        float total = 0f;
        foreach (float deltaTime in frameDeltaTimeArray)
        {
            total += deltaTime;
        }
        return frameDeltaTimeArray.Length / total;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }
}
