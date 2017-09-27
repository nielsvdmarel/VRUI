using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertItemScript : MonoBehaviour {
    [SerializeField]
    private GameObject InserItemTimer;
    [SerializeField]
    private bool ItemIsInserting;
    [SerializeField]
    private float Timer;
    [SerializeField]
    private GameObject CurrentInsertingItem;
    private GameObject Itemlist;
	void Start ()
    {
        ItemIsInserting = false;
    }
	
	
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            ItemIsInserting = true;
            StartCoroutine(StartTimer());
            CurrentInsertingItem = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            ItemIsInserting = false;
            InserItemTimer.SetActive(false);
            CurrentInsertingItem = null;
        }
    }


    IEnumerator StartTimer()
    {
        while (ItemIsInserting)
        {
            InserItemTimer.SetActive(true);
            yield return new WaitForSeconds(Timer);
            AddItemToInventory();
            ItemIsInserting = false;
            InserItemTimer.SetActive(false);
        }
       
    }

    void AddItemToInventory()
    {
        GameObject has = GameObject.Find("ItemManager");
        has.GetComponent<ItemPusher>().CurrentGivenItem = CurrentInsertingItem;
        has.GetComponent<ItemPusher>().PushNewItem();
        
    }
}
