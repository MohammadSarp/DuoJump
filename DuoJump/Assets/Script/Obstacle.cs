using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Player player;

    public float distanceObstaclePlayer = -5f;


    void Update(){
        ObstacleCleaner();
    }


    void OnCollisionEnter2D(Collision2D collision){
        
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if(rb != null){
            player.Die();            
        }
    }

    void ObstacleCleaner(){
        float distance = player.transform.position.x - transform.position.x;
        if (distance > distanceObstaclePlayer){
            Destroy(gameObject);
        }
    }

    
}
