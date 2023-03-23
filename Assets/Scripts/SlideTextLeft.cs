using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public class SlideTextLeft : MonoBehaviour
    {
        private float movementSpeed = 5f;
        private const float DespawnXPosition = -30f; //Left side of the camera

        private void Update()
        {
            if (Manager.GameState == GameStateEnum.Flying)
            {
                if (transform.position.x <= DespawnXPosition)
                {
                    Destroy(transform.gameObject);
                }
                transform.position = new Vector3(transform.position.x - movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
        }
    }
}
