using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform Enemies5;
    public float enemeySpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Enemies5.position += Vector3.right * enemeySpeed * Time.deltaTime;
    }
}
