using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagFollowerScript : MonoBehaviour {
    [SerializeField]
    private float FollowSpeed;
    [SerializeField]
    private GameObject VRCamera;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        transform.localPosition = new Vector3(VRCamera.transform.position.x, 1.37f, VRCamera.transform.position.z);

    }
}
