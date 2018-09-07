using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ListenerBehaviour : MonoBehaviour 
{

	///*** PUBLIC FIELD ***///

	[Tooltip("Contact informations")]
	public ContactClass myContact;

    [Header("GameObjects :")]
	public GameObject myMap;
	public GameObject myButtonMap;
	public GameObject myVideo;
	public GameObject myButtonVideo;
	public GameObject myPointer;
	public GameObject myPortrait;

	[Header("Animators :")]
	public Animator myAnimPointer;


    ///*** PRIVATE FIELD ***///

	private bool isVideoOn = false;
	private bool isMapOn = false;

	// Contains the currently set auto focus mode.
    private CameraDevice.FocusMode mFocusMode;

	// Use this for initialization
	void Start () {

		// Automatic focus every 2 seconds
        InvokeRepeating("DoFocus", 2.0f, 2.0f);

        myMap.SetActive(false);
        myVideo.SetActive(false);

        myAnimPointer.enabled = false;
	}

	/** Configure the focus mode of the camera
    */
    void DoFocus() 
    {
        if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO))
            mFocusMode = CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO;
    }

    public void onGameObjectlogoAssystem3DClicked()
	{
		Application.OpenURL(myContact.companyURL);
	}

	public void onGameObjectBalloonLinkedinClicked()
	{
		Application.OpenURL(myContact.linkedinURL);
	}

	public void onGameObjectBalloonPhoneClicked()
	{
		Application.OpenURL("tel://" + myContact.telephoneNumber);
	}

	public void onGameObjectBalloonMailClicked()
	{
		Application.OpenURL("mailto:" + myContact.email + "?subject=" + myContact.emailSubject);
	}

	public void onGameObjectVideoClicked()
	{
		if(isMapOn)
		{
			isMapOn = false;

			// Button Translation
			Vector3 position = myButtonMap.transform.localPosition;
			position.y = 1.6f;
			myButtonMap.transform.localPosition = position;

			myMap.SetActive(false);
			myAnimPointer.Rebind();
			myAnimPointer.Play("AddressStill2");
			myPointer.SetActive(false);
		}
		
		if(!isVideoOn)
		{
			isVideoOn = true;

			// Button Translation
			Vector3 position = myButtonVideo.transform.localPosition;
			position.y = 1.0f;
			myButtonVideo.transform.localPosition = position;

			myVideo.SetActive(true);
			myPointer.SetActive(false);
		}

		else
		{
			isVideoOn = false;

			// Button Translation
			Vector3 position = myButtonVideo.transform.localPosition;
			position.y = 1.6f;
			myButtonVideo.transform.localPosition = position;

			myVideo.SetActive(false);
		}

		if(!isVideoOn && !isMapOn)
		{
			myPortrait.SetActive(true);
			myPointer.SetActive(true);
		}
		
		else
			myPortrait.SetActive(false);
	}

	public void onGameObjectMapClicked()
	{
		if(isVideoOn)
		{
			isVideoOn = false;

			// Button Translation
			Vector3 position = myButtonVideo.transform.localPosition;
			position.y = 1.6f;
			myButtonVideo.transform.localPosition = position;

			myVideo.SetActive(false);
		}

		if(!isMapOn)
		{
			isMapOn = true;

			// Button Translation
			Vector3 position = myButtonMap.transform.localPosition;
			position.y = 1.0f;
			myButtonMap.transform.localPosition = position;

			myMap.SetActive(true);
			myPointer.SetActive(true);

			myAnimPointer.enabled = true;
			myAnimPointer.Play("AnimAdresse");
		}

		else
		{
			isMapOn = false;

			// Button Translation
			Vector3 position = myButtonMap.transform.localPosition;
			position.y = 1.6f;
			myButtonMap.transform.localPosition = position;

			myMap.SetActive(false);
			myPointer.SetActive(true);

			myAnimPointer.Rebind();
			myAnimPointer.Play("AddressStill2");
		}

		if(!isVideoOn && !isMapOn)
		{
			myPortrait.SetActive(true);
			myPointer.SetActive(true);
		}

		else
			myPortrait.SetActive(false);
	}	
}
