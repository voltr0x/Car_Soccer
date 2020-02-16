using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    public GameObject leftWheel;
    public GameObject rightWheel;
    private float maxWheelTurn = 30f;

    [SerializeField] float forwardSpeed;
    [SerializeField] float turnSpeed;

    [SerializeField] ParticleSystem dirtSplatter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get player inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Move the vehicle
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        
        /*
        //Rotate the wheels
        leftWheel.transform.Rotate(Vector3.up, 3f * horizontalInput);
        if(leftWheel.transform.rotation.y < -maxWheelTurn)
        {
            leftWheel.transform.rotation = Quaternion.Euler(leftWheel.transform.rotation.x, -maxWheelTurn, leftWheel.transform.rotation.z);
        }
        
        rightWheel.transform.Rotate(Vector3.up, 3f * horizontalInput);
        if (leftWheel.transform.rotation.y > maxWheelTurn)
        {
            leftWheel.transform.rotation = Quaternion.Euler(leftWheel.transform.rotation.x, maxWheelTurn, leftWheel.transform.rotation.z);
        }
        */

        //Reset vehicle rotation if toppled
        if (Input.GetKey(KeyCode.Space))
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
        }

        //Dirt animation
        if (Input.GetKeyDown(KeyCode.W))
        {
            dirtSplatter.Play();
        }
    }
}
