using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Vuforia;

public class ViewClass : MonoBehaviour, ITrackableEventHandler {
	public GameObject myMap;
	public GameObject myVideo;
	public GameObject myPointer;
	public GameObject startMode;

    public Animator myAnimPointer;
    public Animator myLogoAnim;
    public Animator myBalloonMailAnim;
    public Animator myBalloonLinkedinAnim;
    public Animator myBalloonPhoneAnim;

    // Contains the currently set auto focus mode.
    private CameraDevice.FocusMode mFocusMode;
    private TrackableBehaviour mTrackableBehaviour;

    public void start () {
    	Screen.orientation = ScreenOrientation.LandscapeLeft;
        print(mFocusMode);
        InvokeRepeating("DoFocus", 2.0f, 2.0f);

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    //Configure the focus mode of the camera
    void DoFocus() 
    {
        if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO))
            mFocusMode = CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO;
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED && !myLogoAnim.isActiveAndEnabled)
        {
            //if(!isAnimStarted)
            //{
                //isAnimStarted = true;
                myLogoAnim.enabled = true;
                myLogoAnim.Play("AnimLogoTrans"); 
                //myBalloonMailAnim.enabled = true;
                myBalloonMailAnim.Play("AnimBalloonMail"); 
                myBalloonLinkedinAnim.enabled = true;
                myBalloonLinkedinAnim.Play("AnimBalloonLinkedin"); 
                myBalloonPhoneAnim.enabled = true;
                myBalloonPhoneAnim.Play("AnimBalloonPhone"); 
                

            //}
        }
    }

    public void OnClickMap() {
    	myVideo.SetActive(false);

		if(myMap.activeSelf) {
			myMap.SetActive(false);
			startMode.SetActive(true);
			myAnimPointer.Rebind();
			myAnimPointer.Play("AddressStill2");
		}
		else {
			myMap.SetActive(true);
			startMode.SetActive(false);
			myAnimPointer.Play("AnimAdresse");
		}
    }


    public void OnClickVideo() {
    	myMap.SetActive(false);

		if(myVideo.activeSelf) {
			myVideo.SetActive(false);
			startMode.SetActive(true);
			myPointer.SetActive(true);
		}
		else {
			myVideo.SetActive(true);
			startMode.SetActive(false);
			myPointer.SetActive(false);
		}    	
    }

}