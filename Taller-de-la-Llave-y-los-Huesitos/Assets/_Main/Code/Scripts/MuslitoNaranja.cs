using UnityEngine;

public class MuslitoNaranja : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.RecolectarMuslitoNaranja();
            }
            else
            {
                Debug.LogError("No se encontró GameManager en la escena");
            }

            Destroy(gameObject);
        }
    }
}
