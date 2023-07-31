using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] public Transform bulletSpawnPoint;
    public GameObject bulletObj;
    [SerializeField] public float bulletSpeed = 10;
    private GameObject bullet;
    [SerializeField] private int noOfPlayer;

    public void SpawnBullet()
    {
        if (Input.GetButtonDown("Fire1P" + noOfPlayer))
        {
            bullet = Instantiate(bulletObj, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
