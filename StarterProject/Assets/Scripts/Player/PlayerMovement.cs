using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    float horizontal;
    [SerializeField] private Rigidbody2D rb;
    private PlayerControls playerControls;

    [SerializeField] private float jumpForce;
    private bool canJump;


    private void Awake()
    {
        InitValues();
    } //END Awake()

    private void Update()
    {
        Flip();
    } //END Update()


    private void FixedUpdate()
    {
        Walk();
    } //END FixedUpdate()



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            canJump = true;
        }
    } //END OnCOllisionEnter2D()

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            canJump = false;
        }
    } //END OnCollisionExit2D()


    private void OnEnable()
    {
        playerControls.Enable();
    } //END OnEnable()

    private void OnDisable()
    {
        playerControls.Disable();
    } // END OnDisable()

    private void InitValues()
    {
        //Attach player controls for movement
        playerControls = new PlayerControls();
        playerControls.Player.Movement.performed += ctx => horizontal = ctx.ReadValue<float>();
        playerControls.Player.Movement.canceled += _ => horizontal = 0;

        //Append Jump() to player controls for jump
        playerControls.Player.Jump.started += _ => Jump();
    } //END InitValues()

    /// <summary>
    ///Player walks using new input system
    /// </summary>
    private void Walk()
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        
    } //END Walk()

    /// <summary>
    /// Flips player sprite based on whether it is moving left or right
    /// </summary>
    private void Flip() //Sprites in, not working properly
    {
        if (horizontal < 0) //Left
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1);
        }
        else if (horizontal > 0) //Right
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
        }
    } //END Flip()

    /// <summary>
    /// Player jumps w/ add force
    /// </summary>
    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        
    } //END Jump()
} //END PlayerMovement.cs
