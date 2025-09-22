using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using JetBrains.Annotations;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        //플레이어 방향으로 발싸
        target = FindObjectOfType<PlayerController>().transform;   
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
