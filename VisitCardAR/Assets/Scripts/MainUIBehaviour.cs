using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIBehaviour : MonoBehaviour 
{

	///*** PUBLIC FIELD ***///

	[Header("Canvas section :")]
	public Canvas myCanvasMainUI;
	public Canvas myCanvasMenu;

	[Header("Animation section :")]
	public Animator myLogoAnim;

	[Header("UI Section :")]
	public Text myButtonARText;
	public GameObject myImageTarget;
	

	///*** PRIVATE FIELD ***///

	private bool isAR_ON = true;

	

	// Use this for initialization
	void Start () {

		myCanvasMenu.enabled = true;
		myCanvasMainUI.enabled = false;	
	}
	
	public void OnButtonStartClicked()
	{
		myCanvasMenu.enabled = false;
		myCanvasMainUI.enabled = true;	
	}

	public void onButtonARClicked()
	{
		if(isAR_ON)
		{
			isAR_ON = false;

			myButtonARText.text = "AR On";

			myImageTarget.SetActive(false);
		}

		else
		{
			isAR_ON = true;

			myButtonARText.text = "AR Off";

			myImageTarget.SetActive(true);

			myLogoAnim.Play("AnimLogoTrans");
		}
	}

	public void onButtonQuitClicked()
	{
		// save any game data here
		#if UNITY_EDITOR
		// Application.Quit() does not work in the editor so
		// UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
