using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAppear : MonoBehaviour
{
    public Collider2D Coll { get; private set; }
    [SerializeField] private SpriteRenderer platformSprite;
    private Color tmp;
    [SerializeField] private Button button;
    [SerializeField] private float speed;

    private void Start()
    {
        Coll = GetComponent<Collider2D>();
        tmp = platformSprite.color;
    }

    private void Update()
    {
        if (button.buttonActivated)
        {
            tmp.a = Mathf.Lerp(tmp.a, 1, speed * Time.deltaTime);
            Coll.enabled = true;
        }
        else
        {
            tmp.a = Mathf.Lerp(tmp.a, 0, speed * Time.deltaTime);
            Coll.enabled = false;
        }
        platformSprite.color = tmp;
    }
}
