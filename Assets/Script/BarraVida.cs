using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour

{
    public float vidaMaxima = 100f;
    public Slider slider;
  
    void Start()
    {
        if (slider != null)
        {
            slider.minValue = 0;
            slider.maxValue = vidaMaxima;
            slider.value = vidaMaxima;
        }
    }

    public void ActualizarBarra(float vidaActual)
    {
        if (slider != null)
            slider.value = vidaActual;
    }

    void Update()
    {

    }
}

