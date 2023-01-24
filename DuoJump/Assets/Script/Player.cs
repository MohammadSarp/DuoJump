using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public bool isPlayer1;
    public float movementSpeed = 10f;
    public float jumpForce = 5f;
    bool isTopGround;
    bool isBottomGround;
    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public GameObject startPoint;
    public GameObject restartPanel;
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

        if(isTopGround == true && Input.GetKeyDown(KeyCode.W) && isPlayer1){
            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }


        else if (isBottomGround == true && Input.GetKeyDown(KeyCode.Space) && isPlayer1 == false){
            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }
        
    }

    public void Die(){
        Rigidbody2D rbPlayer1 = player1Prefab.GetComponent<Rigidbody2D>();
        rbPlayer1.constraints = RigidbodyConstraints2D.FreezePosition;

        Rigidbody2D rbPlayer2 = player2Prefab.GetComponent<Rigidbody2D>();
        rbPlayer2.constraints = RigidbodyConstraints2D.FreezePosition;

        Invoke("ShowRestartPanel", 1f);
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

    void ShowRestartPanel(){
        restartPanel.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        ScoreCounter.score = 0;
    }
}
