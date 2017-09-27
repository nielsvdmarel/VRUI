using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class ViveInput : MonoBehaviour {
    public SteamVR_TrackedObject mTrackedObject = null;
    public SteamVR_Controller.Device VRController;
    public bool LeftTriggerPressed;
    public bool RightTriggerPressed;
    private GameObject GameLeader;
    
    //swipen
    private readonly Vector2 mXAxis = new Vector2(1, 0);
    private readonly Vector2 mYAxis = new Vector2(0, 1);
    private bool trackingSwipe = false;
    private bool checkSwipe = false;

    // The angle range for detecting swipe
    private const float mAngleRange = 30;

    // To recognize as swipe user should at lease swipe for this many pixels
    private const float mMinSwipeDist = 0.2f;

    // To recognize as a swipe the velocity of the swipe
    // should be at least mMinVelocity
    // Reduce or increase to control the swipe speed
    private const float mMinVelocity = 4.0f;

    private Vector2 mStartPosition;
    private Vector2 endPosition;

    private float mSwipeStartTime;

    void Awake()
    {
        mTrackedObject = GetComponent<SteamVR_TrackedObject>();
        GameLeader = GameObject.Find("VRUI");
    }	

	
	void Update ()
    {
        VRController = SteamVR_Controller.Input((int)mTrackedObject.index);

        Swiping();

        if (VRController.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Vector2 touchpad = (VRController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
            print("Pressing Touchpad");

            if (touchpad.y > 0.7f)
            {
                print("Moving Up");
            }

            else if (touchpad.y < -0.7f)
            {
                print("Moving Down");
            }

            if (touchpad.x > 0.7f)
            {
                print("Moving Right");

            }

            else if (touchpad.x < -0.7f)
            {
                print("Moving left");
            }

        }

        if (VRController.GetTouchDown(SteamVR_Controller.ButtonMask.Grip))
        {
            if (this.tag == "RightController")
            {
                GameLeader.GetComponent<UIPosition>().SwichCameraPositionRight();
            }

            if (this.tag == "LeftController")
            {
                GameLeader.GetComponent<UIPosition>().SwichCameraPositionRight();
                LeftTriggerPressed = true;
            }
            Debug.Log("grip Down");
        }

        if (VRController.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
			if(this.tag == "RightController")
            {
                RightTriggerPressed = true;
            }

            if(this.tag == "LeftController")
            {
                LeftTriggerPressed = true;
            }
            Debug.Log("trigger Down");
        }

        if (VRController.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            if (this.tag == "RightController")
            {
                RightTriggerPressed = false;
            }

            if (this.tag == "LeftController")
            {
                LeftTriggerPressed = false;
            }
            Debug.Log("trigger Up");
        }

        Vector2 triggerValue = VRController.GetAxis(EVRButtonId.k_EButton_SteamVR_Trigger);
    }

    private void OnSwipeLeft()
    {
        Debug.Log("Swipe Left"); 
    }

    private void OnSwipeRight()
    {
        Debug.Log("Swipe right"); 
        
    }

    private void OnSwipeTop()
    {
        Debug.Log("Swipe Top");
        GameLeader.GetComponent<UIPosition>().SpawnMenu();
    }

    private void OnSwipeBottom()
    {
        Debug.Log("Swipe Bottom");
        GameLeader.GetComponent<UIPosition>().DeleteMenu();
        
    }

    public void Swiping()
    {
        if ((int)mTrackedObject.index != -1 && VRController.GetTouchDown(Valve.VR.EVRButtonId.k_EButton_Axis0))
        {
            trackingSwipe = true;
            
            mStartPosition = new Vector2(VRController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x,
                VRController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y);
            mSwipeStartTime = Time.time;
        }

        else if (VRController.GetTouchUp(Valve.VR.EVRButtonId.k_EButton_Axis0))
        {
            trackingSwipe = false;
            trackingSwipe = true;
            checkSwipe = true;
            
        }

        else if (trackingSwipe)
        {
            endPosition = new Vector2(VRController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x,
                                      VRController.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y);

        }

        if (checkSwipe)
        {
            checkSwipe = false;

            float deltaTime = Time.time - mSwipeStartTime;

            Vector2 swipeVector = endPosition - mStartPosition;

            float velocity = swipeVector.magnitude / deltaTime;
            //Debug.Log(velocity);
            if (velocity > mMinVelocity &&
                swipeVector.magnitude > mMinSwipeDist)
            {
               
                swipeVector.Normalize();

                float angleOfSwipe = Vector2.Dot(swipeVector, mXAxis);
                angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;

                
                if (angleOfSwipe < mAngleRange)
                {
                    OnSwipeRight();
                }
                else if ((180.0f - angleOfSwipe) < mAngleRange)
                {
                    OnSwipeLeft();
                }
                else
                {
                    
                    angleOfSwipe = Vector2.Dot(swipeVector, mYAxis);
                    angleOfSwipe = Mathf.Acos(angleOfSwipe) * Mathf.Rad2Deg;
                    if (angleOfSwipe < mAngleRange)
                    {
                        OnSwipeTop();
                    }
                    else if ((180.0f - angleOfSwipe) < mAngleRange)
                    {
                        OnSwipeBottom();
                    }
                    else
                    {
                        
                    }
                }
            }
        }

    }
}

