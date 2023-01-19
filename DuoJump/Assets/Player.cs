using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float movementSpeed = 10f;
    public float jumpForce = 5f;
    public GameObject playerPrefab;
    Rigidbody2D rb;
    public GameObject startPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate(){
        Vector2 velocity = rb.velocity;
        velocity.x = movementSpeed;
        rb.velocity = velocity;

        if(Ground.isGround == true && Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
    }

    void Jump(){
        Vector2 velocity = rb.velocity;
        velocity.y = jumpForce;
        rb.velocity = velocity;
    }

    public void Die(){
        Vector3 newPos = new Vector3 (startPoint.transform.position.x, startPoint.transform.position.y, 2);
        transform.position = newPos;
    }
}
