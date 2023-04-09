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
	public int currentIndex = 0;
	public int choiceIndex = 0;
	public bool showChoice = false;

	private void Start()
	{
		if (currentIndex > 0)
		{
			currentIndex = 0;
			
		}
		
		//countDialogueTrack = 0;
		//selectionRectangle.enabled = false;
		//cameraLockedIcon.enabled = false;
		//nextSentenceButton.interactable = false;
	}

	void Update()
	{
		// if (GameQuit(true))
		// {
		// 	countDialogueTrack = 0;
		// }
		if (currentIndex >= 2 && currentIndex <=2)
		{
			OverwriteNextDialogueText("Kontol");
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
		toggleSpacebarMessage.SetActive(active);
		nextSentenceButton.interactable = active;
	}

	public void ToggleDialoguePanel(bool active)
	{
		dialoguePanel.SetActive(active);
		if(active == true)
		{
			currentIndex++;
		}
	}

	public void OverwriteNextDialogueText(string lineOfDialogue)
	{
		dialogueLineText.SetText(lineOfDialogue);
	}

	public void ToggleChoiceButton(bool active)
	{
		factButton.gameObject.SetActive(active);
		mythButton.gameObject.SetActive(active);
	}
}
