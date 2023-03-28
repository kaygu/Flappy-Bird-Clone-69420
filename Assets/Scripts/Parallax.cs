using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private float _parallaxEffect;
        [SerializeField] private bool _moveWhenPaused = false;
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
            if (Manager.GameState == GameStateEnum.Flying || _moveWhenPaused)
            {
                float dist = speed * _parallaxEffect;
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

