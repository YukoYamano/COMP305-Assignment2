using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Not using it. It is copied from midterm assignment
public class newPlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D rBody;
    private Animator anim;
    private float groundCheckRadius = 0.15f;
    private bool isGround = false;
    private bool isFacingRight = true;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        float horiz = Input.GetAxis("Horizontal");
        anim.SetBool("isGrounded", isGround);


        //groundcheck function to be called 
        isGround = GroundCheck();
        // Debug.Log("isGround?:" + GroundCheck());

        if (isGround && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            moveDirection.y -= 2 * Time.deltaTime;
            isGround = false;

        }
        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);




        if (isFacingRight && rBody.velocity.x < 0 || !isFacingRight && rBody.velocity.x > 0)
        {
            Flip();
        }

        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", (rBody.velocity.y));




    }

    //groundcheck function to be implemented
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

}
