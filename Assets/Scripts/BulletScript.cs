using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
    //public EnemyChecker Enemychecker;
    AudioSource audioSource;
    public float bulletSpeed;
    float xFireBullet, yFireBullet;
    public static bool  shooting;
    public Transform player;
    public TextMeshPro hud;
    //public GameObject Enemies5, Enemies4, Enemies3, Enemies2, Enemies1;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Physics2D.IgnoreLayerCollision(10, 8, true);
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
            try
            {
                xFireBullet = player.position.x;
                yFireBullet = player.position.y;
                transform.position = new Vector2(xFireBullet, yFireBullet);
                shooting = true;
                audioSource.Play();
            }
            catch (MissingReferenceException)
            {
                SceneManager.LoadScene(0);

            }

        }

        if (shooting)
        {
            transform.position += Vector3.up * bulletSpeed * Time.deltaTime;
            //Deal damage if reaches the enemey
            //If hits the enemy bullet
            if (transform.position.y > 5.4f)
                shooting = false;
        }
        else
            try
            {
                transform.position = player.position;
            }
            catch (MissingReferenceException)
            {
                hud.text = $"You Lose\nScore: {GameManager.score.ToString()}";
                //EnemyScript.enemyMovement = 0;
                //throw;
            }
    }

/*    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            shooting = false;
            Destroy(collision.gameObject);
            Enemychecker.ReCheck();

        }
    }*/
    public static void ResetBullet()
    {
        shooting = false;
    }
}
