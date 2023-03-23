using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMovement : MonoBehaviour
    {
        private Rigidbody2D _rb;

        private float jumpSpeed = 7f;
        private const float forwardVelocity = 5f;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();

        }

        private void Update()
        {
            switch (Manager.GameState)
            {
                case GameStateEnum.Waiting:
                    if (_rb.bodyType == RigidbodyType2D.Dynamic) _rb.bodyType = RigidbodyType2D.Static;
                    break;
                case GameStateEnum.Dead:
                    if (_rb.bodyType == RigidbodyType2D.Dynamic) _rb.bodyType = RigidbodyType2D.Static;
                    break;
                case GameStateEnum.Flying:
                    if (_rb.bodyType == RigidbodyType2D.Static) _rb.bodyType = RigidbodyType2D.Dynamic;

                    if (Input.GetButtonDown("Jump"))
                    {
                        _rb.velocity = Vector2.up * jumpSpeed;
                        //if (rb.velocity.x > jumpSpeed) rb.velocity = Vector2.up * jumpSpeed; // cap maximum velocity
                    }

                    // Bird roatation
                    float angle = Mathf.Atan2(_rb.velocity.y, forwardVelocity) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    break;
            }
  
        }
    }
}
