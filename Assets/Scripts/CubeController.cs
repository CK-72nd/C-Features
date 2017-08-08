using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public int lives = 3;
    public float rotationSpeed = 180;
    public float acceleration = 10f;
    public float deceleration = 0.1f;

    private Rigidbody2D rigid; // default value null

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Quaternion rot = transform.rotation;

        float z = rot.eulerAngles.z;

        z -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        rot = Quaternion.Euler(0, 0, z);

        transform.rotation = rot;

        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * acceleration * Time.deltaTime, 0);

        pos += rot * velocity;

        transform.position = pos;

    }
}