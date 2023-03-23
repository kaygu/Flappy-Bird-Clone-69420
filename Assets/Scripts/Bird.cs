using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace BirdGame
{
    [RequireComponent(typeof(Animator))]
    public class Bird : MonoBehaviour
    {
        private Animator _anim;
        private bool _alive = true;

        // points
        [SerializeField] private TMP_Text pointsText;
        private int points = 0;


        private void Awake()
        {
            if (!Manager.Init()) return;
            _anim = GetComponent<Animator>();
            
        }

        private void Update()
        {
            if (transform.position.y > 5f || transform.position.y < -5f)
            {
                Die();
            }
            if (Input.GetButtonDown("Jump"))
            {
                switch (Manager.GameState)
                {
                    case GameStateEnum.Waiting:
                        Manager.GameState = GameStateEnum.Flying;
                        break;
                    case GameStateEnum.Dead:
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                        break;
                    case GameStateEnum.Flying:
                        break;
                }
            }

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Pipe"))
            {
                Die();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Pipe(Clone)")
            {
                ++points;
                pointsText.text = points.ToString();
            }
        }

        private void Die()
        {
            Manager.GameState = GameStateEnum.Dead;
            _anim.SetTrigger("death");
            _alive = false;
        }
    }

}
