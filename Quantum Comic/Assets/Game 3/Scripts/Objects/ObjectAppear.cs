using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppear : MonoBehaviour
{
    public Collider2D Coll { get; private set; }

    [Header("References")]
    [SerializeField] private PlatformDrop[] platformDrops;
    [SerializeField] private Button[] multiButtons;
    public Button button; // button that makes the object appear

    [Space(5)]
    [SerializeField] private float speed;

    [Space(5)]
    public bool isVisible = false;

    private SpriteRenderer objectSprite;
    private Color tmp;
    private bool canDrop;
    private bool isButton;

    private void Start()
    {
        objectSprite = GetComponent<SpriteRenderer>();
        Coll = GetComponent<Collider2D>();
        tmp = objectSprite.color;

        if (platformDrops.Length > 0) // since both scripts effect alpha values, need to check if object has both scripts assigned
            canDrop = true;
        else
            canDrop = false;

        if (multiButtons.Length > 0) // since both scripts effect alpha values, need to check if object has both scripts assigned
            isButton = true;
        else
            isButton = false;
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
        else if (isButton)
        {
            if (!multiButtons[0].buttonActivated)
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
