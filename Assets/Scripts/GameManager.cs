using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Quan ly toan bo game, ve scoring, UI...
public class GameManager : MonoBehaviour
{
    private Player player;
    public Spawner spawner;
    public TreeSpawner fronttreespawner;
    public TreeSpawner backtreespawner;
    //public AudioSource audioSource;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endGameScoreText;
    public float score;
    // public Button Retry;
    // public Button Home;
    // public Button Exit;
    // public Image Title;
    AudioManager audioManager;
    public GameObject WaterReflect;
    public GameObject EndGameMenu;
    public static GameManager Instance { get; private set; } 
    //get cho quyen access tu moi nguon, nhung private set chi cho class nay duoc tuy chinh
    public float gameSpeed { get; private set; } 
    public float initialGameSpeed = 5f;
    public float gameSpeedChange = 0.1f;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (Instance == null) Instance = this;
        else DestroyImmediate(gameObject);
    }
    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }
    private void Start()
    {
        //Khi bat dau, assign cac bien voi cac doi tuong trong game (player, obstacle, va cay) = ham find object of type
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        fronttreespawner = FindObjectOfType<TreeSpawner>();
        NewGame();
    }
    static public bool speedPotionTrigger = false;
    static public bool diamondTrigger = false;
    private void Update()
    {
        if (speedPotionTrigger)
        { 
            gameSpeed -= 0.7f;
            AudioSpeed.audioManager.musicSource.pitch -=0.05f;
            AudioSpeed.audioManager.SFXSource.pitch -=0.05f;
        }
        speedPotionTrigger = false;
        gameSpeed = gameSpeed + gameSpeedChange * Time.deltaTime;
        if (diamondTrigger) score += 200;
        diamondTrigger = false;
        score += gameSpeed  * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }
    public void NewGame()
    {
        audioManager.PlaySFX(audioManager.start);
        score = 0;
        HealthManager.health = 3;
        MovingAfterSpawning[] obstacles = FindObjectsOfType<MovingAfterSpawning>();
        foreach (var obs in obstacles)
            {
                Destroy(obs.gameObject);
            }
        gameSpeed = initialGameSpeed;
        enabled = true;
        //player.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        fronttreespawner.gameObject.SetActive(true);
        WaterReflect.gameObject.SetActive(false);
        WaterReflect.gameObject.SetActive(true);
        backtreespawner.gameObject.SetActive(true);
        endGameScoreText.gameObject.SetActive(false);
        audioManager.musicSource.gameObject.SetActive(true);
        // Retry.gameObject.SetActive(false);
        // Home.gameObject.SetActive(false);
        // Exit.gameObject.SetActive(false);
        // Title.gameObject.SetActive(false);
        EndGameMenu.gameObject.SetActive(false);
    }
    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;
        //audioSource.Stop();
        endGameScoreText.gameObject.SetActive(true);
        endGameScoreText.text = Mathf.FloorToInt(score).ToString("D5");
        // Title.gameObject.SetActive(true);
        // Retry.gameObject.SetActive(true);
        // Home.gameObject.SetActive(true);
        // Exit.gameObject.SetActive(true);
        EndGameMenu.gameObject.SetActive(true);
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        fronttreespawner.gameObject.SetActive(false);
        backtreespawner.gameObject.SetActive(false);
        audioManager.musicSource.gameObject.SetActive(false);
        //WaterReflect.gameObject.SetActive(false);
    }
}
