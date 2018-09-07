using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewClass : MonoBehaviour {
	public GameObject myMap;
	//public GameObject myButtonMap;
	public GameObject myVideo;
	//public GameObject myButtonVideo;
	public GameObject myPointer;
	//public GameObject myPortrait;

    public Animator myAnimPointer;

    public GameObject startMode;

    //private bool isVideoOn = false;
	//private bool isMapOn = false;


    public void start () {

    }


    public void OnClickMap() {
    	myVideo.SetActive(false);

		if(myMap.activeSelf) {
			//isMapOn = false;

			myMap.SetActive(false);
			startMode.SetActive(true);
			myAnimPointer.Rebind();
			myAnimPointer.Play("AddressStill2");
		}
		else {
			//isMapOn = true;

			myMap.SetActive(true);
			startMode.SetActive(false);
			myAnimPointer.Play("AnimAdresse");
		}
    }


    public void OnClickVideo() {
    	myMap.SetActive(false);

		if(myVideo.activeSelf) {
			//isVideoOn = false;

			myVideo.SetActive(false);
			startMode.SetActive(true);
			myPointer.SetActive(true);
		}
		else {
			//isVideoOn = true;

			myVideo.SetActive(true);
			startMode.SetActive(false);
			myPointer.SetActive(false);
		}    	
    }

}