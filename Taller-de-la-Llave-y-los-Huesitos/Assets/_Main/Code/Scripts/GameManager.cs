using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    [SerializeField] private GameObject panelVictoria;
    [SerializeField] private TMP_Text victoriaText;

    [SerializeField] private GameObject panelDerrota;
    [SerializeField] private TMP_Text derrotaText;

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

    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GanarJuego(string mensaje)
    {
        if (panelVictoria != null)
        {
            panelVictoria.SetActive(true);
            victoriaText.text = "¡GANASTE!";
        }
        Time.timeScale = 0f; // pausa el juego
    }

    public void PerderJuego(string mensaje)
    {
        if (panelDerrota != null)
        {
            panelDerrota.SetActive(true);
            derrotaText.text = "¡PERDISTE!";
        }
        Time.timeScale = 0f;
        StartCoroutine(ReiniciarDespues(5f)); // Reinicia después de 5 segundos
    }

    private IEnumerator ReiniciarDespues(float segundos)
    {
        yield return new WaitForSecondsRealtime(segundos);
        ReiniciarEscena();
    }

    // Mueve la función EstadoDeJuego dentro de la clase GameManager
    public void EstadoDeJuego(string estado)
    {
        switch (estado)
        {
            case "Play":
                Time.timeScale = 1f; // Reanuda el juego
                if (panelVictoria != null) panelVictoria.SetActive(false);
                if (panelDerrota != null) panelDerrota.SetActive(false);
                if (victoriaText != null) victoriaText.text = "";
                if (derrotaText != null) derrotaText.text = "";
                break;
            case "Pause":
                Time.timeScale = 0f; // Pausa el juego
                break;
            case "Ganar":
                GanarJuego("¡GANASTE!");
                break;
            case "Perder":
                PerderJuego("¡PERDISTE!");
                break;
        }
    }
}