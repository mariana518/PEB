using UnityEngine;

public class Cámara : MonoBehaviour
{
    public float SpeedCamara = 3f;
    public float OffSet = 0f;
    public Transform Personaje;
    public bool seguir = true;

    [Header("Tamaño del Zoom (Más pequeño = Más cerca)")]
    public float tamañoZoom = 5f; // Cambia este número en el Inspector (prueba con 3 o 4)

    void Start()
    {
        // Esto cambia automáticamente el Size de la cámara al iniciar
        GetComponent<Camera>().orthographicSize = tamañoZoom;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            seguir = !seguir;
        }
    }

    void LateUpdate()
    {
        if (seguir && Personaje != null)
        {
            Vector3 NuevaPos = new Vector3(Personaje.position.x, Personaje.position.y + OffSet, -10f);
            transform.position = Vector3.Lerp(transform.position, NuevaPos, SpeedCamara * Time.deltaTime);
        }
    }
}