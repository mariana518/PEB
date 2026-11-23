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

    public CAM_Movement camaraScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = 0;

        
        bool estaCaminando = movimiento.x != 0;
        animator.SetBool("Derecha", estaCaminando);

        
        if (movimiento.x > 0)
        {
            spriteRenderer.flipX = false; 
        }
        else if (movimiento.x < 0)
        {
            spriteRenderer.flipX = true; 
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            enSuelo = false; 
        }
    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2(movimiento.x * velocidad, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enSuelo = true; 
    }
}
