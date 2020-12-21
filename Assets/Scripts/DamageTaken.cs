using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    AudioSource audioSource;
    public EnemyChecker Enemychecker;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("hit e");
            BulletScript.ResetBullet();
            Destroy(gameObject);

        }
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            audioSource.Play();
            BulletScript.ResetBullet();
            Destroy(gameObject);
            Enemychecker.ReCheck();
            EnemyChecker.enemy--;
            EnemyScript.bonus += 0.1f;
            GameManager.score += 10;
        }
    }


}
