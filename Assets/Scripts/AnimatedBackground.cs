using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBackground : MonoBehaviour
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
    //Su dung OnEnable thay Start de co the dung chuyen dong khi game over va bat dau lai khi start over
    //Start chi co the bat dau chuyen dong cua Obj 1 lan duy nhat
    private void OnEnable()
        {
           Invoke(nameof(Animate), 0f);
        }

}
