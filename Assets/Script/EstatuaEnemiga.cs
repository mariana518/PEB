using UnityEngine;

public class EstatuaEnemiga : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject bolaPrefab;
    public Transform puntoDisparo;
    public float tiempoEntreDisparos = 2f;

    [Header("Detección")]
    public float rangoDeteccion = 8f;

    private Transform jugador;
    private float temporizador = 0f;
    private float relojDebug = 0f;

    void Start()
    {
        Debug.Log(name + ": EstatuaEnemiga arrancó");

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) jugador = p.transform;
        else Debug.LogError(name + ": NO encontré ningún objeto con tag Player");

        if (bolaPrefab == null)
            Debug.LogError(name + ": Bola Prefab está VACÍO");
        else
        {
            if (bolaPrefab.scene.IsValid())
                Debug.LogError(name + ": Bola Prefab es un objeto de la ESCENA, arrastra el prefab desde el Project");
            if (bolaPrefab.GetComponent<BolaCemento>() == null)
                Debug.LogError(name + ": el prefab de la bola NO tiene el script BolaCemento");
            if (bolaPrefab.GetComponent<Rigidbody2D>() == null)
                Debug.LogError(name + ": el prefab de la bola NO tiene Rigidbody2D");
        }
    }

    void Update()
    {
        if (jugador == null || bolaPrefab == null) return;

        float distancia = Vector2.Distance(transform.position, jugador.position);

        // Cada segundo te dice qué tan lejos estás
        relojDebug += Time.deltaTime;
        if (relojDebug >= 1f)
        {
            Debug.Log(name + ": distancia al jugador = " + distancia.ToString("F1") + " (rango " + rangoDeteccion + ")");
            relojDebug = 0f;
        }

        if (distancia <= rangoDeteccion)
        {
            temporizador += Time.deltaTime;
            if (temporizador >= tiempoEntreDisparos)
            {
                Disparar();
                temporizador = 0f;
            }
        }
        else
        {
            temporizador = tiempoEntreDisparos;
        }
    }

    void Disparar()
    {
        Vector3 origen = puntoDisparo != null ? puntoDisparo.position : transform.position;
        Vector2 direccion = jugador.position - origen;

        GameObject bola = Instantiate(bolaPrefab, origen, Quaternion.identity);
        bola.GetComponent<BolaCemento>().Lanzar(direccion);

        Debug.Log(name + " DISPARÓ desde " + origen);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}