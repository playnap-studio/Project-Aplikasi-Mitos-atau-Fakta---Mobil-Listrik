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
	[ConditionalHide("hasChoices", true)] public bool isCorrectAnswer;
	//private int currentChoiceDialogueIndex = 3;


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
			if(Application.isPlaying)
			{
				if(hasToPause)
				{
					pauseScheduled = true;
				}
				
				if(hasChoices)
				{
					//UIManager.Instance.ToggleChoiceButton(true);
					//UIManager.Instance.OverwriteNextDialogueText(dialogueFactLine);
					//currentChoiceDialogueIndex = UIManager.Instance.currentDialogueIndex + 1;
					// if (UIManager.Instance.currentDialogueIndex >= 3 && UIManager.Instance.currentDialogueIndex <= 3)
					// {
					// 	UIManager.Instance.OverwriteNextDialogueText("**This is choice response dialogue");
					// }
					// Debug.Log("This Dialogue has choices and choice index is " + currentChoiceDialogueIndex);
					
					// if(isCorrectAnswer)
					// {
					// 	Debug.Log("Jawabanmu Benar!");
					// 	UIManager.Instance.OverwriteNextDialogueText(dialogueFactLine);
					// }
					// else
					// {
					// 	Debug.Log("Jawabanmu Salah");
					// 	UIManager.Instance.OverwriteNextDialogueText(dialogueMythLine);
					// }
				}
				else
				{
					//currentChoiceDialogueIndex = -1;
					//UIManager.Instance.ToggleChoiceButton(false);
				}
				
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
		}
		else
		{
			UIManager.Instance.ToggleDialoguePanel(false);
			//UIManager.Instance.ToggleChoiceButton(false);
		}

		clipPlayed = false;
	}
}