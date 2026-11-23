using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class InicioStonebound : MonoBehaviour
{
    [SerializeField] private GameObject menuInicio;
    [SerializeField] private GameObject menuOpciones;
    [SerializeField] private GameObject pantallaEspera;
    [SerializeField] private string escenaJuego = "Nivel";
    [SerializeField, Min(0f)] private float segundosMinimos = 5f;

    private bool cargando;

    private void Awake()
    {
        if (menuInicio != null)
            menuInicio.SetActive(true);
        if (menuOpciones != null)
            menuOpciones.SetActive(false);
        if (pantallaEspera != null)
            pantallaEspera.SetActive(false);
    }

    public void AbrirOpciones()
    {
        if (cargando || menuOpciones == null)
            return;

        menuInicio.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void CerrarOpciones()
    {
        menuOpciones.SetActive(false);
        menuInicio.SetActive(true);
    }

    public void Jugar()
    {
        if (cargando)
            return;

        if (menuInicio == null || pantallaEspera == null ||
            string.IsNullOrWhiteSpace(escenaJuego) ||
            !Application.CanStreamedLevelBeLoaded(escenaJuego))
        {
            Debug.LogError("Revisa los paneles del Canvas y la escena de juego en Build Profiles.", this);
            return;
        }

        cargando = true;
        menuInicio.SetActive(false);
        pantallaEspera.SetActive(true);
        StartCoroutine(CargarNivel());
    }

    private IEnumerator CargarNivel()
    {
        // Deja que Unity dibuje la pantalla antes de iniciar la carga.
        yield return null;

        float activarDesde = Time.unscaledTime + segundosMinimos;
        AsyncOperation carga = SceneManager.LoadSceneAsync(escenaJuego, LoadSceneMode.Single);
        carga.allowSceneActivation = false;

        while (carga.progress < 0.9f || Time.unscaledTime < activarDesde)
            yield return null;

        carga.allowSceneActivation = true;
    }

    public void Salir()
    {
        Application.Quit();
    }
}
