using UnityEngine;

public class HuesitoPuntos : MonoBehaviour
{
    public Contador contador;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            contador.RecolectarHuesito();
            Debug.Log("Huesito recogido! Sumar puntos.");
            Destroy(gameObject); // Destruye el huesito después de recogerlo
        }
    }
}
