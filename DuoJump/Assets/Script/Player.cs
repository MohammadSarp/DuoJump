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
    public GameObject rightScore;

    Rigidbody2D rb;
    bool activeRestartButton = false;

    bool activeRightHighScore = true;

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
        RestartWithEnter();
    }

    void Movement(){
        Vector2 velocity = rb.velocity;
        velocity.x = movementSpeed;
        rb.velocity = velocity;
    }


    public void Jump(){

        if(isTopGround == true && Input.GetKeyDown(KeyCode.W) && isPlayer1){
            Rigidbody2D p1Rb = player1Prefab.GetComponent<Rigidbody2D>();
            Vector2 velocity = p1Rb.velocity;
            velocity.y = jumpForce;
            p1Rb.velocity = velocity;
        }


        else if (isBottomGround == true && Input.GetKeyDown(KeyCode.Space) && isPlayer1 == false){
            Rigidbody2D p2Rb = player2Prefab.GetComponent<Rigidbody2D>();
            Vector2 velocity = p2Rb.velocity;
            velocity.y = jumpForce;
            p2Rb.velocity = velocity;
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
        rightScore.SetActive(false);
        activeRestartButton = true;
        activeRightHighScore = false;

        
    }

    public void Restart(){
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        ScoreCounter.score = 0;
        activeRestartButton = false;
        activeRightHighScore = true;
        rightScore.SetActive(true);
    }

    void RestartWithEnter(){

        if(activeRestartButton && Input.GetKeyDown(KeyCode.Return)){
            Restart();
        }
    }

    public void JumpButtonTop(){
        if(isTopGround == true){
        Rigidbody2D p1Rb = player1Prefab.GetComponent<Rigidbody2D>();
        Vector2 velocity = p1Rb.velocity;
        velocity.y = jumpForce;
        p1Rb.velocity = velocity;
        }
    }

    public void JumpButtonBottom(){
        if(isBottomGround == true){
        Rigidbody2D p2Rb = player2Prefab.GetComponent<Rigidbody2D>();
        Vector2 velocity = p2Rb.velocity;
        velocity.y = jumpForce;
        p2Rb.velocity = velocity;
        }
        
    }

    public void ContinueTheGame(){
        Rigidbody2D rbPlayer1 = player1Prefab.GetComponent<Rigidbody2D>();
        Rigidbody2D rbPlayer2 = player2Prefab.GetComponent<Rigidbody2D>();  
        rbPlayer1.constraints = RigidbodyConstraints2D.None;
        rbPlayer2.constraints = RigidbodyConstraints2D.None;
        rbPlayer1.constraints = RigidbodyConstraints2D.FreezeRotation;
        rbPlayer2.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    

    

}
