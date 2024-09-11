using UnityEngine;

public class MovingAfterSpawning : MonoBehaviour
{
    private float leftEdge;
    private void Start()
        {
            leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 3f;
        }
    private void Update()
        {
            transform.position = transform.position + Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;
            if (transform.position.x < leftEdge) Destroy(gameObject);
        }
}
