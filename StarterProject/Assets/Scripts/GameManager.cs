using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool win;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadInstructions()
    {
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
    }


    IEnumerator WaitToUnloadInstructions()
    {
        yield return new WaitForSeconds(2);
        LoadGame();
    }
   
} //END GameManager.cs
