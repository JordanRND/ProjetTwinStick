using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    [SerializeField] public Transform bulletSpawnPoint;
    public GameObject bulletObj;
    [SerializeField] public float bulletSpeed = 10;
    private GameObject bullet;
    [SerializeField] private int noOfPlayer;
    public GameObject rocketObj;
    private GameObject rocket;
    [SerializeField] public float rocketSpeed = 10;
    private bool rocketUsed;
    [SerializeField] private AudioClip shootSound;

    public void Move(Vector2 moveTo)
    {
        direction = moveTo;
        rb.velocity = new Vector3(direction.x, 0, direction.y) * movementSpeed;

        if (rb.velocity != Vector3.zero)
        {
            transform.forward = rb.velocity;
        }
    }

    public void Fire1()
    {
        if (Input.GetButtonDown("Fire1P" + noOfPlayer))
        {
            SoundManager.instance.PlaySound(shootSound);
            bullet = Instantiate(bulletObj, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }

    public IEnumerator Fire2()
    {
        if (Input.GetButtonDown("Fire2P" + noOfPlayer) && rocketUsed == false)
        {
            rocket = Instantiate(rocketObj, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            rocket.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * rocketSpeed;
            rocketUsed = true;
            yield return new WaitForSeconds(5f);
            rocketUsed = false;
        }
    }

    public void Update()
    {
        Fire1();
        StartCoroutine(Fire2());
    }
}
