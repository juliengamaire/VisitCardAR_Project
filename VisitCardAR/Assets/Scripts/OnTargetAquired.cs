using UnityEngine;
using Vuforia;

public class OnTargetAquired : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;
    private bool isAnimStarted = false;

    public Animator myLogoAnim;
    public Animator myBalloon1Anim;
    public Animator myBalloon2Anim;
    public Animator myBalloon3Anim;
 
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        myLogoAnim.enabled = false;
        myBalloon1Anim.enabled = false;
        myBalloon2Anim.enabled = false;
        myBalloon3Anim.enabled = false;
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
                myLogoAnim.enabled = true;
                myLogoAnim.Play("AnimLogoTrans"); 
                myBalloon1Anim.enabled = true;
                myBalloon1Anim.Play("AnimBalloonMail"); 
                myBalloon2Anim.enabled = true;
                myBalloon2Anim.Play("AnimBalloonLinkedin"); 
                myBalloon3Anim.enabled = true;
                myBalloon3Anim.Play("AnimBalloonPhone"); 
                

            }
            

        }
        else
        {
            
        }
    }   
}