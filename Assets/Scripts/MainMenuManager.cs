using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Quan ly toan bo game, ve scoring, UI...
public class MainMenuManager : MonoBehaviour
{
    public Spawner spawner;
    public TreeSpawner treespawn;
    public AudioSource audioSource;

    public static GameManager Instance { get; private set; } 
    //get cho quyen access tu moi nguon, nhung private set chi cho class nay duoc tuy chinh
    public float gameSpeed { get; private set; } 
    public float initialGameSpeed = 5f;
    public float gameSpeedChange = 0.1f;

    private void Start()
        {
            //Khi bat dau, assign cac bien voi cac doi tuong trong game (player, obstacle, va cay) = ham find object of type
            spawner = FindObjectOfType<Spawner>();
            treespawn = FindObjectOfType<TreeSpawner>();
        }
    private void Update()
        {
            gameSpeed = gameSpeed + gameSpeedChange * Time.deltaTime;
        }
}
