using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 1f;
    [SerializeField] private GameObject bullet;

    void Update()
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
        }
    }
}
