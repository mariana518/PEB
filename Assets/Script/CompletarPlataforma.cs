using UnityEngine;

public class CompletarPlataforma : MonoBehaviour
{
    public GameObject plataformaIncompleta;  // la plataforma blanca
    public GameObject plataformaCompleta;    // la oculta
    public int piedrasNecesarias = 3;
    public KeyCode tecla = KeyCode.E;

    private NewMonoBehaviourScript jugador;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jugador = other.GetComponent<NewMonoBehaviourScript>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jugador = null;
    }

    void Update()
    {
        if (jugador != null && Input.GetKeyDown(tecla))
        {
            if (jugador.GastarPiedras(piedrasNecesarias))
            {
                plataformaCompleta.SetActive(true);
                plataformaIncompleta.SetActive(false);
                gameObject.SetActive(false); // esta zona ya no se usa
            }
        }
    }
}
