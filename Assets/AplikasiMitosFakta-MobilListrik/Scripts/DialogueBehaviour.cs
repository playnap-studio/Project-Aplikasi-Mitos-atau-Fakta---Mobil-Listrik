using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class DialogueBehaviour : PlayableBehaviour
{
    public string characterName;
	[TextAreaAttribute(4, 10)] public string dialogueLine;
    public int dialogueFontSize;

	public bool hasToPause = false;
	[Header("Choices Option")] public bool isLastDialogue = false;
	private int currentLastDialogueIndex = 0;


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
			UIManager.Instance.ToggleFinishButton(false);
			UIManager.Instance.SetDialogue(characterName, dialogueLine, dialogueFontSize);			
			if(Application.isPlaying)
			{
				if(hasToPause)
				{
					pauseScheduled = true;
				}
				
				if(isLastDialogue)
				{
					// currentLastDialogueIndex store currentDialogueIndex (0 = 5 -> 5 = 5)
					currentLastDialogueIndex = UIManager.Instance.currentDialogueIndex;
					// tempCurrentLastDialogueIndex store currentLastDialogueIndex (0=5 -> 5=5)
					UIManager.Instance.tempCurrentLastDialogueIndex = currentLastDialogueIndex;
					Debug.Log(currentLastDialogueIndex + ", " + UIManager.Instance.tempCurrentLastDialogueIndex);
				}
				else
				{
					UIManager.Instance.ToggleFinishButton(false);
				}
				
			}
			clipPlayed = true;
		}
	}

	public override void OnBehaviourPause(Playable playable, FrameData info)
	{
		if(pauseScheduled)
		{
			GameManager.Instance.PauseTimeline(director);
		}
		else
		{
			UIManager.Instance.ToggleDialoguePanel(false);
		}

		clipPlayed = false;
	}
}