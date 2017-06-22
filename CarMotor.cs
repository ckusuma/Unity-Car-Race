using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMotor : MonoBehaviour {

    public float accelIncreaseRate;
    public float turnSensitivity;
    public Vector3 currVelocity;
    public float maxVelocity;
    float inputH;
    float inputH2;
    public float balloons;
    public float lives;
    private Rigidbody rb;
    float inputAccel;
    float inputAccel2;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        inputH2 = Input.GetAxis("Horizontal 2");
        inputAccel = Input.GetAxis("Right Trigger");
        
        currVelocity = rb.velocity;
        if (((inputH == -1 || inputH == 1)  && tag == "Car 1"))
        {
            Turn();
        }
        if (((inputH2 == -1 || inputH2 == 1) && tag == "Car 2"))
        {
            Turn2();
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

    private void Turn2()
    {

        transform.Rotate(new Vector3(0, turnSensitivity * Time.deltaTime * inputH2, 0));
    }

    private void VelocityControl()
    {
        if (tag == "Car 1")
        {
            if (inputAccel == 1)
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

        if (tag == "Car 2")
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
}
