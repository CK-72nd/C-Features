using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Variables
{ }
public class Player : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float rotationSpeed = 20f;
    public Vector3 rotateDir = Vector3.forward;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Get Horizontal Input
        float inputH = Input.GetAxis("Horizontal");
        // Get Verical Input
        float inputV = Input.GetAxis("Vertical");
        //Move THe Player
        //Direction X Input (sign) X Speed X DeltaTime
        transform.position += transform.right * inputV * movementSpeed * Time.deltaTime;
        // Direction X Input(sign) X Speed X deltaTime
        transform.eulerAngles += rotateDir * inputH * rotationSpeed * Time.deltaTime;

	}
}
