using UnityEngine;

public class DesaparecerPlataforma : MonoBehaviour
{
    private float tiempoActivacion;

    private void OnEnable()
    {
        // Guardamos el momento exacto en que aparece la plataforma
        tiempoActivacion = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignoramos cualquier colisión durante los primeros 0.2 segundos de haber aparecido
        if (Time.time - tiempoActivacion < 1f) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            // Segundo salto: Desaparece "crashed" y el personaje cae
            gameObject.SetActive(false);
        }
    }
}
