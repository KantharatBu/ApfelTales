using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContrller : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode pressKey;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pressKey))
        {
            sr.sprite = pressedImage;
        }

        if (Input.GetKeyUp(pressKey))
        {
            sr.sprite = defaultImage;
        }
    }
}
