using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
//RaycastHIt2D playerCheck = Physics2D.Raycast(transform.position, Vector2.down, 15f, LayerMask.GetMask("Enemy"))

public class EnemyScript : MonoBehaviour
{
    AudioSource audioSource;
    int enemyRowMovement = 5;
    bool coolDown, lastRowEnemy = true, dropCoolDown;
    public static float enemyMovement = 5;
    public Transform EnemyOne, EnemyTwo, EnemyThree, EnemyFour, EnemyFive, Enemies, LWall, RWall;
    public static int level = 5;
    public static float bonus = 1;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(EnemyMovement());

        if ((Vector3.Distance(EnemyFive.position, RWall.position) < 5.13f ||
            Vector3.Distance(EnemyFour.position, RWall.position) < 5.13f ||
            Vector3.Distance(EnemyThree.position, RWall.position) < 5.13f ||
            Vector3.Distance(EnemyTwo.position, RWall.position) < 5.13f ||
            Vector3.Distance(EnemyOne.position, RWall.position) < 5.13f ||
            Vector3.Distance(EnemyFive.position, LWall.position) < 5.06f ||
            Vector3.Distance(EnemyFour.position, LWall.position) < 5.06f ||
            Vector3.Distance(EnemyThree.position, LWall.position) < 5.06f ||
            Vector3.Distance(EnemyTwo.position, LWall.position) < 5.06f ||
            Vector3.Distance(EnemyOne.position, LWall.position) < 5.06f) && !dropCoolDown)
        {
            dropCoolDown = true;
            Enemies.position += Vector3.down * 25 * Time.deltaTime;
            enemyMovement *= -1;
            StartCoroutine(CoolDown());
        }
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(2);
        dropCoolDown = false;
    }

    IEnumerator EnemyMovement()
    {
        if (!coolDown)
        {
            switch (enemyRowMovement)
            {
                case 1:
                    {
                        lastRowEnemy = true;
                        coolDown = true;
                        EnemyOne.position += Vector3.right * enemyMovement * bonus * Time.deltaTime;
                        EnemyOne.position = new Vector3(EnemyFive.position.x, EnemyOne.position.y);
                        transform.position = new Vector3(EnemyFive.position.x, transform.position.y);
                        enemyRowMovement = 5;
                        yield return new WaitForSeconds(0.04f - bonus/50);
                        break;
                    }
                case 2:
                    {
                        coolDown = true;
                        EnemyTwo.position += Vector3.right * enemyMovement * bonus * Time.deltaTime;
                        EnemyTwo.position = new Vector3(EnemyFive.position.x, EnemyTwo.position.y);
                        enemyRowMovement--;
                        yield return new WaitForSeconds(0.04f - bonus / 50);
                        break;
                    }
                case 3:
                    {
                        coolDown = true;
                        EnemyThree.position += Vector3.right * enemyMovement * bonus * Time.deltaTime;
                        EnemyThree.position = new Vector3(EnemyFive.position.x, EnemyThree.position.y);
                        enemyRowMovement--;
                        yield return new WaitForSeconds(0.04f - bonus / 50);
                        break;
                    }
                case 4:
                    {
                        coolDown = true;
                        EnemyFour.position += Vector3.right * enemyMovement * bonus * Time.deltaTime;
                        EnemyFour.position = new Vector3(EnemyFive.position.x, EnemyFour.position.y);
                        enemyRowMovement--;
                        yield return new WaitForSeconds(0.04f - bonus / 50);

                        break;
                    }
                case 5:
                    {
                        if (lastRowEnemy)
                        {
                            coolDown = true;
                            EnemyFive.position += Vector3.right * enemyMovement * bonus * Time.deltaTime;
                            enemyRowMovement--;
                            yield return new WaitForSeconds(0.04f - bonus / 50);
                            lastRowEnemy = false;
                            audioSource.Play();

                        }
                        break;
                    }
            }
            yield return new WaitForSeconds(0.04f);
            coolDown = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
/*        if (collision.gameObject.tag == "Wall")
        {
            Enemies.position += Vector3.down * 25 * Time.deltaTime;
            enemyMovement *= -1;
        }*/
    }
}
