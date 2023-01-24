using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float range = 20f;
    public float verticalRange = 20f;
    public float fireRate;
    public float nextTimeToFire;
    public float damage = 20f;

    public LayerMask gunMask;

    BoxCollider theGunTrigger;

    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        theGunTrigger = GetComponent<BoxCollider>();
        theGunTrigger.size = new Vector3 (1, verticalRange, range);
        theGunTrigger.center = new Vector3 (0, 0, range/2);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire){
            Fire();
        }    
    }

    void OnTriggerEnter(Collider collider){

        Enemy enemy = collider.transform.GetComponent<Enemy>();

        if (enemy){
            enemyManager.AddEnemy(enemy);
        }
    }

    void OnTriggerExit(Collider collider){

        Enemy enemy = collider.transform.GetComponent<Enemy>();

        if (enemy){
            enemyManager.RemoveEnemy(enemy);
        }
    }

    void Fire(){


        foreach (var enemy in enemyManager.enemyInSight){

            var dir = enemy.transform.position - transform.position;

            RaycastHit hit;

            if(Physics.Raycast(transform.position, dir, out hit, range * 1.5f, gunMask)){
                if (hit.transform == enemy.transform){
                    enemy.TakeDamage(damage);

                    Debug.DrawRay(transform.position, dir, Color.green);
                }
            }

            }
        

        nextTimeToFire = Time.time + fireRate; 
    }

}
