using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;

    public Image fill;

    public void MudarBarra(float health)
    {
        slider.value = health;
        if(health < 4 && health > 0)
        {
            slider.value = 5;
        }
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

    public void MaximoVida(float vidamaxima)
    {
        slider.maxValue = vidamaxima;
        fill.color = gradient.Evaluate(1f);
    }
}
