using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {
    [SerializeField]
    private bool quitButton;
    [SerializeField]
    private GameObject QuitMenu;
	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Fire1"))
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
