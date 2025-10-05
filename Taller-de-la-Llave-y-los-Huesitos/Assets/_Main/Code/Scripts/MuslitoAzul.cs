using UnityEngine;

public class MuslitoAzul : MonoBehaviour
{
    public float tiempoExtra = 10f; // tiempo que suma

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.RecolectarMuslitoAzul(tiempoExtra);
            }
            else
            {
                Debug.LogError("No se encontró GameManager en la escena");
            }

            Destroy(gameObject);
        }
    }
}
