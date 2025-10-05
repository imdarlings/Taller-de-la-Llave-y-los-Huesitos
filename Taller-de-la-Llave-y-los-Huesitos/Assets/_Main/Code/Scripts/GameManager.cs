using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UIManager uiManager;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

         DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        Debug.Log("GameManager iniciado");

        if (uiManager != null)
        {
            uiManager.ActualizarPuntos(Huesitos);
            uiManager.ActualizarVidas(Vidas);
            uiManager.ActualizarTiempo(Tiempo);
            uiManager.ActualizarLlave(false);
        }

        else
        {
            Debug.LogError("No se encontro el UIManager en la escena");
}
    }

   

    [Header("Valores del juego")]
    [SerializeField] private int Huesitos;
    [SerializeField] private int Vidas = 3; // vida inicial
    [SerializeField] private float Tiempo = 60f; // tiempo inicial en segundos
    private bool tiempoActivo = true;
    [SerializeField] private int Llave = 0; // 0 = no tiene llave, 1 = tiene llave

    [Header("Obstáculo")]
    [SerializeField] private GameObject ObstaculoLlave;

   
    void Update()
    {
        if (tiempoActivo)
        {
            Tiempo -= Time.deltaTime;
            if (Tiempo <= 0)
            {
                Tiempo = 0;
                tiempoActivo = false;
                uiManager.MostrarDerrota("¡PERDISTE!"); // Llama al UIManager para manejar la derrota
            }
            uiManager.ActualizarTiempo(Tiempo);
        }
    }

    public void RecolectarHuesito()
    {
        Huesitos++;
        if (Huesitos >= 10 && ObstaculoLlave != null)
        {
            ObstaculoLlave.SetActive(false); // Elimina el obstáculo
        }
        uiManager.ActualizarPuntos(Huesitos);
    }

    public void RecolectarMuslitoNaranja(int vidaExtra = 1)
    {
        Vidas += vidaExtra;
        uiManager.ActualizarVidas(Vidas);
    }

    public void PerderVida(int daño = 1)
    {
        Vidas -= daño;
        if (Vidas <= 0)
        {
            Vidas = 0;
            tiempoActivo = false;
            uiManager.MostrarDerrota("¡PERDISTE!");
        }
        uiManager.ActualizarVidas(Vidas);
    }


    public void RecolectarMuslitoAzul(float tiempoExtra = 10f)
    {
        Tiempo += tiempoExtra;
        uiManager.ActualizarTiempo(Tiempo);
    } // <-- Se añadió el punto y coma y la llave de cierre

    public void RecolectarLlave()
    {
        if (Huesitos >= 10)
        {
            ObstaculoLlave.SetActive(false); // Elimina el obstáculo
            Llave = 1;
            uiManager.ActualizarLlave(true);
        }
    }

    public bool TieneLlave()
    {
        return Llave == 1;
    }

    public void EstadoDelJuego(string estado)
    {
        switch (estado)
        {
            case "Ganar":
                uiManager.MostrarVictoria();
                break;
            case "Perder":
                uiManager.MostrarDerrota("¡PERDISTE!");
                break;
            case "Play":
                Time.timeScale = 1;
                break;
            case "Pausa":
                Time.timeScale = 0;
                break;
            default:
                Debug.LogWarning("Estado del juego desconocido: " + estado);
                break;
        }
    }

    internal void RecolectarHuesito(object huesitos)
    {
        throw new NotImplementedException();
    }
}

