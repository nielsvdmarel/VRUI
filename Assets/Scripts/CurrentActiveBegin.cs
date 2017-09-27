using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentActiveBegin : MonoBehaviour {

    [SerializeField]
    private int ButtonIndex;
    [SerializeField]
    private int ButtonIndex2;
    public Sprite OffImage;
    public Sprite ONImage;
    private GameObject g;
    public GameObject NextMenu;
    [SerializeField]
    private bool RightControllerButton;




    void Start()
    {
    
        g = GameObject.Find("VRUI");
        NextMenu.SetActive (false);
    }

    void Update()
    {
        RightControllerButton = GameObject.Find("Controller (right)").GetComponent<ViveInput>().RightTriggerPressed;

       
		if (RightControllerButton)
        {

            if(this.gameObject.tag == "Begin")
            {
                if (ButtonIndex != g.GetComponent<UIManager>().currentButtonLayer1)
                {
                    OtherButton();
                }
            }
            if (this.gameObject.tag == "Mid")
            {
                if (ButtonIndex2 != g.GetComponent<UIManager>().currentButtonLayer2)
                {
                    OtherButton();
                }
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
		if (RightControllerButton)
        {
            if (other.tag == "ControllerCollider")
            {
                if (gameObject.tag == "Begin")
                {
                    this.GetComponent<Image>().sprite = ONImage;
                    g.GetComponent<UIManager>().currentButtonLayer1 = ButtonIndex;
                    NextMenu.SetActive(true);
                }
                if (gameObject.tag == "Mid")
                {
                    this.GetComponent<Image>().sprite = ONImage;
                    g.GetComponent<UIManager>().currentButtonLayer2 = ButtonIndex2;
                    NextMenu.SetActive(true); 
                }
                
                if(gameObject.tag == "Final")
                {
                    
                }
            }
        }
    }

    void OtherButton()
    {
        this.GetComponent<Image>().sprite = OffImage;
        NextMenu.SetActive(false);

    }

    void OnDisable()
    {
        if (this.gameObject.tag == "Mid")
        {
            NextMenu.SetActive(false);
            this.GetComponent<Image>().sprite = OffImage;
        }

        if (this.gameObject.tag == "Begin")
        {
            NextMenu.SetActive(false);
            this.GetComponent<Image>().sprite = OffImage;
        }
    }
}
