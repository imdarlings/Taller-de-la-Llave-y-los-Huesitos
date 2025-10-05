using UnityEngine;

public class Trampa : MonoBehaviour
{
    public int da�o = 1;
    private GameManager gameManager;

    [SerializeField]
    void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (gameManager != null)
            gameManager.PerderVida(da�o);
    }
}