using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    float xFireBullet, yFireBullet;
    bool shooting;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && !shooting)
        {
            xFireBullet = player.position.x;
            yFireBullet = player.position.y;
            transform.position = new Vector2(xFireBullet, yFireBullet);
            shooting = true;
        }

        if (shooting)
        {
            transform.position += Vector3.up * bulletSpeed * Time.deltaTime;
            //Deal damage if reaches the enemey
            //If hits the enemy bullet
            if (transform.position.y > 3.2f)
                shooting = false;

        }
        else
            transform.position = player.position;
    }
}
