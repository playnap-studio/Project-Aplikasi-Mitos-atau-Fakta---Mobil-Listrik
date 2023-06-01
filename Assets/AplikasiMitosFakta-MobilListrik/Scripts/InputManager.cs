using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    // Update is called once per frame
    void Update()
    {
        switch(GameManager.Instance.gameMode)
		{
            case GameManager.GameMode.DialogueMoment:
                UIManager.Instance.nextSentenceButton.onClick.AddListener(delegate { GameManager.Instance.ResumeTimeline(); });
                UIManager.Instance.factButton.onClick.AddListener(delegate { GameManager.Instance.ResumeTimeline(); });
                UIManager.Instance.mythButton.onClick.AddListener(delegate { GameManager.Instance.ResumeTimeline(); });
            break;
        }
    }
}
