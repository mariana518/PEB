using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
   public int gemasRecogidas = 0; // Contador de gemas recogidas
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gema"))
        {
            gemasRecogidas++; 
            Destroy(other.gameObject); // Destruye la gema recogida
            Debug.Log("Gemas recogidas: " + gemasRecogidas); // Muestra el contador en la consola
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
