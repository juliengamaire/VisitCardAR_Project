using UnityEngine;
using Vuforia;

public class OnTargetAquired : MonoBehaviour, ITrackableEventHandler
{
    ///*** PUBLIC FIELD ***///

    [Header("Logo section")]
    public Animator myLogoAnim;

    [Header("Balloon section")]
    public Animator myBalloonMailAnim;
    public Animator myBalloonLinkedinAnim;
    public Animator myBalloonPhoneAnim;


    ///*** PRIVATE FIELD ***///

    private TrackableBehaviour mTrackableBehaviour;
    private bool isAnimStarted = false;
 
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        /*
        myLogoAnim.enabled = false;
        myBalloonMailAnim.enabled = false;
        myBalloonLinkedinAnim.enabled = false;
        myBalloonPhoneAnim.enabled = false;
        */
    }
     
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if(!isAnimStarted)
            {
                isAnimStarted = true;
                //myLogoAnim.enabled = true;
                myLogoAnim.Play("AnimLogoTrans"); 
                //myBalloonMailAnim.enabled = true;
                myBalloonMailAnim.Play("AnimBalloonMail"); 
                //myBalloonLinkedinAnim.enabled = true;
                myBalloonLinkedinAnim.Play("AnimBalloonLinkedin"); 
                //myBalloonPhoneAnim.enabled = true;
                myBalloonPhoneAnim.Play("AnimBalloonPhone"); 
                

            }
            

        }
        else
        {
            
        }
    }   
}