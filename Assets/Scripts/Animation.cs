using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Sprite[] sprites;
    private int spritesIndex;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Animate()
    {
        spritesIndex++;
        if (spritesIndex>=sprites.Length) spritesIndex = 0;
        if (spritesIndex>=0 && spritesIndex<sprites.Length) spriteRenderer.sprite = sprites[spritesIndex];
        Invoke(nameof(Animate), 0.2f);
    }
    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }
}
