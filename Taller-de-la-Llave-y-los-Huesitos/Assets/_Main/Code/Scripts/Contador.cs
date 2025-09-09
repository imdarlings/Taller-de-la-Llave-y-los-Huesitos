using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Contador : MonoBehaviour
{
    [Header("Contadores")]
    [SerializeField] private int _Huesitos;
    [SerializeField] private int _MuslitosNaranjas = 3; // vida inicial
    [SerializeField] private float _Tiempo = 60f; // tiempo inicial en segundos
    private bool tiempoActivo = true;
    [SerializeField] private int _Llave = 0; // 0 = no tiene llave, 1 = tiene llave

    [Header("Referencias UI")]
    [SerializeField] private TextMeshProUGUI huesitosText;
    [SerializeField] private TextMeshProUGUI muslitosNaranjasText;
    [SerializeField] private TextMeshProUGUI tiempoText;
    [SerializeField] private TextMeshProUGUI llaveText;

    [Header("Obstáculo")]
    [SerializeField] private GameObject ObstaculoLlave;

    public int MuslitosNaranjas { get => _MuslitosNaranjas; set => _MuslitosNaranjas = value; }

    void Start()
    {
        ActualizarUI();
    }

    void Update()
    {
        if (tiempoActivo)
        {
            _Tiempo -= Time.deltaTime;
            if (_Tiempo <= 0)
            {
                _Tiempo = 0;
                tiempoActivo = false;
                GameManager.instance.PerderJuego("GAME OVER"); // Llama al GameManager para manejar la derrota
            }
            ActualizarUI();
        }
    }

    public void RecolectarHuesito()
    {
        _Huesitos++;
        if (_Huesitos >= 10 && ObstaculoLlave != null)
        {
            ObstaculoLlave.SetActive(false); // Elimina el obstáculo
        }
        ActualizarUI();
    }

    public void RecolectarMuslitoNaranja(int vidaExtra = 1)
    {
        MuslitosNaranjas += vidaExtra;
        ActualizarUI();
    }

    public void PerderVida(int daño = 1)
    {
        MuslitosNaranjas -= daño;
        if (MuslitosNaranjas <= 0)
        {
            MuslitosNaranjas = 0;
            tiempoActivo = false;
            GameManager.instance.PerderJuego("GAME OVER");
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


    private void ActualizarUI()
    {
        huesitosText.text = $"Huesitos: {_Huesitos}";
        muslitosNaranjasText.text = $"Vida: {MuslitosNaranjas}";

        int segundos = Mathf.CeilToInt(_Tiempo);
        tiempoText.text = $"Tiempo: {segundos}";

        llaveText.text = $"Llave: {(_Llave == 1 ? "Sí" : "No")}";
    }
}