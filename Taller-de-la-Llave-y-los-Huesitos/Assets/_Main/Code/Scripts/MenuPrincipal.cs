using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private TMP_InputField inputEdad;
    [SerializeField] private GameObject panelEdad;
    [SerializeField] private GameObject panelInicio;

    public void ValidarEdad()
    {
        if (int.TryParse(inputEdad.text, out int edad))
        {
            if (edad >= 0 && edad <= 100)
            {
                panelEdad.SetActive(false);
                panelInicio.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Edad fuera del rango válido.");
            }
        }
        else
        {
            Debug.LogWarning("Por favor ingresa una edad válida.");
        }
    }

    public void Jugar()
    {
        SceneManager.LoadScene("MUNDO"); 
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Cerrando juego...");
    }
}
