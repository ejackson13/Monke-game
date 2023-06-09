using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    [SerializeField] float _moveSpeed = .5f;
    [SerializeField] float _jumpHeight = 10;
    float _distToGround;
    bool _facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        _distToGround = GetComponent<Collider2D>().bounds.extents.y;
        Debug.Log(_distToGround);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, new Vector3(transform.position.x, transform.position.y - (_distToGround + .1f)), Color.black);
        Move();
    }


    void Move()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        Vector2 velocity = new Vector2(Input.GetAxis("Horizontal") * _moveSpeed, 0);
        velocity.y = rigidbody.velocity.y;

        //Debug.Log(velocity.y);

        // program for jumping
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            //Debug.Log("Jump");
            velocity.y += _jumpHeight;
        }

        if((_facingRight && velocity.x < 0) || (!_facingRight && velocity.x > 0)) {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
            _facingRight = !_facingRight;
        }


        rigidbody.velocity = velocity;

        Animator animator = GetComponent<Animator>();
        animator.SetFloat("Speed", Math.Abs(velocity.x));
        animator.SetFloat("Y Velocity", velocity.y);
        animator.SetBool("Grounded", isGrounded());
        
    }

    bool isGrounded()
    {
        //Debug.Log(transform.position.y - (_distToGround + .1f));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, _distToGround + .1f);
        return hit.collider != null;
    }
}
