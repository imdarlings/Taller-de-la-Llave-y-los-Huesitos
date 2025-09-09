using UnityEngine;

public class MuslitoAzul : MonoBehaviour
{
    public Contador contador;
    public float tiempoExtra = 10f; // puedes cambiarlo desde el inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            contador.RecolectarMuslitoAzul(tiempoExtra);
            Destroy(gameObject);
        }
    }
}