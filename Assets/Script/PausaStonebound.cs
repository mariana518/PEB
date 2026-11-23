using UnityEngine;

public sealed class PausaStonebound : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject botonPausa;

    private bool enPausa;
    private float escalaAnterior;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            AlternarPausa();
    }

    public void AlternarPausa()
    {
        if (enPausa)
        {
            Reanudar();
            return;
        }

        if (Time.timeScale == 0f || menuPausa == null || botonPausa == null)
            return;

        escalaAnterior = Time.timeScale;
        enPausa = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        if (!enPausa)
            return;

        RestaurarTiempo();
        menuPausa.SetActive(false);
        botonPausa.SetActive(true);
    }

    private void OnDisable()
    {
        if (enPausa)
            RestaurarTiempo();
    }

    private void RestaurarTiempo()
    {
        enPausa = false;
        Time.timeScale = escalaAnterior;
    }
}
