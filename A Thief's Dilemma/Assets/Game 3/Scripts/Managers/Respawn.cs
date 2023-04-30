using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject player;
    [SerializeField] private RewindTime rewindTime;
    [SerializeField] private CinemachineShake cinemachineShake;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private AudioSource deathAudio;
    [SerializeField] private Button[] buttons;
    [SerializeField] private Transform respawnPos; // unique respawn point assigned in inspector for each "room"
    [SerializeField] private ParticleSystem deathParticle;

    [Space(5)]
    [SerializeField] private float speed;
    private GameManager3 manager;
    private Color tmp;

    private void Start()
    {
        tmp = playerSprite.color;
        manager = GameObject.Find("GameManager").GetComponent<GameManager3>();
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
            if (!rewindTime.isRewinding) // allows player to reverse through death obstacles (lasers)
            {
                Instantiate(deathParticle, player.transform.position, deathParticle.transform.rotation);
                manager.playerDeath = true;
                RespawnPlayer();
            }
        }
    }

    // death effects, then moves player to assigned respawn position
    void RespawnPlayer()
    {
        cinemachineShake.ShakeCamera(1f, 0.25f);
        deathAudio.Play();
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].buttonActivated = false;
        player.SetActive(false);
        tmp.a = 0;
        playerSprite.color = tmp;
        player.transform.position = respawnPos.position;
        player.SetActive(true);
    }
}
