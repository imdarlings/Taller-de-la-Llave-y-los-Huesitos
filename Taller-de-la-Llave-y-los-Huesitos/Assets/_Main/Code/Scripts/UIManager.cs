using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Contadores UI")]
    [SerializeField] private TextMeshProUGUI huesitosText;
    [SerializeField] private TextMeshProUGUI tiempoText;
    [SerializeField] private TextMeshProUGUI llaveText;
    [SerializeField] private Image llaveIcono;

    [Header("Corazones")]
    [SerializeField] private Image[] corazones;
    [SerializeField] private Sprite corazonLleno;
    [SerializeField] private Sprite corazonVacio;

    [Header("Paneles")]
    [SerializeField] private GameObject panelVictoria;
    [SerializeField] private GameObject panelDerrota;

    public void ActualizarPuntos(int cantidad)
    {
        huesitosText.text = $"{cantidad}";
    }

    public void ActualizarTiempo(float tiempo)
    {
        int segundos = Mathf.CeilToInt(tiempo);
        tiempoText.text = $"{segundos}s";
    }

    public void ActualizarVidas(int vidas)
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].sprite = (i < vidas) ? corazonLleno : corazonVacio;
        }
    }

    public void ActualizarLlave(bool tieneLlave)
    {
        llaveText.text = tieneLlave ? "Sí" : "No";
        llaveIcono.enabled = tieneLlave;
    }

    public void MostrarVictoria()
    {
        panelVictoria.SetActive(true);
    }

    public void MostrarDerrota(string mensaje)
    {
        panelDerrota.SetActive(true);
    }
}
