using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Listener : MonoBehaviour {

	private bool isVideoOn = false;
	private bool isMapOn = false;


	public GameObject myMap;
	public GameObject myButtonMap;
	public GameObject myVideo;
	public GameObject myButtonVideo;
	public GameObject myPointer;
	public GameObject myPortrait;

	public string myURLLinkedin = "https://www.linkedin.com/in/juliengamaire/";
	public string myTelNumber = "0665256929";
	public string myEmail = "";
	public string myEmailSubject = "";

	public Animator myAnimPointer;


	// Contains the currently set auto focus mode.
    private CameraDevice.FocusMode mFocusMode;

	// Use this for initialization
	void Start () {

		Screen.orientation = ScreenOrientation.LandscapeLeft;
        print(mFocusMode);
        InvokeRepeating("DoFocus", 2.0f, 2.0f);

        myMap.SetActive(false);
        myVideo.SetActive(false);

        myAnimPointer.enabled = false;
	}
	
	void Update()
	{
		if( Input.GetMouseButtonDown(0) )
		{
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;

			if( Physics.Raycast( ray, out hit, 100 ) )
			{
				Debug.Log( hit.transform.gameObject.name );
				
				if (hit.transform.gameObject.name == "logoAssystem3D") 
				{
					Application.OpenURL("https://www.assystemtechnologies.com/");
				}
				else if (hit.transform.gameObject.name == "BalloonLinkedin") 
				{
					Application.OpenURL(myURLLinkedin);
				}
				else if (hit.transform.gameObject.name == "BalloonPhone") 
				{
					Application.OpenURL("tel://" + myTelNumber);
				}
				else if (hit.transform.gameObject.name == "BalloonMail") 
				{
		  			Application.OpenURL("mailto:" + myEmail + "?subject=" + myEmailSubject);
				}
				else if (hit.transform.gameObject.name == "ButtonVideo" || hit.transform.gameObject.name == "PlaneButtonVideo") 
				{
					if(isMapOn)
					{
						isMapOn = false;
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
						Vector3 position = myButtonVideo.transform.localPosition;
						position.y = 1.0f;
						myButtonVideo.transform.localPosition = position;
						myVideo.SetActive(true);
						myPointer.SetActive(false);
					}
					else
					{
						isVideoOn = false;
						Vector3 position = myButtonVideo.transform.localPosition;
						position.y = 1.6f;
						myButtonVideo.transform.localPosition = position;
						myVideo.SetActive(false);
					}
										
		  			
				}
				else if (hit.transform.gameObject.name == "Pointer" || hit.transform.gameObject.name == "ButtonMap" || hit.transform.gameObject.name == "PlaneButtonMap") 
				{
					if(isVideoOn)
					{
						isVideoOn = false;
						Vector3 position = myButtonVideo.transform.localPosition;
						position.y = 1.6f;
						myButtonVideo.transform.localPosition = position;
						myVideo.SetActive(false);
					}

					if(!isMapOn)
					{
						isMapOn = true;
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
						Vector3 position = myButtonMap.transform.localPosition;
						position.y = 1.6f;
						myButtonMap.transform.localPosition = position;
						myMap.SetActive(false);
						myPointer.SetActive(true);
						myAnimPointer.Rebind();
						myAnimPointer.Play("AddressStill2");
					}
				}
			}			
		}

		if(!isVideoOn && !isMapOn)
		{
			myPortrait.SetActive(true);
			myPointer.SetActive(true);
		}
		else
			myPortrait.SetActive(false);
	}

	/** Configure the focus mode of the camera
    */
    void DoFocus() 
    {
        if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO))
            mFocusMode = CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO;
    }

	
}
