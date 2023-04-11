using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(GameManager.Instance.gameMode)
		{
        case GameManager.GameMode.DialogueMoment:
				// if()
				// {
                    UIManager.Instance.nextSentenceButton.onClick.AddListener(delegate { GameManager.Instance.ResumeTimeline(); });
                    UIManager.Instance.factButton.onClick.AddListener(delegate { GameManager.Instance.ResumeTimeline(); });
                    UIManager.Instance.mythButton.onClick.AddListener(delegate { GameManager.Instance.ResumeTimeline(); });
					//GameManager.Instance.ResumeTimeline();
				// }
				break;
        }
        //Debug.Log("Current dialogue track: " + UIManager.Instance.countDialogueTrack);
    }

    public void NextSentence()
    {
        GameManager.Instance.ResumeTimeline();

    }
}
