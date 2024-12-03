using UnityEngine;

public class AnimatedCharacter : MonoBehaviour
{
    public Sprite[] Crabby;
    public Sprite[] Captain;
    public Sprite[] Pink;
    public Sprite[] Tooth;
    private int spritesIndex;
    private SpriteRenderer spriteRenderer;
    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Animate0()
    {
        spritesIndex++;
        if (spritesIndex>=Crabby.Length) spritesIndex = 0;
        if (spritesIndex>=0 && spritesIndex<Crabby.Length) spriteRenderer.sprite = Crabby[spritesIndex];
        Invoke(nameof(Animate0), 1f/GameManager.Instance.gameSpeed);
    }
    private void Animate1()
    {
        spritesIndex++;
        if (spritesIndex>=Captain.Length) spritesIndex = 0;
        if (spritesIndex>=0 && spritesIndex<Captain.Length) spriteRenderer.sprite = Captain[spritesIndex];
        Invoke(nameof(Animate1), 1f/GameManager.Instance.gameSpeed);
    }
    private void Animate2()
    {
        spritesIndex++;
        if (spritesIndex>=Pink.Length) spritesIndex = 0;
        if (spritesIndex>=0 && spritesIndex<Pink.Length) spriteRenderer.sprite = Pink[spritesIndex];
        Invoke(nameof(Animate2), 1f/GameManager.Instance.gameSpeed);
    }
    private void Animate3()
    {
        spritesIndex++;
        if (spritesIndex>=Tooth.Length) spritesIndex = 0;
        if (spritesIndex>=0 && spritesIndex<Tooth.Length) spriteRenderer.sprite = Tooth[spritesIndex];
        Invoke(nameof(Animate3), 1f/GameManager.Instance.gameSpeed);
    }
    //Su dung OnEnable thay Start de co the dung chuyen dong khi game over va bat dau lai khi start over
    //Start chi co the bat dau chuyen dong cua Obj 1 lan duy nhat
    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else Load();
        if (selectedOption==0) Invoke(nameof(Animate0), 0f);
        else if (selectedOption == 1) Invoke(nameof(Animate1), 0f);
        else if (selectedOption == 2) Invoke(nameof(Animate2), 0f);
        else Invoke(nameof(Animate3), 0f);
    }
}
