using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLooking : MonoBehaviour
{

    public float sensitivity = 1.5f;
    public float smoothness = 10f;

    public float xPos;

    public float smoothMouseXPos;

    public float currentPosition;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        MouseDirection();
    }

    void MouseDirection(){
        xPos = Input.GetAxisRaw("Mouse X");
        xPos *= sensitivity * smoothness;
        smoothMouseXPos = Mathf.Lerp(smoothMouseXPos, xPos, 1f / smoothness);
        currentPosition += smoothMouseXPos;
        transform.localRotation = Quaternion.AngleAxis(currentPosition, transform.up);
        
    }


}

