using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private TMP_InputField inputEdad;
    [SerializeField] private GameObject panelEdad;
    [SerializeField] private GameObject panelInicio;

    private void Start()
    {
        if (PlayerPrefs.GetInt("EdadRegistrada", 0) == 1)
        {
            panelEdad.SetActive(false);
            panelInicio.SetActive(true);
        }
        else
        {
            panelEdad.SetActive(true);
            panelInicio.SetActive(false);
        }
    }

    public void ValidarEdad()
    {
        if (int.TryParse(inputEdad.text, out int edad))
        {
            if (edad >= 0 && edad <= 100)
            {
                PlayerPrefs.SetInt("EdadRegistrada", 1);
                PlayerPrefs.SetInt("EdadJugador", edad);
                PlayerPrefs.Save();

                panelEdad.SetActive(false);
                panelInicio.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Edad fuera del rango válido (0 - 100).");
            }
        }
        else
        {
            Debug.LogWarning("Por favor, ingresa una edad válida.");
        }
    }

    public void Jugar()
    {
        SceneManager.LoadScene("MUNDO");
    }

    public void Salir()
    {
        Debug.Log("Cerrando juego...");
        Application.Quit();
    }

    public static void VolverAlMenu()
    {
        PlayerPrefs.SetInt("VolverAlMenu", 1);
        SceneManager.LoadScene("MenuPrincipal");
    }
}
