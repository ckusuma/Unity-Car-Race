using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMotor : MonoBehaviour {

    public float accelIncreaseRate;
    public float turnSensitivity;
    public Vector3 currVelocity;
    public float maxVelocity;
    float inputH;
    public float balloons;
    public float lives;
    private Rigidbody rb;
    private float inputAccel;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        //inputAccel = Input.GetAxis("6th AXIS");
        currVelocity = rb.velocity;
        if (inputH == -1 || inputH == 1)
        {
            Turn();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currVelocity = rb.velocity;
        VelocityControl();

        
    }

    private void Turn()
    {
        transform.Rotate(new Vector3(0, turnSensitivity * Time.deltaTime * inputH, 0));
    }

    private void VelocityControl()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = currVelocity + (transform.forward * accelIncreaseRate * Time.deltaTime);
            currVelocity = rb.velocity;
        }
        

        float currVelMagnitude = rb.velocity.magnitude;

        if (currVelMagnitude > maxVelocity)
        {
            rb.velocity = currVelocity.normalized * maxVelocity;
        }


    }
}
