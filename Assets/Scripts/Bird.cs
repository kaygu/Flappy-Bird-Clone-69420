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
        private AudioSource _deathSound;

        [SerializeField] private TMP_Text _scoreString;
        [SerializeField] private TMP_Text _highScoreString;
        private int _score = 0;
        private int _oldHighScore;


        private void Awake()
        {
            if (!Manager.Init()) return;
            _anim = GetComponent<Animator>();
            _deathSound = GetComponent<AudioSource>();
            _oldHighScore = PlayerPrefs.GetInt("Highscore", 0);
            SetHighscore();
        }

        private void Update()
        {
            if (Manager.GameState == GameStateEnum.Flying)
            {
                if (transform.position.y > 5f || transform.position.y < -5f)
                {
                    Die();
                }
            }

            if (Input.GetButtonDown("Jump"))
            {
                switch (Manager.GameState)
                {
                    case GameStateEnum.Waiting:
                        Manager.GameState = GameStateEnum.Flying;
                        break;
                    case GameStateEnum.Dead:
                        Manager.GameState = GameStateEnum.Waiting;
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
                ++_score;
                SetScore();
            }
        }

        private void SetScore()
        {
            _scoreString.text = _score.ToString();
        }

        private void SetHighscore()
        {
            _highScoreString.text = _oldHighScore.ToString();
        }

        private void Die()
        {
            Manager.GameState = GameStateEnum.Dead;
            if (_score > _oldHighScore)
            {
                _oldHighScore = _score;
                PlayerPrefs.SetInt("Highscore", _score);
            }
            SetHighscore();
            _deathSound.Play();
            _anim.SetTrigger("death");
        }
    }

}
