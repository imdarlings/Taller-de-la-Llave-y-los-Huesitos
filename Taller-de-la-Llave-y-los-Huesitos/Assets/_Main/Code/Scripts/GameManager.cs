using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager uiManager;

    private bool tiempoActivo = true;
    private bool juegoTerminado = false;

    [Header("Valores del juego")]
    [SerializeField] private int Huesitos;
    [SerializeField] private int Vidas = 3;
    [SerializeField] private float Tiempo = 60f;
    public int Llave = 0;

    [Header("Obstáculo")]
    [SerializeField] private GameObject ObstaculoLlave;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("GameManager iniciado");

        // Reasignar UIManager si no existe (por si la escena cambió)
        if (uiManager == null)
        {
            uiManager = Object.FindFirstObjectByType<UIManager>();
            if (uiManager != null)
                Debug.Log("UIManager reconectado automáticamente.");
            else
                Debug.LogError("UIManager no encontrado en la escena.");
        }

        ActualizarUIInicial();
    }

    private void ActualizarUIInicial()
    {
        if (uiManager != null)
        {
            uiManager.ActualizarPuntos(Huesitos);
            uiManager.ActualizarVidas(Vidas);
            uiManager.ActualizarTiempo(Tiempo);
            uiManager.ActualizarLlave(Llave == 1);
        }
    }

    private void Update()
    {
        if (!tiempoActivo || juegoTerminado) return;

        Tiempo -= Time.deltaTime;
        if (Tiempo <= 0)
        {
            Tiempo = 0;
            PerderJuego("¡PERDISTE!");
        }
        uiManager?.ActualizarTiempo(Tiempo);
    }

    public void RecolectarHuesito()
    {
        if (juegoTerminado) return;
        Huesitos++;
        if (Huesitos >= 10 && ObstaculoLlave != null)
        {
            ObstaculoLlave.SetActive(false);
        }
        uiManager?.ActualizarPuntos(Huesitos);
    }

    public void RecolectarMuslitoNaranja(int vidaExtra = 1)
    {
        if (juegoTerminado) return;
        Vidas += vidaExtra;
        uiManager?.ActualizarVidas(Vidas);
    }

    public void PerderVida(int daño = 1)
    {
        if (juegoTerminado) return;
        Vidas -= daño;
        uiManager?.ActualizarVidas(Vidas);

        if (Vidas <= 0)
        {
            Vidas = 0;
            PerderJuego("¡PERDISTE!");
        }
    }

    public void RecolectarMuslitoAzul(float tiempoExtra = 10f)
    {
        if (juegoTerminado) return;
        Tiempo += tiempoExtra;
        uiManager?.ActualizarTiempo(Tiempo);
    }

    public void RecolectarLlave()
    {
        if (juegoTerminado) return;
        if (Huesitos >= 10)
        {
            Llave = 1;
            ObstaculoLlave?.SetActive(false);
            uiManager?.ActualizarLlave(true);
        }
    }

    public void GanarJuego()
    {
        if (juegoTerminado) return;

        juegoTerminado = true;
        tiempoActivo = false;
        Time.timeScale = 0f;

        Debug.Log("¡GANASTE!");
        uiManager?.MostrarVictoria();
    }

    public void PerderJuego(string razon = "¡PERDISTE!")
    {
        if (juegoTerminado) return;

        juegoTerminado = true;
        tiempoActivo = false;
        Time.timeScale = 0f;

        Debug.Log(razon);
        uiManager?.MostrarDerrota(razon);

        StartCoroutine(ReiniciarDespues(5f));
    }

    private IEnumerator ReiniciarDespues(float segundos)
    {
        yield return new WaitForSecondsRealtime(segundos);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        juegoTerminado = false;
    }

    public void EstadoDelJuego(string estado)
    {
        switch (estado)
        {
            case "Ganar":
                GanarJuego();
                break;
            case "Perder":
                PerderJuego();
                break;
            case "Play":
                Time.timeScale = 1f;
                break;
            case "Pausa":
                Time.timeScale = 0f;
                break;
            default:
                Debug.LogWarning("Estado desconocido: " + estado);
                break;
        }
    }
}
