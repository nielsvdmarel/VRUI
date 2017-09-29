using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPusher : MonoBehaviour {
    public GameObject CurrentGivenItem;
    public GameObject[] AllItemSlots;
    public GameObject[] AllItems;
    public Sprite[] PushImage;
    public Text[] CurrentgivenText;
    public int CurrentPushNum;
    private int CurrentImageNum;
    private int ItemNumber;
    
    void Start ()
    {
        CurrentPushNum = 0;
        CurrentImageNum = 0;
    }
	
	
	void Update ()
    {
        print(CurrentGivenItem);
	}

   public void PushNewItem()
    {
        
        for (int CurrentPushNum = 0; CurrentPushNum < AllItemSlots.Length; CurrentPushNum++)
        {

            if (AllItemSlots[CurrentPushNum].GetComponent<ItemHolder>().CurrentItem == null || AllItemSlots[CurrentPushNum].GetComponent<ItemHolder>().CurrentItem == CurrentGivenItem)
            {
                AllItemSlots[CurrentPushNum].GetComponent<ItemHolder>().CurrentItem = CurrentGivenItem;
                AllItemSlots[CurrentPushNum].GetComponent<ItemHolder>().ItemImage = PushImage[SelectItemNumber()];
                AllItemSlots[CurrentPushNum].GetComponent<ItemHolder>().AmountOfItems++;
                AllItemSlots[CurrentPushNum].GetComponent<ItemHolder>().UpdateImageAndText();
                CurrentGivenItem.SetActive(false);
                AllItemSlots[CurrentPushNum].GetComponent<ItemHolder>().AmountOfItems++;
     
                return;
            }

        }
            
     }

    private int SelectItemNumber()
    {

        CurrentImageNum = 0;
        ItemNumber = 0;
        for (int b = 0; b < AllItems.Length; b++)
        {
            if (CurrentGivenItem.name == AllItems[b].name)
            {
                return b; 
            }
        }
        print("error");
        return -1;
    }
}

