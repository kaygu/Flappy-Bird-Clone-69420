using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BirdGame
{
    public class SlideObject : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 5f;
        [SerializeField] private Direction _direction;
        private const float _despawnXPosition = -30f; //Left side of the camera

        private void Update()
        {
            if (Manager.GameState == GameStateEnum.Flying)
            {
                if (transform.position.x <= _despawnXPosition)
                {
                    Destroy(this.gameObject);
                }
                float _x = transform.position.x;
                float _y = transform.position.y;
                float _deltaSpeed = _movementSpeed * Time.deltaTime;
                switch (_direction)
                {
                    case Direction.Left:
                        _x -= _deltaSpeed;
                        break;
                    case Direction.Right:
                        _x += _deltaSpeed;
                        break;
                    case Direction.Up:
                        _y += _deltaSpeed;
                        break;
                    case Direction.Down:
                        _y -= _deltaSpeed;
                        break;
                    default:
                        Debug.LogError("Direction enum is not set");
                        break;
                }
                transform.position = new Vector3(_x, _y, transform.position.z);
            }
        }

        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
