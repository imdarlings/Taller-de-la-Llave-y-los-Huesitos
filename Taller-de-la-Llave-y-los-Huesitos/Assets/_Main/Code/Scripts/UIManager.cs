using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI puntosText;
    [SerializeField] private TextMeshProUGUI vidasText;
    [SerializeField] private TextMeshProUGUI tiempoText;
    [SerializeField] private TextMeshProUGUI llaveText;

    [SerializeField] private GameObject panelVictoria;
    [SerializeField] private GameObject panelDerrota;
    [SerializeField] private TMP_Text victoriaText;
    [SerializeField] private TMP_Text derrotaText;
   
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void ActualizarPuntos(int puntos) => puntosText.text = $"Huesitos: {puntos}";
    public void ActualizarVidas(int vidas) => vidasText.text = $"Vidas: {vidas}";
    public void ActualizarTiempo(float tiempo) => tiempoText.text = $"Tiempo: {Mathf.CeilToInt(tiempo)}";
    public void ActualizarLlave(bool tieneLlave) => llaveText.text = $"Llave: {(tieneLlave ? "Sí" : "No")}";

    public void MostrarVictoria()
    {
        panelVictoria.SetActive(true);
    }

    public void MostrarDerrota(string razon)
    {
        panelDerrota.SetActive(true);
        derrotaText.text = razon;
    }
}
