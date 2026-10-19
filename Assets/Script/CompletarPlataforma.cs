using UnityEngine;

public class CompletarPlataforma : MonoBehaviour
{
    public GameObject plataformaCompleta; // Arrastra aquí la plataforma completa en el Inspector

    public void ActivarPlataformaCompleta()
    {
        if (plataformaCompleta != null)
        {
            plataformaCompleta.SetActive(true); // Activa la plataforma completa
        }

        gameObject.SetActive(false); // Desactiva la plataforma blanca
    }
}
