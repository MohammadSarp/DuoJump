using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public static bool isGround = true;

    void OnCollisionEnter2D(Collision2D collision){
        
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if(rb != null){
                isGround = true;
            
        }
    }

    void OnCollisionExit2D(Collision2D collision){
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if(rb != null){
                isGround = false;
            
        }
    }
}
