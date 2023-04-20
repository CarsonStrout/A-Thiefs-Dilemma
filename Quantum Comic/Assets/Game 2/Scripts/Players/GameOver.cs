using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameManager2 gameManager2;
    [SerializeField] private GameObject otherPlayer;
    [SerializeField] private ParticleSystem deathParticle;
    [SerializeField] private AudioSource playerExplosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            playerExplosion.Play();
            Instantiate(deathParticle, otherPlayer.transform.position, deathParticle.transform.rotation);
            otherPlayer.SetActive(false);
            Instantiate(deathParticle, gameObject.transform.position, deathParticle.transform.rotation);
            gameObject.SetActive(false);
            gameManager2.loseGame = true;
        }
    }
}
