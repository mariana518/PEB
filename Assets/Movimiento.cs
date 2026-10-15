using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb;
    private Vector2 movimiento;
    public Animator animator;
    private SpriteRenderer spriteRenderer; // Necesario para voltear el dibujo
    public float fuerzaSalto = 7f;
    private bool enSuelo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtenemos el componente de la imagen
    }

    void Update()
    {
        // Lee tanto la izquierda (A / Flecha Izquierda) como la derecha (D / Flecha Derecha)
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = 0;

        // 1. La animación se enciende si te estás moviendo hacia cualquier lado (diferente de 0)
        bool estaCaminando = movimiento.x != 0;
        animator.SetBool("Derecha", estaCaminando);

        // 2. Voltear el sprite dependiendo de a dónde mires
        if (movimiento.x > 0)
        {
            spriteRenderer.flipX = false; // Mirando normal (derecha)
        }
        else if (movimiento.x < 0)
        {
            spriteRenderer.flipX = true;  // Volteado horizontalmente (izquierda)
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            enSuelo = false; // Desactivamos el salto hasta que vuelva a tocar el piso
        }
    }

    void FixedUpdate()
    {
        // Mueve al personaje libremente a la izquierda o derecha
        rb.linearVelocity = new Vector2(movimiento.x * velocidad, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enSuelo = true; // Al tocar cualquier objeto con colisión (como tu piso), se reinicia el salto
    }
}
