using UnityEngine;
//Quan ly toan bo game, ve scoring, UI...
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } 
    //get cho quyen access tu moi nguon, nhung private set chi cho class nay duoc tuy chinh
    public float gameSpeed { get; private set; } 
    public float initialGameSpeed = 5f;
    public float gameSpeedChange = 0.1f;
    private void Awake()
        {
            if (Instance == null) Instance = this;
            else DestroyImmediate(gameObject);
        }
    private void OnDestroy()
        {
            if (Instance == this) Instance = null;
        }
    private void NewGame()
        {
            gameSpeed = initialGameSpeed;
        }
    private void Start()
        {
            NewGame();
        }
    void Update()
        {
            gameSpeed = gameSpeed + gameSpeedChange * Time.deltaTime;
        }
}
