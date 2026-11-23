using UnityEngine;
using TMPro;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int piedrasRecolectadas = 0;
 
    public TextMeshProUGUI textoContador;

    void Start()
    {
        ActualizarTexto();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gema"))
        {
            GameManager.Instance.RecogerTrozo();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("piedra"))
        {
            piedrasRecolectadas++;
            Destroy(other.gameObject);

            ActualizarTexto();

           
        }
    }
    public bool GastarPiedras(int cantidad)
    {
        if (piedrasRecolectadas < cantidad) return false;

        piedrasRecolectadas -= cantidad;
        ActualizarTexto();
        return true;
    }

    void ActualizarTexto()
    {
        if (textoContador != null)
        {
            textoContador.text =piedrasRecolectadas + "/3";
        }
    }
}
