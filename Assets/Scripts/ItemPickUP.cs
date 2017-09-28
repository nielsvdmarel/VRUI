using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUP : MonoBehaviour {
    private bool RightControllerButton;
    private bool IsInHandle;
    public GameObject Controller;
    public GameObject sword;
    public Rigidbody rb;
    void Start ()
    {
        IsInHandle = false;
        rb = sword.GetComponent<Rigidbody>();
	}
	
	
	void Update ()
    {
        RightControllerButton = GameObject.Find("Controller (right)").GetComponent<ViveInput>().RightTriggerPressed;
       
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "ControllerCollider")
        {
            if (RightControllerButton)
            {
                sword.transform.SetParent(Controller.transform);
                rb.isKinematic = true;
                rb.useGravity = false;
            }

            else
            {
                sword.transform.SetParent(null);
                rb.isKinematic = false;
                rb.useGravity = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "ControllerCollider")
        {
                sword.transform.SetParent(null);
                rb.isKinematic = false;
                rb.useGravity = true;
            
        }
    }


}
