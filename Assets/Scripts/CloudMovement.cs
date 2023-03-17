using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    private float movementSpeed = 4f;
    private float DespawnPositionX = -18f;

    void Update()
    {
        if (transform.position.x <= DespawnPositionX)
        {
            Destroy(transform.gameObject);
        }
        if (BirdLife.isAlive())
        {
            transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
