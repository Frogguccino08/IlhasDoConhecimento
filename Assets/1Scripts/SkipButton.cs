using TMPro;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    public Controle control;
    public TMP_Text text;

    public void Onclick()
    {
        text.text = "Player pulou turno";
        StartCoroutine(control.Turno(false));
        control.turno ++;

        control.pontosRodada += 50;
        control.textoArea.text = "Pontuação:\n " + control.pontosRodada;
    }
}
