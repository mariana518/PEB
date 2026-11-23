using UnityEngine;
using TMPro;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int piedrasRecolectadas = 0;

    public TextMeshProUGUI textoContador;

    public float vidas = 100f;
    public BarraVida barraVida;
    public GameObject panelMuerte;

    void Start()
    {
        ActualizarTexto();


            if (panelMuerte != null)
                panelMuerte.SetActive(false);
    }
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gema"))
        {
            GameManager.Instance.RecogerTrozo();
            AudioManager.Instance.PlaySFX(AudioManager.Instance.recogerGema);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("piedra"))
        {
            piedrasRecolectadas++;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.recogerPiedra);
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
            textoContador.text = piedrasRecolectadas + "/3";
        }
    }

    public void RecibirDanio(float cantidad)
    {
        if (vidas <= 0) return;   

        vidas -= cantidad;
        if (vidas < 0) vidas = 0;
        Debug.Log("Recibiste daño, Vida: " + vidas);

        if (barraVida != null)
            barraVida.ActualizarBarra(vidas);

        if (vidas <= 0)
            Morir();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.golpeEnemigo);
            RecibirDanio(30);

        }
    }
    void Morir()
    {
        if (panelMuerte != null)
            panelMuerte.SetActive(true);

        Time.timeScale = 0f;  
    }

}
