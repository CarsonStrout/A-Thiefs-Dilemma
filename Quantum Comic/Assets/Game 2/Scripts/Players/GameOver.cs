using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameManager2 gameManager2;
    [SerializeField] private GameObject otherPlayer;

    [Header("Particle Effects")]
    [SerializeField] private ParticleSystem boxParticle;
    [SerializeField] private ParticleSystem mineParticle;
    [SerializeField] private ParticleSystem implosionParticle;

    [Space(5)]
    [Header("Death Sounds")]
    [SerializeField] private AudioSource playerExplosion;
    [SerializeField] private AudioSource mineExplosion;
    [SerializeField] private AudioSource playerImplosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            playerExplosion.Play();
            Instantiate(boxParticle, otherPlayer.transform.position, boxParticle.transform.rotation);
            otherPlayer.SetActive(false);
            Instantiate(boxParticle, gameObject.transform.position, boxParticle.transform.rotation);
            gameObject.SetActive(false);
            gameManager2.loseGame = true;
        }
        else if (other.gameObject.tag == "Mine")
        {
            mineExplosion.Play();
            Destroy(other.gameObject);
            Instantiate(mineParticle, otherPlayer.transform.position, mineParticle.transform.rotation);
            otherPlayer.SetActive(false);
            Instantiate(mineParticle, gameObject.transform.position, mineParticle.transform.rotation);
            gameObject.SetActive(false);
            gameManager2.loseGame = true;
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            playerImplosion.Play();
            Instantiate(implosionParticle, otherPlayer.transform.position, implosionParticle.transform.rotation);
            otherPlayer.SetActive(false);
            Instantiate(implosionParticle, gameObject.transform.position, implosionParticle.transform.rotation);
            gameObject.SetActive(false);
            gameManager2.loseGame = true;
        }
    }
}
