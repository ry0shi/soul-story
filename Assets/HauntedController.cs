using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntedController : MonoBehaviour
{
    GameObject hauntedBySoul;
    Rigidbody2D rb;
    float horInput;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpForce = 3;
    bool SpacePressed;

    Feet feet;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feet = transform.Find("Feet").GetComponent<Feet>();
    }

    void Update()
    {
        hauntedBySoul = GameObject.FindWithTag("Player").GetComponent<Haunter>().hauntedObject;
        if (hauntedBySoul == this.gameObject)
        {
            Move();
            Jump();
        }
    }
/*
    private bool IsGrounded()
    {
        var groundCheck = Physics2D.Raycast(transform.position - new Vector3(0, 1f, 0), Vector2.down, 0.05f);
        return groundCheck.collider != null;
    }
*/
    void Move()
    {
        //if (IsGrounded())
        horInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3((horInput * speed * Time.deltaTime), 0, 0));
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && feet.grounded)
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
    }
}
