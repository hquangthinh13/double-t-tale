using UnityEngine;

public class Ground : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float slowerNumb = 1f;
    private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
    void Update()
    {
        float speed = GameManager.Instance.gameSpeed / 48;
        meshRenderer.material.mainTextureOffset = meshRenderer.material.mainTextureOffset + Vector2.right * speed * Time.deltaTime * slowerNumb;
    }
}
