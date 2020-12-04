using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed;
    float _movementSpeed;
    bool playerLock;
    // Start is called before the first frame update
    void Start()
    {
        //movementSpeed = _movementSpeed;
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

/*        if (playerLock)
            movementSpeed = 0;
        else
            movementSpeed = _movementSpeed;*/
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Wall"))
        {
            Debug.Log("sadsa");

            playerLock = true;
        }
    }

}
