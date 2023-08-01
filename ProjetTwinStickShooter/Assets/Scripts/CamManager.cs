using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject cam;
    private Vector3 midpoint;
    private float distance;

    private void CamMovement()
    {
        midpoint = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
        distance = Vector3.Distance(player1.transform.position, player2.transform.position);
        if (distance < 15f)
        {
            distance = 15f;
        }
        else if (distance > 25f)
        {
            distance = 15f + (distance - 25f);
        }
        else if (distance < 35f)
        {
            distance = 20f;
        }
        cam.transform.position = new Vector3(midpoint.x, distance, midpoint.z);
    }
    private void Update()
    {
        CamMovement();
    }
}
