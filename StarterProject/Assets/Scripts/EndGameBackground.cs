using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameBackground : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Image bgObj;
    [SerializeField] private Sprite[] backgroundImages;  //0 should be lose, 1 is win

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winSFX;
    [SerializeField] private AudioClip loseSFX;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        CheckBackground();
    }

    /// <summary>
    /// Change background based on win or lose
    /// </summary>
    private void CheckBackground()
    {
        if (!gameManager.win)
        {
            bgObj.sprite = backgroundImages[0];
            audioSource.clip = loseSFX;
            audioSource.Play();
        }
        else if (gameManager.win) 
        {
            bgObj.sprite = backgroundImages[1];
            audioSource.clip = winSFX;
            audioSource.Play();
        }
    } //END CheckBackground()

    public void LoadMainMenu()
    {
        gameManager.PlayClickSFX();
        SceneManager.LoadScene(0);
    }

} //END EndGameBackground.cs
