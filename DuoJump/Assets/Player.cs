using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isPlayer1;
    public float movementSpeed = 10f;
    public float jumpForce = 5f;
    bool isTopGround;
    bool isBottomGround;
    public GameObject playerPrefab;
    public GameObject startPoint;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Movement();
    }

    void Movement(){
        Vector2 velocity = rb.velocity;
        velocity.x = movementSpeed;
        rb.velocity = velocity;
    }


    void Jump(){

        if(isTopGround == true && Input.GetKeyDown(KeyCode.Space) && isPlayer1){
            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }


        else if (isBottomGround == true && Input.GetKeyDown(KeyCode.W) && isPlayer1 == false){
            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }
        
    }

    public void Die(){
        Vector3 newPos = new Vector3 (startPoint.transform.position.x, startPoint.transform.position.y, 2);
        transform.position = newPos;
    }


    void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.tag == "Ground Top"){
            isTopGround = true;
        } else if (collision.gameObject.tag == "Ground Bottom"){
            isBottomGround = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision){

        if (collision.gameObject.tag == "Ground Top"){
            isTopGround = false;
        } else if (collision.gameObject.tag == "Ground Bottom"){
            isBottomGround = false;
        }
    }

}
