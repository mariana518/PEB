using UnityEngine;

public class CAM_Movement : MonoBehaviour
{

    public float SpeedCamara = 3f;
    public float OffSet;
    public Transform Personaje;
    public bool seguir = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            seguir = !seguir;
        }
        if (seguir && Personaje != null)
        {

            Vector3 NuevaPos = new Vector3(Personaje.position.x, Personaje.position.y + OffSet, -15f);
            transform.position = Vector3.Slerp(transform.position, NuevaPos, SpeedCamara = Time.deltaTime);
        }
    }
}
