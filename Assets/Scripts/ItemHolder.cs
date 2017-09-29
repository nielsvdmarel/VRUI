using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour {
    public GameObject CurrentItem;
    public int AmountOfItems;
    public Sprite ItemImage;
    public Text ItemName;
    public GameObject ChildImage;
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

   public void UpdateImageAndText()
    {
        this.gameObject.GetComponentsInChildren<Image>()[1].sprite = ItemImage;
        ItemName.text = CurrentItem.name + " X " + AmountOfItems;
    }
}
