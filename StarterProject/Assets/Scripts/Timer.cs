using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private PlayerHealth playerHealth;


    // Update is called once per frame
    void Update()
    {
        CountdownTimer();
    } //END Update()

    /// <summary>
    /// Uses starting time (10 seconds) and subtracts how long it has been since the game has started/this script has been enabled ot get time left
    /// </summary>
    void CountdownTimer()
    {
        timer -= Time.deltaTime;
        
        //Check if game is ongoing or time is up
        if (timer <= 0)
        {
            //Time is up
            timerText.text = "0";
            playerHealth.Die();
        }
        else
        {
            timerText.text = timer.ToString();
        }


    } //END CountdownTimer()
} //END Timer.cs
