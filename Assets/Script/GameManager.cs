using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public Image gemaUI;               // la Image del Canvas
    public Sprite gemaSinColor;        // estado con 0 trozos
    public Sprite[] etapas;            // 8 sprites: gema 1 de 8 ... gema 8 de 8
    public GameObject gemaFlotante;
    [Header("Config")]
    public int totalTrozos = 8;

    private int trozosRecogidos = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ActualizarImagen();
    }

    public void RecogerTrozo()
    {
        if (trozosRecogidos >= totalTrozos) return;

        trozosRecogidos++;
        ActualizarImagen();
        if (trozosRecogidos >= totalTrozos)
        {
            if (gemaFlotante != null)
                gemaFlotante.SetActive(true);
        }
    }

    void ActualizarImagen()
    {
        if (trozosRecogidos == 0)
            gemaUI.sprite = gemaSinColor;
        else
            gemaUI.sprite = etapas[trozosRecogidos - 1];
    }

    public bool TieneTodos()
    {
        return trozosRecogidos >= totalTrozos;
    }


}