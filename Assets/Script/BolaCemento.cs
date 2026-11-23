using UnityEngine;

public class BolaCemento : MonoBehaviour
{
    public float velocidad = 6f;
    public float danio = 10f;
    public float tiempoVida = 4f; 

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

   
    public void Lanzar(Vector2 direccion)
    {
        rb.linearVelocity = direccion.normalized * velocidad;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.golpeBola);

            var jugador = other.GetComponent<NewMonoBehaviourScript>();
            if (jugador != null)
                jugador.RecibirDanio(danio);

            Destroy(gameObject);
        }
    }
}