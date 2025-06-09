using TMPro;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    public Controle control;
    public TMP_Text text;

    public void Onclick()
    {
        control.pulouTurno = true;
        text.text = "Player pulou turno";
        StartCoroutine(control.Turno(false));
        control.turno++;

        control.pontosRodada += 50;
        control.textoArea.text = "Pontuação:\n " + control.pontosRodada;
        
        if (control.pontosRodada > control.escolha.pontos)
        {
            control.escolha.pontos = control.pontosRodada;
            control.pontMax.text = "Pontuação Máxima: " + control.escolha.pontos;
        }
    }
}
