using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonARAndQuitClass : MonoBehaviour {

	public Text myButtonText;
	public GameObject myImageTarget;
	public Animator myLogoAnim;

	public void start() {

	}

	public void OnClickAR() {
		if(myImageTarget.activeSelf)
		{
			myButtonText.text = "AR On";
			myImageTarget.SetActive(false);
		}
		else
		{
			myButtonText.text = "AR Off";
			myImageTarget.SetActive(true);
			myLogoAnim.Play("AnimLogoTrans");
		}
	}

	public void OnCLickQuit() {
		Application.Quit();
	}
}