using UnityEngine;

public class HuesitoPuntos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Huesito recogido! Sumar puntos.");
            Destroy(gameObject); // Destruye el huesito después de recogerlo
        }
    }
}
