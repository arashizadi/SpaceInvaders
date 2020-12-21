using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(50, 250), transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * 3 * Time.deltaTime;
        if (transform.position.x < -20)
            transform.position = new Vector3(Random.Range(50, 250), transform.position.y);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            BulletScript.ResetBullet();
            GameManager.score += 300;
            transform.position = new Vector3(Random.Range(50, 250), transform.position.y);
        }
    }

    }
