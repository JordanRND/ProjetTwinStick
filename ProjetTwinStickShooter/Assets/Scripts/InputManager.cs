using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerController pc;
    [SerializeField] public int noOfPlayer;
    private Vector2 direction;
    [SerializeField] private Gun gun;

    private void GetDirection()
    {
        direction.x = Input.GetAxis("HorizontalP" + noOfPlayer);
        direction.y = Input.GetAxis("VerticalP" + noOfPlayer);
    }

    private void Update()
    {
        GetDirection();
        pc.Move(direction);
        gun.SpawnBullet();
    }
}
