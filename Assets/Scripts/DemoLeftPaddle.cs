using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DemoLeftPaddle : MonoBehaviour
{
    public float unitsPerSec = 6f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float verticalValue = Input.GetAxis("Vertical");

        Vector3 force = Vector3.right * verticalValue * unitsPerSec; // * unitsPerSecond * Time.deltaTime;
        Debug.Log(force);


        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"we hit {collision.gameObject.name}");
        
        // get reference to paddle collider
        BoxCollider bc = GetComponent<BoxCollider>();
        Bounds bounds = bc.bounds;
        float maxX = bounds.max.x;
        float minX = bounds.min.x;

        Debug.Log($"maxX = {maxX}, minY = {minX}");
        Debug.Log($"x pos of ball is {collision.transform.position.x}");

        Quaternion rotation = Quaternion.Euler(0f, 0f, -60f);
        Vector3 bounceDirection = rotation * Vector3.up;
        
        if (collision.gameObject.tag == "Ball")
        {
            Rigidbody rb = collision.rigidbody;
            rb.AddForce(bounceDirection * 1000f, ForceMode.Force);
        }
    }
}
