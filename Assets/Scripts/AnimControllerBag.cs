using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControllerBag : MonoBehaviour {
    private Animator anim;
	
	void Start ()
    {
        anim = this.GetComponent<Animator>();
        anim.SetInteger("OpenClosed", 0);
	}

    void OpenAnim()
    {
        anim.SetInteger("OpenClosed", 1);
    }

    void CloseAnim()
    {
        anim.SetInteger("OpenClosed", 0);
    }

   void OnTriggerStay(Collider col)
    {
      
        OpenAnim();
    }

    void OnTriggerExit(Collider col)
    {
        CloseAnim();
    }
}
