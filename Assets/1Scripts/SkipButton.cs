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
        //Ao clicar o ataque
        control.player.list.AtaquesComEfeitos(true, (control.escolha.regiao + 1) * -1, 0, control.player, control.enemy);

        for (int i = 0; i < 6; i++)
        {
            if (control.player.isPassive[i] == true)
            {
                control.player.list.AtaquesComEfeitos(true, control.player.attackID[i], 0, control.player, control.enemy);
            }
        }

        for (int i = 0; i < 6; i++)
        {
            if (control.enemy.isPassive[i] == true)
            {
                control.enemy.list.AtaquesComEfeitos(false, control.enemy.attackID[i], 1, control.player, control.enemy);
            }
        }

        //Função quando acaba o turno
        

        control.pulouTurno = true;
        text.text = "Player pulou turno";
        StartCoroutine(control.Turno(false));
        control.turno++;

        control.pontosRodada += 5;
        control.textoArea.text = "Pontuação:\n " + control.pontosRodada;

        if (control.pontosRodada > control.escolha.pontos)
        {
            control.pontMax.text = "Pontuação Máxima: " + control.pontosRodada;
        }
    }
}
