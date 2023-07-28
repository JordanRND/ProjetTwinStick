using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    public Transform bulletSpawnPoint;
    public GameObject bulleto;
    [SerializeField] public float bulletSpeed = 10;
    private GameObject bullet;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            bullet = Instantiate(bulleto, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
