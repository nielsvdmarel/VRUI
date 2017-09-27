using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPusher : MonoBehaviour {
    public GameObject CurrentGivenItem;
    public GameObject[] AllItemSlots;
    public GameObject[] AllItems;
    public Image[] PushImage;
    public int CurrentPushNum;
    
    void Start ()
    {
        CurrentPushNum = 0;
        
    }
	
	
	void Update ()
    {
		
	}

   public void PushNewItem() // werkt maar mag veel schoner, eenvoudiger en count die wordt doorgegeven klopt niet! ook een max toevoegen! 
    {
        CurrentPushNum = 0;
        for (int i = 0; i < AllItemSlots.Length; i++)
        {

            if (AllItemSlots[CurrentPushNum].GetComponent<ItemHolder>().CurrentItem == null || AllItemSlots[CurrentPushNum].GetComponent<ItemHolder>().CurrentItem == CurrentGivenItem)
            {
                AllItemSlots[CurrentPushNum].GetComponent<ItemHolder>().CurrentItem = CurrentGivenItem;
                AllItemSlots[CurrentPushNum].GetComponent<ItemHolder>().AmountOfItems++;
                CurrentPushNum = 0;
                return;
            }

            if (AllItemSlots[CurrentPushNum].GetComponent<ItemHolder>().CurrentItem != CurrentGivenItem)
            {
                CurrentPushNum++;
            }

        }
            
     }
}

