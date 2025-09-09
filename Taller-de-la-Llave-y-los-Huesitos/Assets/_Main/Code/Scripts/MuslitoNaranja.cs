using UnityEngine;

public class MuslitoNaranja : MonoBehaviour
{
    public Contador contador;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            contador.RecolectarMuslitoNaranja();
            Debug.Log("Muslito Naranja recogido! Sumar vida.");
            Destroy(gameObject); // Destruye el muslito después de recogerlo
        }
    }
}
