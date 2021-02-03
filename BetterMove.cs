using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class BetterMove : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public bool onGround = true;

    public float speed = 15.0f;
    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * speed;
        float yMovement = Input.GetAxis("Vertical") * speed;
        xMovement *= Time.deltaTime * 5;
        yMovement *= Time.deltaTime * 5;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(xMovement, 0.0f, yMovement);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(xMovement, 0.0f, yMovement);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(xMovement, 0.0f, yMovement);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(xMovement, 0.0f, yMovement);
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            onGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            onGround = true;
        }
    }
}

