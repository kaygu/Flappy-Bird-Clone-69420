using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cloudPrefab;
    [SerializeField] private Sprite[] textures;
    [SerializeField] private float delay = 2f;
    private float timer;
    private float yOffset = 2.5f;

    private float SpawnPositionX;
    private float SpawnPositionY;

    private void Start()
    {
        timer = delay;
        SpawnPositionX = transform.position.x;
        SpawnPositionY = transform.position.y;
        SpawnCloud();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f && BirdLife.isAlive())
        {
            SpawnCloud();
            timer = delay + Random.Range(0, 1f);
        }

    }

    private void SpawnCloud()
    {
        float range = Random.Range(SpawnPositionY - yOffset, SpawnPositionY + yOffset);
        GameObject cloud = Instantiate(cloudPrefab, new Vector3(SpawnPositionX, range, transform.position.z), Quaternion.identity, transform);
        SpriteRenderer cloudSprite = cloud.GetComponent<SpriteRenderer>();
        int randomSprite = Random.Range(0, textures.Length);
        cloudSprite.sprite = textures[randomSprite];
    }
}
