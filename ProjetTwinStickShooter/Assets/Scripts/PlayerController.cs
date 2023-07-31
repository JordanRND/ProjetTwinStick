using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed;

    public void Move(Vector2 moveTo)
    {
        direction = moveTo;
        rb.velocity = new Vector3(direction.x, 0, direction.y) * movementSpeed;

        if (rb.velocity != Vector3.zero)
        {
            transform.forward = rb.velocity;
        }
    }
}
