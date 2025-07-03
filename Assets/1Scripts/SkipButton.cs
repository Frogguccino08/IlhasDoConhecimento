using TMPro;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    //Chamado de outros objetos
    public Controle control;
    public TMP_Text text;

    //Função quando clica no botão de pular o seu turno pula o turno, adiciona pontos e inicia o turno inimigo 
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
