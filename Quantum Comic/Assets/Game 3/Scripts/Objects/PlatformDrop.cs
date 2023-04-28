using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDrop : MonoBehaviour
{
    public Rigidbody2D RB { get; private set; }
    public Collider2D Coll { get; private set; }
    private SpriteRenderer platformSprite;
    private Color tmp;
    private Vector2 startPos;
    [SerializeField] private Button button;
    [SerializeField] private float speed;
    public bool isDropping = false;

    private void Start()
    {
        platformSprite = GetComponent<SpriteRenderer>();
        startPos = transform.localPosition;
        Coll = GetComponent<Collider2D>();
        RB = GetComponent<Rigidbody2D>();
        tmp = platformSprite.color;
    }

    private void Update()
    {
        if (button.buttonActivated)
        {
            RB.bodyType = RigidbodyType2D.Dynamic;
            Coll.enabled = false;
            RB.gravityScale = Mathf.Lerp(RB.gravityScale, 5, speed * Time.deltaTime);
            tmp.a = Mathf.Lerp(tmp.a, 0, speed * Time.deltaTime);
            isDropping = true;
        }
        else
        {
            RB.bodyType = RigidbodyType2D.Static;
            transform.localPosition = startPos;
            Coll.enabled = true;
            tmp.a = Mathf.Lerp(tmp.a, 1, speed * Time.deltaTime);
            isDropping = false;
        }
        platformSprite.color = tmp;
    }
}
