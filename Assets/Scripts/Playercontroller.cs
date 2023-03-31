using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed = 10.0f;
    //rigidbody 2d  component
    private Rigidbody2D playerRb;
    //animation component
    public Animator playerAnim;
    public bool isOnGround = true;

    



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //move the player with a d 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //move the player left whit left arrow key
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //play run animation
            playerAnim.SetBool("Run", true);
        }
        //move the player right with right arrow key
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            //play run animation
            playerAnim.SetBool("Run", true);
        }
        else
        {
            //stop run animation
            playerAnim.SetBool("Run", false);
        }
        


        //keep the player in bounds
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);

        }
       
        //change the player orientation
        if (horizontalInput < 0)
            {
                transform.localScale = new Vector3(-8, 8, 8);
            }
        else if (horizontalInput > 0)
            {
                transform.localScale = new Vector3(8, 8, 8);
            }

        //jump  
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerRb.AddForce(Vector3.up * 15, ForceMode2D.Impulse);
            //play jump animation
            playerAnim.SetBool("Jump", true);
            isOnGround = false;
        }

        

        

    


       
    }
    //jump only when on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerAnim.SetBool("Jump", false);
            isOnGround = true;

        }
    }
    

}
