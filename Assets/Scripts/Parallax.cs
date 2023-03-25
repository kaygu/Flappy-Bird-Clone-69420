using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private float parallaxEffect;
        private float speed = 0;

        private float startpos;
        private float length;

        void Start()
        {
            startpos = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        void FixedUpdate()
        {
            if (Manager.GameState == GameStateEnum.Flying)
            {
                float dist = speed * parallaxEffect;
                transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

                // repeat background
                if (dist > startpos + length)
                {
                    speed = 0;
                }
                else if (dist < startpos - length)
                {
                    speed = 0;
                }
                --speed;
            }
        }
    }
}

