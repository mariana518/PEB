using UnityEngine;

public class PlataformaRota : MonoBehaviour
{
    public GameObject objetoCrashed; // Arrastra aquí el objeto "crashed" desde la Jerarquía
    private int vecesPisada = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
         

            vecesPisada++;

            if (vecesPisada == 1)
            {
                // Primer salto: Desaparece "rota" y aparece "crashed"
                gameObject.SetActive(false); // Desactiva la plataforma "rota"

                if (objetoCrashed != null)
                {
                    objetoCrashed.SetActive(true); // Activa la plataforma "crashed"
                }
            }
        }
    }
}
