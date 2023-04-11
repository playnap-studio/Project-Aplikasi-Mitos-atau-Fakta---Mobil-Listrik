using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Playables;

public class GameManager : Singleton<GameManager>
{
	public GameMode gameMode = GameMode.Gameplay;

	private PlayableDirector activeDirector;
	// DialogueBehaviour dialogueBehaviour = new DialogueBehaviour();

	private void Awake()
	{
		//Cursor.lockState = CursorLockMode.Confined;
		// #if UNITY_EDITOR
		// Application.targetFrameRate = 30; //just to keep things "smooth" during presentations
		// #endif
		UIManager.Instance.ToggleNextSentenceMessage(false);
		UIManager.Instance.ToggleChoiceButton(false);
		UIManager.Instance.ToggleFinishButton(false);
	}

	//Called by the TimeMachine Clip (of type Pause)
	public void PauseTimeline(PlayableDirector whichOne)
	{
		activeDirector = whichOne;
		activeDirector.playableGraph.GetRootPlayable(0).SetSpeed(0d);
		gameMode = GameMode.DialogueMoment; //InputManager will be waiting for a spacebar to resume
		UIManager.Instance.ToggleNextSentenceMessage(true);
		UIManager.Instance.ToggleChoiceButton(true);
		if (UIManager.Instance.tempCurrentLastDialogueIndex == UIManager.Instance.currentDialogueIndex)
		{
			UIManager.Instance.ToggleFinishButton(true);
			UIManager.Instance.ToggleNextSentenceMessage(false);
			UIManager.Instance.ToggleChoiceButton(false);
			Debug.Log("GAMEMANAGER : " + UIManager.Instance.tempCurrentLastDialogueIndex);
		}

	}

	//Called by the InputManager
	public void ResumeTimeline()
	{
		UIManager.Instance.ToggleNextSentenceMessage(false);
		UIManager.Instance.ToggleChoiceButton(false);
		UIManager.Instance.ToggleDialoguePanel(false);
		UIManager.Instance.ToggleFinishButton(false);
		activeDirector.playableGraph.GetRootPlayable(0).SetSpeed(1d);
		gameMode = GameMode.Gameplay;
	}

	public enum GameMode
	{
		Gameplay,
		//Cutscene,
		DialogueMoment, //waiting for input
	}
}
