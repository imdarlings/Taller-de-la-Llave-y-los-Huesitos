using UnityEngine;

public class Puerta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager gameManager = FindFirstObjectByType<GameManager>();

            if (gameManager != null)
            {
                // Cambiado: comprobar si el jugador tiene la llave usando la propiedad 'Llave'
                if (gameManager.Llave > 0)
                {
                    GameManager.instance.GanarJuego();
                }
            }
        }
    }
}