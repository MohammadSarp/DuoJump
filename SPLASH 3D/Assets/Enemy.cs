using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health = 20f;

    public GameObject deadEffect;

    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage){
        health -= damage;

        if (health < 0){
            Die();
        }
    }
 
    void Die(){
        Instantiate(deadEffect, transform.position, Quaternion.identity);
        enemyManager.RemoveEnemy(this);
        Destroy(gameObject);
    }

}
