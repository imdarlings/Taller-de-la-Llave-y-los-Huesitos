using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UIManager uiManager;

    [Header("Valores del juego")]
    [SerializeField] private int _Huesitos;
    [SerializeField] private int _Vidas = 3; // vida inicial
    [SerializeField] private float _Tiempo = 60f; // tiempo inicial en segundos
    private bool tiempoActivo = true;
    [SerializeField] private int _Llave = 0; // 0 = no tiene llave, 1 = tiene llave


    [Header("Obstáculo")]
    [SerializeField] private GameObject ObstaculoLlave;

    void Update()
    {
        if (tiempoActivo)
        {
            _Tiempo -= Time.deltaTime;
            if (_Tiempo <= 0)
            {
                _Tiempo = 0;
                tiempoActivo = false;
                UIManager.instance.PanelDerrota ("¡PERDISTE!"); // Llama al GameManager para manejar la derrota
            }
            uiManager.ActualizarTiempo (_Tiempo);
        }
    }

    public void RecolectarHuesito()
    {
        _Huesitos++;
        if (_Huesitos >= 10 && ObstaculoLlave != null)
        {
            ObstaculoLlave.SetActive(false); // Elimina el obstáculo
        }
        uiManager.ActualizarPuntos (_Huesitos);
    }

    public void RecolectarMuslitoNaranja(int vidaExtra = 1)
    {
        MuslitoNaranja += vidaExtra;
        uiManager.ActualizarVidas (_Vidas);
    }

    public void PerderVida(int daño = 1)
    {
        MuslitoNaranja -= daño;
        if (MuslitoNaranja <= 0)
        {
            MuslitoNaranja = 0;
            tiempoActivo = false;
            GameManager.instance.PerderJuego("¡PERDISTE!");
        }
        ActualizarUI();
    }


    public void RecolectarMuslitoAzul(float tiempoExtra = 10f)
    {
        _Tiempo += tiempoExtra;
        ActualizarUI();
    }

    public void RecolectarLlave()
    {
        if (_Huesitos >= 10)
        {
            ObstaculoLlave.SetActive(false); // Elimina el obstáculo
            _Llave = 1;
            ActualizarUI();
        }
    }

    public bool TieneLlave()
    {
        return _Llave == 1;
    }

