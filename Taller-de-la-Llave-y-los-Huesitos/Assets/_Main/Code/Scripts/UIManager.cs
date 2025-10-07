using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Contadores UI")]
    [SerializeField] private TextMeshProUGUI huesitosText;
    [SerializeField] private TextMeshProUGUI tiempoText;
    [SerializeField] private TextMeshProUGUI llaveText;

    [Header("Corazones (Vidas)")]
    [SerializeField] private Image[] corazones;
    [SerializeField] private Sprite corazonLleno;
    [SerializeField] private Sprite corazonVacio;

    [Header("Paneles de Estado")]
    [SerializeField] private GameObject panelVictoria;
    [SerializeField] private GameObject panelDerrota;

    public void ActualizarPuntos(int cantidad)
    {
        if (huesitosText != null)
            huesitosText.text = $"{cantidad}";
    }

    public void ActualizarTiempo(float tiempo)
    {
        if (tiempoText != null)
        {
            int segundos = Mathf.CeilToInt(tiempo);
            tiempoText.text = $"{segundos}s";
        }
    }

    public void ActualizarVidas(int vidas)
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (corazones[i] != null)
                corazones[i].sprite = (i < vidas) ? corazonLleno : corazonVacio;
        }
    }

    public void ActualizarLlave(bool tieneLlave)
    {
        if (llaveText != null)
            llaveText.text = tieneLlave ? "Sí" : "No";
    }

    public void MostrarVictoria()
    {
        if (panelVictoria != null)
            panelVictoria.SetActive(true);
    }

    public void MostrarDerrota(string mensaje)
    {
        if (panelDerrota != null)
            panelDerrota.SetActive(true);
    }
}
