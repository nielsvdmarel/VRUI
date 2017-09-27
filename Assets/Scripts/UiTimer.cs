using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTimer : MonoBehaviour {
    
    public float Timer;
    [SerializeField]
    private Text TimerText;
    private float TimerNeeded;
	
	void Update()
    {
        TimerText.text = "" + TimerNeeded;
    }


    void OnEnable()
    {
        TimerNeeded = 0;
        StartCoroutine(StartTimer());
    }


    IEnumerator StartTimer()
    {
        TimerNeeded = 0;
        while (TimerNeeded < Timer)
        {
            
            yield return new WaitForSeconds(1);
            TimerNeeded++;
            
        }

    }
}
