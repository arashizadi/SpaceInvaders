using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class ShellDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            BulletScript.ResetBullet();
            Destroy(gameObject);
        }        
        else if (collision.tag == "Enemy")
        {
            collision.transform.position = new Vector3(0, -6);
            Destroy(gameObject);
        }
    }
}
