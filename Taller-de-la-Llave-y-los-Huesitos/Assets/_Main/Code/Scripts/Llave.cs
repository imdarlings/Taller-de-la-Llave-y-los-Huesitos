using UnityEngine;

public class Llave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Contador contador = FindFirstObjectByType<Contador>();
            if (contador != null)
            {
                contador.RecolectarLlave();
            }
            Destroy(gameObject); // desaparece la llave al recogerla
        }
    }
}