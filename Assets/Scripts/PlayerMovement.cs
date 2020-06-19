using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;

    public bool isJumping;
    private float move;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Player1")
        {
            move = Input.GetAxis("Horizontal");

            rigidbody.velocity = new Vector3(move*playerSpeed, rigidbody.velocity.y);

            if(move < 0)
                transform.eulerAngles = new Vector3(0, 180, 0);
            else if(move > 0)
                transform.eulerAngles = new Vector3(0, 0, 0);
            
            if(Input.GetButtonDown("Jump") && !isJumping) {
                rigidbody.AddForce(new Vector2(rigidbody.velocity.x, jumpForce));
                isJumping = true;
            }
        }
        if(gameObject.tag == "Player2")
        {
            move = Input.GetAxis("Horizontal2");

            rigidbody.velocity = new Vector3(move*playerSpeed, rigidbody.velocity.y);

            if(move < 0)
                transform.eulerAngles = new Vector3(0, 180, 0);
            else if(move > 0)
                transform.eulerAngles = new Vector3(0, 0, 0);

            if(Input.GetButtonDown("Jump2") && !isJumping) {
                rigidbody.AddForce(new Vector2(rigidbody.velocity.x, jumpForce));
                isJumping = true;
            }
        }
        
        
    }
    


}
