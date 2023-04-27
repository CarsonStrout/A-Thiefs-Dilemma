using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer playerSprite;
    private Color tmp;
    [SerializeField] private Button button;
    [SerializeField] private float speed;
    [SerializeField] private Transform respawnPos; // unique respawn point assigned in inspector for each "room"
    [SerializeField] private ParticleSystem deathParticle;

    private void Start()
    {
        tmp = playerSprite.color;
    }

    private void Update()
    {
        tmp.a = Mathf.Lerp(tmp.a, 1, speed * Time.deltaTime);
        playerSprite.color = tmp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(deathParticle, player.transform.position, deathParticle.transform.rotation);
            RespawnPlayer();
        }
    }

    void RespawnPlayer()
    {
        button.buttonActivated = false;
        player.SetActive(false);
        tmp.a = 0;
        playerSprite.color = tmp;
        player.transform.position = respawnPos.position;
        player.SetActive(true);
    }
}
