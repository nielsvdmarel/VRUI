using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPosition : MonoBehaviour {
    [SerializeField]
    private GameObject VrMenu;
    [SerializeField]
    private GameObject VRMenuCanvas;
    public bool CameraOpenSpace;
    [SerializeField]
    private Transform FollowObject;
    [SerializeField]
    private float Followspeed;
    [SerializeField]
    private Transform Cameratrack;

    void Start ()
    {
		CameraOpenSpace = true;
	}
	
	
	void Update ()
    {
        if (CameraOpenSpace)
        {
            float step = Followspeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, FollowObject.position, step);
            //VRMenuCanvas.transform.LookAt(Cameratrack.transform);
            VRMenuCanvas.transform.rotation = Quaternion.LookRotation(transform.position - Cameratrack.transform.position);

        }

	}

   public void SpawnMenu()
    {

        VrMenu.gameObject.SetActive(true);
    }

   public void DeleteMenu()
    {
        VrMenu.gameObject.SetActive(false);
    }

    public void SwichCameraPositionRight()
    {
        if (CameraOpenSpace)
        {
            Debug.Log("On Controller");
            CameraOpenSpace = false;
        }
        else
        {
            Debug.Log("Open Space");
            CameraOpenSpace = true;
        }
    }



}
