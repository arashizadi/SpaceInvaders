using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed;
    public float bulletSpeed;
    public Transform bullet;
    bool shooting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Shoot();
    }

    void PlayerMovement()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;

        else if (Input.GetAxis("Horizontal") < 0)
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && !shooting)
        {
            Debug.Log("Shoot");
            for (float i = 0; i < 7.5f; i = i+ 0.10f)
            {
                Debug.Log(i);
                bullet.position += Vector3.up/1000 * bulletSpeed * Time.deltaTime;

            }
            bullet.position = new Vector2(0, 0);
            shooting = false;
            //implement enemy touch or enemy bullet touch

        }
/*        if(bullet.position.y >= 7.5f)
        {
            bullet.position = new Vector2(0, 0);
            shooting = false;
        }*/
    }
}
