using UnityEngine;

public class Puerta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager gameManager = FindFirstObjectByType<GameManager>();

            if (gameManager != null)
            {
                if (gameManager.TieneLlave())
                {
                    gameManager.uiManager.MostrarVictoria();
                }
            }
        }
    }
}