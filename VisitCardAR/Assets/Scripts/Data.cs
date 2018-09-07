using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Vuforia;

public class Data {

	// Contains the currently set auto focus mode.
    private CameraDevice.FocusMode mFocusMode;

    private string[] animationNames;

	/** Configure the focus mode of the camera
    */
    void DoFocus() 
    {
        if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO))
            mFocusMode = CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO;
    }
}