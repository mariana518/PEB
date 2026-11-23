using UnityEngine;

public class DesaparecerPlataforma : MonoBehaviour
{
    private float tiempoActivacion;

    private void OnEnable()
    {
       
        tiempoActivacion = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (Time.time - tiempoActivacion < 1f) return;

        if (collision.gameObject.CompareTag("Player"))
        {
     
            gameObject.SetActive(false);
        }
    }
}
