using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public class PipeMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 4f;
        private const float DespawnPipeXPosition = -18f; //Left side of the camera

        private void Update()
        {
            if (Manager.GameState == GameStateEnum.Flying)
            {
                if (transform.position.x <= DespawnPipeXPosition)
                {
                    Destroy(transform.gameObject);
                }
                transform.position = new Vector2(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y);
            }
        }
    }
}
