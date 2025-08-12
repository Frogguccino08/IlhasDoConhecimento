using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Variaveis/Objetos de programação que precisa
    public Slider slider;
    public Gradient gradient;

    public Image fill;

    private float max;


    //Função responsável por mudar a quantidade que mostra na barra de vida de acordo com a vida
    public void MudarBarra(float health)
    {
        slider.value = health;
        if (health < (max / 20) && health > 0)
        {
            slider.value = max / 20;
        }
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

    //Função que muda o máximo da barra para o máximo de vida do personagem
    public void MaximoVida(float vidamaxima)
    {
        max = vidamaxima;
        slider.maxValue = vidamaxima;
        fill.color = gradient.Evaluate(1f);
    }
}
