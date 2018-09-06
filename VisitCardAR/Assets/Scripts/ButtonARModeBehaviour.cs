using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonARModeBehaviour : MonoBehaviour {

	private bool isAROn = true;
	public Text myButtonText;
	public GameObject myImageTarget;
	public Animator myLogoAnim;
	public GameObject myBalloon1;
	public GameObject myBalloon2;
	public GameObject myBalloon3;
	public float positionY1;
	public float positionY2;
	public float positionY3;

	// Use this for initialization
	void Start () {
		myButtonText.text = "AR Off";
	}

	public void Click()
	{
		if(isAROn)
		{
			myButtonText.text = "AR On";
			isAROn = !isAROn;
			myImageTarget.SetActive(false);
			Vector3 position1 = myBalloon1.transform.localPosition;
			Vector3 position2 = myBalloon2.transform.localPosition;
			Vector3 position3 = myBalloon3.transform.localPosition;
			position1.y = positionY1;
			position2.y = positionY2;
			position3.y = positionY3;
			myBalloon1.transform.localPosition = position1;
			myBalloon2.transform.localPosition = position2;
			myBalloon3.transform.localPosition = position3;
		}
		else
		{
			myButtonText.text = "AR Off";
			isAROn = !isAROn;
			myImageTarget.SetActive(true);
			myLogoAnim.Play("AnimLogoTrans");
		}
	}
	
}
