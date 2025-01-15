using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private GameManager gameManager;
    public int health = 3;
    [SerializeField] private Image[] healthImages;

    [SerializeField] private ParticleSystem healthParticles;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hitSFX;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        DecreaseHealth(collision);
    } //END OnCollisionEnter2D

    /// <summary>
    /// When player collides with an enemy, subtract 1 from health
    /// </summary>
    void DecreaseHealth(Collision2D _collision)
    {
        if (_collision.gameObject.GetComponent<TimeEnemyAttacks>() != null)
        {
            health--;
            healthParticles.Play();
            healthImages[health].gameObject.SetActive(false);

            audioSource.clip = hitSFX;
            audioSource.Play();

            //If player is out of health
            if (health <= 0) 
            {
                Die();
            }
        }
    } //END DecreaseHealth()

    /// <summary>
    /// Ends game with a lose condition
    /// </summary>
    public void Die()
    {
        Debug.Log("Dead");
        gameManager.win = false;
        gameManager.LoadEnd();
        //game over
    } //END Die()




} //END PlayerHealth.cs
