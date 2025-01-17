using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool win;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadInstructions()
    {
        PlayClickSFX();
        SceneManager.LoadScene(1);
        StartCoroutine(WaitToUnloadInstructions());
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadEnd()
    {
        SceneManager.LoadScene(3);
        StartCoroutine (WaitToUnloadEnd());
    }

    public void LoadMainMenu()
    {
        PlayClickSFX();
        SceneManager.LoadScene(0);
    }


    IEnumerator WaitToUnloadInstructions()
    {
        yield return new WaitForSeconds(2);
        LoadGame();
    }

    IEnumerator WaitToUnloadEnd()
    {
        yield return new WaitForSeconds(2);
        LoadMainMenu();
    }

    public void PlayClickSFX()
    {
        audioSource.Play();
    }

    public void QuitGame()
    {
        PlayClickSFX();
        Application.Quit();
    }

   
} //END GameManager.cs
