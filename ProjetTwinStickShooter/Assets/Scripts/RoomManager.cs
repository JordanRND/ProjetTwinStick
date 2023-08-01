using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] doors;
    [SerializeField] private bool[] playerIsInTheRoom;
    public int enemiesCounter = 0;
    private Enemy enemy;

    public void Start()
    {
        enemiesCounter = enemies.Length;
    }

    private void AllPlayersAreInTheRoom()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
        }

        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InputManager inputManager))
        {
            playerIsInTheRoom[inputManager.noOfPlayer - 1] = true;
            if (playerIsInTheRoom[0] && playerIsInTheRoom[1])
            {
                AllPlayersAreInTheRoom();
            }
        }
    }

    public void CheckEnemiesRemaining()
    {
        enemiesCounter--;
        if (enemiesCounter <= 0)
        {
            foreach (GameObject door in doors)
            {
                door.SetActive(false);
            }
        }
    }
}
