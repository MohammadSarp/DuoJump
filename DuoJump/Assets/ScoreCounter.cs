using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{


    public static int score;
    public Text scoreText;


    void Update(){
        scoreText.text = score.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision){

        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if(rb != null){
            score++;
            Destroy(this);
        }
    }

}
