using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;
    private Transform person;
    public float horizontal;
    public float vertical;

    private float moveLimiter = 0.7f;

    public float runSpeed = 5f;

    public bool left = false;
    public bool right = true;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        if (horizontal != 0 && vertical != 0) {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        if (horizontal > 0) {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            left = false;
            right = true;
        } else if (horizontal < 0) {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            left = true;
            right = false;
        }
    }

    public bool GetLook() {
        return left;
    }
}