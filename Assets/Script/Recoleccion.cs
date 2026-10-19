using UnityEngine;
using TMPro;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public int piedrasRecolectadas = 0;
    public CompletarPlataforma scriptPlataforma;
    public TextMeshProUGUI textoContador;
    public int gemasRecogidas = 0; // Contador de gemas recogidas
    void Start()
    {
        ActualizarTexto();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gema"))
        {
            gemasRecogidas++;
            Destroy(other.gameObject); // Destruye la gema recogida
            Debug.Log("Gemas recogidas: " + gemasRecogidas); // Muestra el contador en la consola
        }
        if (other.CompareTag("piedra"))
        {
            piedrasRecolectadas++;
            Destroy(other.gameObject);

            ActualizarTexto(); // Actualiza el número en la pantalla

            if (piedrasRecolectadas >= 3)
            {
                if (scriptPlataforma != null)
                {
                    scriptPlataforma.ActivarPlataformaCompleta();
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
        void ActualizarTexto()
        {
            if (textoContador != null)
            {
                textoContador.text = "Piedras: " + piedrasRecolectadas + "/3";
            }
        }
    }
