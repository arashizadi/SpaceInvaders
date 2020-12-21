using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed;
    float _movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _movementSpeed = movementSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

    }

    void PlayerMovement()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        else if (Input.GetAxis("Horizontal") < 0)
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        if (transform.position.x > 5.43f)
            ResetRightMove();
        if (transform.position.x < -5.43f)
            ResetLeftMove();
    }
    void ResetRightMove()
    {
        movementSpeed = 0;
        transform.position = new Vector3(5.3f, transform.position.y);
        movementSpeed = _movementSpeed;
    }
    void ResetLeftMove()
    {
        movementSpeed = 0;
        transform.position = new Vector3(-5.3f, transform.position.y);
        movementSpeed = _movementSpeed;
    }
/*    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            Debug.Log(transform.position.x);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            movementSpeed = _movementSpeed;
        }
    }*/
}
