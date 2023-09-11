using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;
    public float jumpForce = 300f;
    public  Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
    }



    // Update is called once per frame
    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        float jumpForce = 300f;

        Vector3 moveDirection = new Vector3 (horizontalMove, 0, verticalMove);
        moveDirection.Normalize();
        float magnitude = moveDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);
        transform.Translate(moveDirection * magnitude * speed *Time.deltaTime, Space.World);

        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space)) rigidBody.AddForce(Vector3.up * jumpForce);
    }
}