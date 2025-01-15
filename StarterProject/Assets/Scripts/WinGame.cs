using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
        EndGameWin(collision);
       
    } //END OnCollisionEnter2D()


    /// <summary>
    /// When playe comes into contact with win object, game is ended with the win condition
    /// </summary>
    void EndGameWin(Collision2D _collision)
    {
        if (_collision.gameObject.GetComponent<PlayerHealth>() != null) 
        {
            Debug.Log("Win game");
            gameManager.win = true;
            gameManager.LoadEnd();
            //Game win
        }
    } //END EndGameWin()
} //END WinGame.cs
