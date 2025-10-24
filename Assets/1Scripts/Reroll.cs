using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Reroll : MonoBehaviour
{
    public TelaUpgrade[] botoes = new TelaUpgrade[3];
    public TMP_Text texto;
    public Player player;

    public void Update()
    {
        texto.text = "Rerolls: " + player.reroll;

        if(player.reroll == 0)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void Rerolar()
    {
        if(player.reroll > 0)
        {
            player.teveReroll = true;

            for (int i = 0; i < 3; i++)
            {
                player.rerolados[i] = botoes[i].idAtaque;
                botoes[i].FazerAtaques();
            }

            player.reroll -= 1;
        }
    }
}
