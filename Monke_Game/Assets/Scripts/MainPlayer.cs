using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    [SerializeField] float _moveSpeed = .5f;
    //[SerializeField] float _maxSpeed = 10f;
    [SerializeField] float _jumpHeight = 10;
    //[SerializeField] float _jumpPower = 5;
    //float _currentTilt = 0;
    bool _isJumping = false;
    float _distToGround;


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

        rigidbody.velocity = velocity;

        /*
        if (Math.Abs(rigidbody.velocity.x) > _maxSpeed)
        {
            if(rigidbody.velocity.x < 0)
            {
                rigidbody.velocity = new Vector2(-1 * _maxSpeed, rigidbody.velocity.y);
            }
            else
            {
                rigidbody.velocity = new Vector2(_maxSpeed, rigidbody.velocity.y);
            }
        } 
        */
    }

    bool isGrounded()
    {
        Debug.Log(transform.position.y - (_distToGround + .1f));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, _distToGround + .1f);
        return hit.collider != null;
    }
}
