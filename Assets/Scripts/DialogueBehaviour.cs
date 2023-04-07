using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class DialogueBehaviour : PlayableBehaviour
{
    public string characterName;
	[TextAreaAttribute(4, 10)] public string dialogueLine;
    public int dialogueSize;

	public bool hasToPause = false;
	[Header("Choices Option")] public bool hasChoices = false;
	[ConditionalHide("hasChoices", true)] public string dialogueFactLine;
	[ConditionalHide("hasChoices", true)] public string dialogueMythLine;
	Gameplay gameplay;
	[ConditionalHide("hasChoices", true)] public bool isCorrectAnswer;
	public int choiceIndex;


	private bool clipPlayed = false;
	private bool pauseScheduled = false;
	private PlayableDirector director;

	public override void OnPlayableCreate(Playable playable)
	{
		director = (playable.GetGraph().GetResolver() as PlayableDirector);
		
	}

	public override void ProcessFrame(Playable playable, FrameData info, object playerData)
	{
		
		if(!clipPlayed
			&& info.weight > 0f)
		{
			UIManager.Instance.SetDialogue(characterName, dialogueLine, dialogueSize);			
			//UIManager.Instance.ToggleChoiceButton(true);
			// if(hasChoices)
			// {
			// 	UIManager.Instance.ToggleChoiceButton(true);
			// }
			if(Application.isPlaying)
			{
				if(hasToPause)
				{
					pauseScheduled = true;
				}
				
				if(hasChoices)
				{
					Debug.Log("This Dialogue number Has Choices");
                    // switch(GameManager.Instance.gameMode)
					// {
					// 	case GameManager.GameMode.DialogueMoment:
					// 	Debug.Log("SKLDJMLJDLDJSLSDHLKSHNDNSLKN");
						UIManager.Instance.ToggleChoiceButton(true);
					// 	break;
					// }
					if(isCorrectAnswer)
					{
						Debug.Log("Jawabanmu Benar!");
						UIManager.Instance.OverwriteNextDialogueText(dialogueFactLine);
					}
					else
					{
						Debug.Log("Jawabanmu Salah");
						UIManager.Instance.OverwriteNextDialogueText(dialogueMythLine);
					}
				}
				// else
				// {
				// 	UIManager.Instance.ToggleChoiceButton(false);
				// }
			}
			clipPlayed = true;
		}
	}

	public override void OnBehaviourPause(Playable playable, FrameData info)
	{
		if(pauseScheduled)
		{
			pauseScheduled = false;
			GameManager.Instance.PauseTimeline(director);
			//UIManager.Instance.ToggleChoiceButton(true);
		}
		else
		{
			UIManager.Instance.ToggleDialoguePanel(false);
			
		}
		//UIManager.Instance.ToggleChoiceButton(false);
		

		clipPlayed = false;
	}
}