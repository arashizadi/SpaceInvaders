using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public static int enemy = 11*5;
    public int enemyNumber;
    public float bulletSpeed;
    public static bool enemySpotted = true;
    public Transform enemyBullet;
    public SpriteRenderer[] SpriteArray;
    public static List<Transform> transformList = new List<Transform>();
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        SpriteArray = GetComponentsInChildren<SpriteRenderer>();
        foreach (var sprite in SpriteArray)
            transformList.Add(sprite.transform);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Physics2D.IgnoreLayerCollision(10, 8, true);
    }
    // Update is called once per frame
    void Update()
    {
        if (enemy == 0)
            Debug.Log("You Win");
        try { StartCoroutine(EnemyFire()); }
        catch (MissingReferenceException) { }

    }
    public IEnumerator EnemyFire()
    {
        if (enemyNumber == EnemyScript.level)
        {
            int rng = UnityEngine.Random.Range(0, transformList.Count);
            if (transformList.Count > 0 && !enemySpotted)
            {
                enemySpotted = true;
                try { 
                    enemyBullet.position = new Vector3(transformList[rng].position.x, transformList[rng].position.y);
                    audioSource.Play();
                }
                catch (MissingReferenceException) { }
            }
            else if (transformList.Count > 0 && enemySpotted)
            {
                enemyBullet.position += (Vector3.down) * bulletSpeed * Time.deltaTime;
                if (enemyBullet.position.y < UnityEngine.Random.Range(-10, -60) && enemyBullet.transform != null && transformList[rng] != null)
                {
                    enemySpotted = false;
                    enemyBullet.position = new Vector3(0, -6);
                    yield return new WaitForSeconds(UnityEngine.Random.Range(2, 5));
                }
            }
            else
            {
                EnemyScript.level--;
                enemySpotted = false;
                Destroy(gameObject);
                yield return new WaitForSeconds(UnityEngine.Random.Range(2, 5));
            }
        }
    }
    public void ReCheck()
    {
        SpriteArray = GetComponentsInChildren<SpriteRenderer>();
        if (gameObject.transform.childCount > 0)
            foreach (var sprite in SpriteArray)
                transformList.Add(sprite.transform);
    }
}
