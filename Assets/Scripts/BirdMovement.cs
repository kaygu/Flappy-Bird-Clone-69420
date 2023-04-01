using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMovement : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _flaps;

        private float jumpSpeed = 7f;
        private const float forwardVelocity = 5f;
        private Vector2 _previousVelocity;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _audioSource = GetComponent<AudioSource>();

        }

        private void Update()
        {
            if (Manager.GameState == GameStateEnum.Flying)
            {
                if (_rb.bodyType == RigidbodyType2D.Static)
                {
                    _rb.bodyType = RigidbodyType2D.Dynamic;
                    _rb.velocity = _previousVelocity;
                }

                if (Input.GetButtonDown("Jump"))
                {
                    _rb.velocity = Vector2.up * jumpSpeed;
                    _audioSource.clip = _flaps[Random.Range(0, _flaps.Length -1)];
                    _audioSource.Play();
                }

                // Bird roatation
                float angle = Mathf.Atan2(_rb.velocity.y, forwardVelocity) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            else
            {
                if (_rb.bodyType == RigidbodyType2D.Dynamic)
                {
                    _previousVelocity = _rb.velocity;
                    _rb.bodyType = RigidbodyType2D.Static;
                }
            }
        }
    }
}
