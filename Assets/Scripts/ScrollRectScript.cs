using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollRectScript : MonoBehaviour
{

    [SerializeField]
    private ScrollRect scrollrect;

    [SerializeField]
    private GameObject Controller;
    [SerializeField]
    private bool UpButton;
    private bool _ButtonIsSelected1;
    private bool _ButtonIsSelected2;
    public Sprite OffImage;
    public Sprite ONImage;

    void Start()
    {
        _ButtonIsSelected1 = false;
        _ButtonIsSelected2 = false;
        
    }

    void Update()
    {
        if (_ButtonIsSelected1)
        {
            scrollrect.verticalNormalizedPosition += 0.01f;
        }

        if (_ButtonIsSelected2)
        {
            scrollrect.verticalNormalizedPosition -= 0.01f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ControllerCollider")
        {
            this.GetComponent<Image>().sprite = ONImage;
            if (UpButton)
            {
                _ButtonIsSelected1 = true;    
            }

            else
            {
                _ButtonIsSelected2 = true;   
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ControllerCollider")
        {
            this.GetComponent<Image>().sprite = OffImage;
            _ButtonIsSelected1 = false;
            _ButtonIsSelected2 = false;
            Debug.Log("OffButton");
        }
    }

    }
