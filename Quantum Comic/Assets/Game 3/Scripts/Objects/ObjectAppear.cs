using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppear : MonoBehaviour
{
    public Collider2D Coll { get; private set; }
    [SerializeField] private PlatformDrop[] platformDrops;
    private SpriteRenderer objectSprite;
    private Color tmp;
    public Button button;
    [SerializeField] private float speed;
    private bool canDrop;
    public bool isVisible = false;

    private void Start()
    {
        objectSprite = GetComponent<SpriteRenderer>();
        Coll = GetComponent<Collider2D>();
        tmp = objectSprite.color;
        if (platformDrops.Length > 0)
            canDrop = true;
        else
            canDrop = false;
    }

    private void Update()
    {
        if (canDrop)
        {
            if (!platformDrops[0].isDropping)
            {
                if (button.buttonActivated)
                {
                    tmp.a = Mathf.Lerp(tmp.a, 1, speed * Time.deltaTime);
                    Coll.enabled = true;
                    isVisible = true;
                }
                else
                {
                    tmp.a = Mathf.Lerp(tmp.a, 0, speed * Time.deltaTime);
                    Coll.enabled = false;
                    isVisible = false;
                }
                objectSprite.color = tmp;
            }
        }
        else
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
            objectSprite.color = tmp;
        }
    }
}
