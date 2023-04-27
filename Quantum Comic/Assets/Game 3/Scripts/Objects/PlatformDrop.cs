using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDrop : MonoBehaviour
{
    public Rigidbody2D RB { get; private set; }
    [SerializeField] private SpriteRenderer platformSprite;
    private Color tmp;
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Button button;
    [SerializeField] private float speed;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        tmp = platformSprite.color;
    }

    private void Update()
    {
        if (button.buttonActivated)
        {
            RB.bodyType = RigidbodyType2D.Dynamic;
            RB.gravityScale = Mathf.Lerp(RB.gravityScale, 5, speed * Time.deltaTime);
            tmp.a = Mathf.Lerp(tmp.a, 0, speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = startPos;
            RB.bodyType = RigidbodyType2D.Static;
            tmp.a = Mathf.Lerp(tmp.a, 1, speed * Time.deltaTime);
        }
        platformSprite.color = tmp;
    }
}
