using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : Singleton<UIManager>
{
	public TextMeshProUGUI charNameText, dialogueLineText;
	public GameObject toggleNextSentenceMessage, dialoguePanel;
	public Button nextSentenceButton, factButton, mythButton, finishButton;
	[TextAreaAttribute(4, 10)] public string factDialogueLine;
	[TextAreaAttribute(4, 10)] public string mythDialogueLine;
	public int currentDialogueIndex = 0;
	public int choiceResponseDialogueIndex = 0;
	public bool isFactButtonSelected = false;
	public bool isMythButtonSelected = false;
	public int tempCurrentLastDialogueIndex = 0;

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
			toggleNextSentenceMessage.SetActive(active = false);
			nextSentenceButton.interactable = active = false;
			nextSentenceButton.gameObject.SetActive(active = false);
		}
		else
		{
			nextSentenceButton.gameObject.SetActive(true);
			toggleNextSentenceMessage.SetActive(active);
			nextSentenceButton.interactable = active;
		}
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
		if (currentDialogueIndex == (choiceResponseDialogueIndex-1))
		{
			factButton.gameObject.SetActive(active);
			mythButton.gameObject.SetActive(active);
		}
		else
		{
			factButton.gameObject.SetActive(active = false);
			mythButton.gameObject.SetActive(active = false);
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

	public void ToggleFinishButton(bool active)
	{
		finishButton.gameObject.SetActive(active);
		if (active == true)
		{
			Debug.Log("This is last dialogue sentence");
		}
	}
}
