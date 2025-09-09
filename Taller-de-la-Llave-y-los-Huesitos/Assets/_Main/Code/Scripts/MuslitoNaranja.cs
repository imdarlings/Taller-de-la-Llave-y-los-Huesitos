using UnityEngine;

public class MuslitoNaranja : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Muslito Naranja recogido! Sumar vida.");
            Destroy(gameObject); // Destruye el muslito después de recogerlo
        }
    }
}
