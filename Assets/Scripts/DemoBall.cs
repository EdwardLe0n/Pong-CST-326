using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoBall : MonoBehaviour
{

    private Vector3 currentVelocity;
    private float paddleHitCount;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * 500f, ForceMode.Force);

        paddleHitCount = 0;
    }

    public void ResetBall(double player)
    {

        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 blank = new Vector3(0, 0, 0);

        rb.AddForce(blank, ForceMode.VelocityChange);

        
        if (player == 0)
        {
            transform.rotation = new Quaternion(0, 0, -90 - (UnityEngine.Random.value * 180), 1);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, -90 + (UnityEngine.Random.value * 180), 1);
        }


        transform.position = new Vector3(0, (float)(40 - 20 * player), 0);

        rb.AddForce(transform.up * 500f, ForceMode.Force);

        paddleHitCount = 0;
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
        else if (collision.gameObject.tag == "Player")
        {

            Rigidbody rb = GetComponent<Rigidbody>();
            currentVelocity = rb.velocity;

            currentVelocity = new Vector3(currentVelocity.x, -currentVelocity.y, currentVelocity.z);

            paddleHitCount++;
            Debug.Log("Current Paddle Count: " + paddleHitCount);

            rb.AddForce(currentVelocity * 20f * paddleHitCount, ForceMode.VelocityChange);

        }
        else if (collision.gameObject.tag == "KillWall")
        {
            manager.GetComponent<GameManager>().BallScored();
        }
    }

}
