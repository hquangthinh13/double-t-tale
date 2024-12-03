using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public Sprite[] sprites;
    //private int spritesIndex;
    private SpriteRenderer spriteRenderer;
    public CharacterDatabase characterDB;
    AudioManager audioManager;

    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;
    private void UpdateCharacter(int selectedOption){
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprites;
    }
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else Load();
        UpdateCharacter(selectedOption);
    }
//
    public float blinkDuration = 1.7f; // Duration of one blink cycle
    public float gameSpeed = 1f; // Game speed multiplier

    public void StartBlinking()
    {
        StartCoroutine(BlinkCoroutine());
    }

    private IEnumerator BlinkCoroutine()
    {
        float elapsedTime = 0f;
        Color originalColor = spriteRenderer.color;

        while (elapsedTime < blinkDuration)
        {
            elapsedTime += Time.deltaTime * gameSpeed;
            float alpha = Mathf.PingPong(elapsedTime, blinkDuration) / blinkDuration;
            Color newColor = originalColor;
            newColor.a = alpha;
            spriteRenderer.color = newColor;
            yield return null;
        }

        // Restore the original color
        spriteRenderer.color = originalColor;
    }
//
    private CharacterController character;
    private Vector3 direction;
    public float gravity = 9.8f + 2f;
    public float jumpForce = 8f;
    //Awake la ham tu dong duoc goi khi initial script nay trong unity
    private void Awake()
    {
        character = GetComponent<CharacterController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    //Su dung OnEnable thay Start de co the dung chuyen dong khi game over va bat dau lai khi start over
    //Start chi co the bat dau chuyen dong cua Obj 1 lan duy nhat
    private void OnEnable()
    {

        direction = Vector3.zero;
    }
    private void Update()
    {
        direction = direction + Vector3.down * gravity * Time.deltaTime;
        if (character.isGrounded == true) 
        {
            direction = Vector3.down;
            if (Input.GetButton("Jump"))
                {
                    audioManager.PlaySFX(audioManager.jump);
                    direction = Vector3.up * jumpForce;
                }
        }   
        character.Move(direction * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider character)
    {
        if (character.CompareTag("Obstacle"))
        {
            //AnimatedPlayer.Animate().SetActive(false);
            audioManager.PlaySFX(audioManager.hit);
            if(HealthManager.health>1) StartBlinking();
            HealthManager.health--;
            if(HealthManager.health<=0){
                audioManager.PlaySFX(audioManager.death);
                GameManager.Instance.GameOver();
            }
        }
        if (character.CompareTag("Potion"))
        {
            audioManager.PlaySFX(audioManager.start2);
            if (HealthManager.health < 3) HealthManager.health++;
        }
        if (character.CompareTag("Diamond"))
        {
            audioManager.PlaySFX(audioManager.start);
            GameManager.diamondTrigger = true;
            // GameManager.score += 200;
        }
        if (character.CompareTag("SpeedPotion"))
        {
            audioManager.PlaySFX(audioManager.start2);
            GameManager.speedPotionTrigger = true;
        }
    }
}
