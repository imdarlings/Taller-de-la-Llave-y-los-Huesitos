using UnityEngine;

public class Puerta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Buscar el contador en la escena
            Contador contador = FindFirstObjectByType<Contador>();

            if (contador != null)
            {
                // Solo gana si tiene la llave
                if (contador.TieneLlave())
                {
                    GameManager.instance.GanarJuego();
                }
            }
        }
    }
}