using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 8f;

    Rigidbody rb;
    bool jumpPressed;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = transform.forward * v + transform.right * h;
        dir.y = 0f;
        if (dir.magnitude > 1f)
        {
            dir.Normalize();
        }
        
        rb.velocity = new Vector3(dir.x * speed, rb.velocity.y, dir.z * speed);

        if (jumpPressed && isGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);          
        }
        jumpPressed = false;
    }
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.2f);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector3.down * 1.2f);    
    }
}
