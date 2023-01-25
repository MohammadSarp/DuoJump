using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{


    public static int score;

    public Text liveScore;
    public Text restartPanelScore;



    void Update(){
        restartPanelScore.text = score.ToString();
        liveScore.text = score.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision){

        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if(rb != null){
            score++;
            Destroy(this);
        }
    }

}
