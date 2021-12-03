using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float jumpForce = 500.0f;
    [SerializeField]
    private float groundCheckRadius = 0.15f;
    [SerializeField]
    private Transform groundCheckPos;
    [SerializeField]
    private LayerMask whatIsGround;

    private Rigidbody2D rBody;
    private Animator anim;
    private bool isGround = false;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //whernever interact with physics, it's better to use fixed update over update function.
        float horiz = Input.GetAxis("Horizontal");
        //return true or false.
        isGround = GroundCheck();

      
        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);



        //check if the sprite needs to be flipped
        if (isFacingRight && rBody.velocity.x < 0 || !isFacingRight && rBody.velocity.x > 0)
        {
            Flip();
        }
        /*  else if(!isFacingRight && rBody.velocity.x > 0)
          {
              Flip();
          }*/

        //Communicate with the animator
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));

        anim.SetBool("isGround", isGround);

        anim.SetFloat("yVelocity", (rBody.velocity.y));
    }
    private void Update()
    {
        Jump();
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);

    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }
    private void Jump()
    {
        ///Jump code goes here!
        if (isGround && Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Press Jump button");
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGround = false;
            //This is one way to play the sound effect.
            //GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag =="Platform")
        {
            //Debug.Log("Player is on collide with plartform");
            gameObject.transform.parent = other.transform;
        }   
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag== "Platform")
        {
            gameObject.transform.parent = null;
        }       
    }

}
