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
    private float camHeight;

    private void CamMovement()
    {
        midpoint = Vector3.Lerp(player1.transform.position, player2.transform.position, 0.5f);
        distance = Vector3.Distance(player1.transform.position, player2.transform.position);

        if (distance > 25f && distance <= 35f)
        {
            camHeight = 15f + (distance - 25f);
        }
        else if (distance <= 15f)
        {
            camHeight = 15f;
        }
        else if (distance > 35f)
        {
            camHeight = 25f;
        }
        
        cam.transform.position = new Vector3(midpoint.x, camHeight, midpoint.z);
    }
    private void Update()
    {
        CamMovement();
    }
}
