using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
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

    private int maxAmmo = 10;
    private int currentAmmo;
    private float reloadTime = 1.5f;
    private bool canShoot = true;

    [SerializeField] private TextMeshProUGUI ammoCounter;

    public void Start()
    {
        currentAmmo = maxAmmo;
    }

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
            currentAmmo--;
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

    private IEnumerator Reload()
    {
        if (Input.GetButtonDown("ReloadP" + noOfPlayer))
        {
            Debug.Log("Reloading...");
            canShoot = false;
            yield return new WaitForSeconds(reloadTime);
            canShoot = true;
            currentAmmo = maxAmmo;
            ammoCounter.text = currentAmmo + "/" + maxAmmo;
        }
    }

    public void Update()
    {
        if (currentAmmo <= 0)
        {
            canShoot = false;
        }

        if (currentAmmo >= 0 && currentAmmo < maxAmmo)
        {
            StartCoroutine(Reload());
        }

        if (canShoot == true)
        {
            Fire1();
            ammoCounter.text = currentAmmo + "/" + maxAmmo;
        }
        StartCoroutine(Fire2());
    }
}
