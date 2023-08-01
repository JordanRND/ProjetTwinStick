using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float life = 1;
    [SerializeField] private GameObject bullet;

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Destroy(collision.gameObject);
            //Destroy(bullet);
            collision.gameObject.SetActive(false);
            bullet.SetActive(false);
        } else
        {
            bullet.SetActive(false);
        }
    }
}
