using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
	//public Image selectionRectangle;
	//public Image cameraLockedIcon;

	public TextMeshProUGUI charNameText, dialogueLineText;
	public GameObject toggleSpacebarMessage, dialoguePanel;
	public Button nextSentenceButton;
	public Button factButton;
	public Button mythButton;
	[TextAreaAttribute(4, 10)] public string factDialogueLine;
	[TextAreaAttribute(4, 10)] public string mythDialogueLine;
	public int currentDialogueIndex = 0;
	public int choiceResponseDialogueIndex = 0;
	public bool isFactButtonSelected = false;
	public bool isMythButtonSelected = false;
	DialogueBehaviour dialogueBehaviour = new DialogueBehaviour();

	private void Start()
	{
		if (currentDialogueIndex > 0)
		{
			currentDialogueIndex = 0;
		}
	}

	void Update()
	{
		if (isFactButtonSelected)
		{
			OverwriteNextDialogueText(factDialogueLine);
		}
		if (isMythButtonSelected)
		{
			OverwriteNextDialogueText(mythDialogueLine);
		}
	}

	public void SetDialogue(string charName, string lineOfDialogue, int sizeOfDialogue)
	{
		charNameText.SetText(charName);
		dialogueLineText.SetText(lineOfDialogue);
		dialogueLineText.fontSize = sizeOfDialogue;

		ToggleDialoguePanel(true);
	}

	public void ToggleNextSentenceMessage(bool active)
	{
		if (currentDialogueIndex == (choiceResponseDialogueIndex-1))
		{
			toggleSpacebarMessage.SetActive(active = false);
			nextSentenceButton.gameObject.SetActive(active = false);
		}
		toggleSpacebarMessage.SetActive(active);
		nextSentenceButton.gameObject.SetActive(active);
	}

	public void ToggleDialoguePanel(bool active)
	{
		dialoguePanel.SetActive(active);
		if (Application.isPlaying)
		{
			if(active == true)
			{
				currentDialogueIndex++;
			}
		}
	}

	public void OverwriteNextDialogueText(string lineOfDialogue)
	{
		if (currentDialogueIndex >= choiceResponseDialogueIndex && currentDialogueIndex <= choiceResponseDialogueIndex)
		{
			dialogueLineText.SetText(lineOfDialogue);
		}
	}

	public void ToggleChoiceButton(bool active)
	{
		if (currentDialogueIndex != (choiceResponseDialogueIndex-1))
		{
			factButton.gameObject.SetActive(active = false);
			mythButton.gameObject.SetActive(active = false);
		}
		else
		{
			factButton.gameObject.SetActive(active);
			mythButton.gameObject.SetActive(active);
		}
	}

	public void IsFactButtonSelected(bool selected)
	{
		isFactButtonSelected = selected;
	}

	public void IsMythButtonSelected(bool selected)
	{
		isMythButtonSelected = selected;
	}
}
