using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject pipePrefab;
        [SerializeField] private float delay = 2.5f;
        private float timer;
        private float yOffset = 2.5f;

        private float SpawnPositionX;
        private float SpawnPositionY;

        private void Start()
        {
            SpawnPositionX = transform.position.x;
            SpawnPositionY = transform.position.y;
            timer = delay;
            SpawnPipe();
        }

        private void Update()
        {
            if (Manager.GameState == GameStateEnum.Flying)
            {
                timer -= Time.deltaTime;
                if (timer <= 0f)
                {
                    SpawnPipe();
                    timer = delay;
                }
            }
        }

        private void SpawnPipe()
        {
            float range = Random.Range(SpawnPositionY - yOffset, SpawnPositionY + yOffset);
            Instantiate(pipePrefab, new Vector3(SpawnPositionX, range, transform.position.z), Quaternion.identity, transform);
        }
    }
}

