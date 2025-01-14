using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEnemyAttacks : MonoBehaviour
{
    private float seconds;
    [SerializeField] private float maxSeconds;
    [SerializeField] private float minSeconds;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Vector2 force;

    bool moveForward;
    bool moveBack;

    [SerializeField] private Transform ogPos;


    void Start()
    {
        seconds = Random.Range(minSeconds, maxSeconds);
        StartCoroutine(TimeAttack());
    } //END Start()

    private void FixedUpdate()
    {
        Attack();
        Retreat();
    } //END FixedUpdate()

    IEnumerator TimeAttack()
    {
        
        yield return new WaitForSeconds(seconds);

        //Set velocity to 0 to prevent previous force from interfering
        rb.velocity = new Vector2(0, 0);
        moveForward = true;
        moveBack = false;
        StartCoroutine(TimeRetreat());
    } //END TimeAttack()


    IEnumerator TimeRetreat()
    {
        seconds = Random.Range(minSeconds, maxSeconds);
        yield return new WaitForSeconds(seconds);

        //Set velocity to 0 to prevent previous force from interfering
        rb.velocity = new Vector2(0, 0);
        moveForward = false;
        moveBack = true;
        StartCoroutine(TimeAttack());
    } //END TimeRetreat()


    /// <summary>
    /// Adds force to enemy to move forward towards the player
    /// </summary>
    void Attack()
    {
        if (moveForward) 
        {
            
            rb.AddForce(force);
        }
        
    } //END Attack()


    /// <summary>
    /// Moves enemy back to its hiding position
    /// </summary>
    void Retreat()
    {
        if(moveBack)
        {
           
            rb.AddForce(-force);
        }
    } //END Retreat()

} //END TimeENemyAttacks.cs
