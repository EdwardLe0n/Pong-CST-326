using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoBall : MonoBehaviour
{

    private Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * 500f, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        currentVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            Vector3 bounceForce = new Vector3(-currentVelocity.x, currentVelocity.y, currentVelocity.z);

            rb.AddForce(bounceForce, ForceMode.VelocityChange);

        }
    }

}
