using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public float speed = 3f;
    public float distanciaPatrulla = 6f; 

    private Vector2 posicionInicial;
    private int direccion = 1; 

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (animator == null) animator = GetComponent<Animator>();

        // Guardamos dónde empezó el enemigo
        posicionInicial = transform.position;
    }

    void Update()
    {
        
        rb.linearVelocity = new Vector2(speed * direccion, rb.linearVelocity.y);

        // Control de animaciones
        if (direccion == 1)
        {
            animator.SetBool("Derecha", true);
            animator.SetBool("Izquierda", false);
        }
        else
        {
            animator.SetBool("Izquierda", true);
            animator.SetBool("Derecha", false);
        }

        
        if (transform.position.x > posicionInicial.x + distanciaPatrulla)
        {
            direccion = -1;
        }
    
        else if (transform.position.x < posicionInicial.x - distanciaPatrulla)
        {
            direccion = 1;
        }
    }
}
