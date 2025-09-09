using UnityEngine;

public class MuslitoAzul : MonoBehaviour
{
    public float tiempoExtra = 10f; // puedes cambiarlo desde el inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}