using UnityEngine;

public class Cámara : MonoBehaviour
{
    public float SpeedCamara = 3f;
    public float OffSet = 0f;
    public Transform Personaje;
    public bool seguir = true;

    [Header("Tamaño del Zoom (Más pequeño = Más cerca)")]
    public float tamañoZoom = 5f; 

    void Start()
    {

        GetComponent<Camera>().orthographicSize = tamañoZoom;
    }

    void Update()
    {
        if (Time.timeScale == 0f)
            return;

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