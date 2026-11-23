using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    public string SalidaNivel1;  

    private bool jugadorCerca = false;

    void Update()
    {
        if (jugadorCerca && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (GameManager.Instance.TieneTodos())
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SalidaNivel1);
            }
            else
            {
                Debug.Log("puerta cerrada, faltan piezas por recoger");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jugadorCerca = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jugadorCerca = false;
    }
}