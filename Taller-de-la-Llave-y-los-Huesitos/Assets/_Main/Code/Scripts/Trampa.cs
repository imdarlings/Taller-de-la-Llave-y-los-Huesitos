using UnityEngine;

public class Trampa : MonoBehaviour
{
    public int da�o = 1;
    private Contador contador;

    [SerializeField]
    void Awake()
    {
        contador = FindFirstObjectByType<Contador>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (contador != null)
            contador.PerderVida(da�o);
    }
}