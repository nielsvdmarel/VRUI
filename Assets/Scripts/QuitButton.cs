using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {
    [SerializeField]
    private bool quitButton;
    [SerializeField]
    private GameObject QuitMenu;
    private bool RightControllerButton;
    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        RightControllerButton = GameObject.Find("Controller (right)").GetComponent<ViveInput>().RightTriggerPressed;
    }

    void OnTriggerStay(Collider other)
    {
        if (RightControllerButton)
        {
            if (quitButton)
            {
                Application.Quit();
                Debug.Log("Quit");
            }
            else
            {
                QuitMenu.gameObject.SetActive(false);
            }
        }
    }
}
