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
        }
        else if (gameManager.win) 
        {
            bgObj.sprite = backgroundImages[1];
        }
    } //END CheckBackground()

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

} //END EndGameBackground.cs
