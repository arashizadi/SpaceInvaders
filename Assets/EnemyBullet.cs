using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    AudioSource audioSource;
    public TextMeshPro hud;
void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            BulletScript.ResetBullet();
            transform.position = new Vector3(0, -6);
        }
        else if (collision.tag == "Shell")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            hud.text = $"You Lose\nScore: {GameManager.score.ToString()}";
            Debug.Log("You Lose");
        }
    }
}
