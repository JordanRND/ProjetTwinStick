using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] doors;
    [SerializeField] private bool[] playerIsInTheRoom;
    public int counter = 0;
    public int killedEnemies = 0;

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
        foreach (GameObject enemy in enemies)
        {
            counter++;
        }
        counter -= killedEnemies;
        if (counter == 0)
        {
            foreach (GameObject door in doors)
            {
                door.SetActive(false);
            }
        }
    }

    private void Update()
    {   
        CheckEnemiesRemaining();
    }
}
