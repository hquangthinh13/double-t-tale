using UnityEngine;

public class Spawning : MonoBehaviour
{
    [System.Serializable]
    public class SpawnableObj
    {
        public GameObject prefab;
        public float spawnChance; 
    }

    public SpawnableObj[] obstacles;
    public SpawnableObj[] items;
    public SpawnableObj[] fronttrees;
    public SpawnableObj[] backtrees;

    private void Spawn(SpawnableObj[] objects)
    {
        float chance = Random.Range(0f, 1f);
        foreach (var obj in objects)
        {
            if (chance < obj.spawnChance)
            {
                GameObject spawning = Instantiate(obj.prefab);
                break;
            }
            chance -= obj.spawnChance;
        }
        Invoke(nameof(Spawn), Random.Range(1f, 1.8f));
    }
    private float obstacleTimer;
    private float itemTimer;
    private float backtreesTimer;
    private float fronttreesTimer;
    private void Update()
    {
        obstacleTimer -= Time.deltaTime;
        itemTimer -= Time.deltaTime;
        fronttreesTimer -= Time.deltaTime;
        backtreesTimer -= Time.deltaTime;

        if (obstacleTimer <= 0)
        {
            Spawn(obstacles); 
            obstacleTimer = Random.Range(1.5f, 2.5f);
        }
        if (backtreesTimer <= 0)
        {
            Spawn(backtrees); 
            backtreesTimer = Random.Range(1f, 1.7f);
        }
        if (fronttreesTimer <= 0)
        {
            Spawn(fronttrees); 
            fronttreesTimer = Random.Range(1.5f, 2.8f);
        }
        if (itemTimer <= 0)
        {
            Spawn(items); 
            itemTimer = Random.Range(2.0f, 7.0f);
        }
    }
}