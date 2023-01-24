using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = new Vector3(target.transform.position.x + 3f, transform.position.y, -1f);
        transform.position = newPos;

        // Vector3 pos = Vector3.Lerp(transform.position, Vector3.right * Time.deltaTime * 10, 0.5f);
        // transform.position = pos;
    }
}
