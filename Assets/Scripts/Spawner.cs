using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObj
        {
            public GameObject prefab;
            public float spawnChance; //Spawn chance tu 0-1
        }
    public SpawnableObj[] objects;
    public float respawnTime = 3f;
    public float countdown;
    private void Start()
        {
            countdown = respawnTime;
        }
    private void Spawn()
        {
            float chance = Random.Range(0f,1f);
            foreach (var obj in objects)
                {   
                    if (chance<obj.spawnChance)
                        {
                            GameObject Spawning = Instantiate(obj.prefab);
                            //Spawning.transform.position = Spawning.transform.position + transform.position;
                            break;
                        }
                    chance -= obj.spawnChance;
                }
            Invoke(nameof(Spawn), Random.Range(0f,1f));
        }
    private void OnEnable()
        {
                countdown -= Time.deltaTime;
                if (countdown<=0)
                    {
                    countdown = respawnTime;
                    Invoke(nameof(Spawn), Random.Range(0f,1f));
                    }
        }
    private void OnDisable()
        {
            CancelInvoke();
        }
}
