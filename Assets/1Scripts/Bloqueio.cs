using TMPro;
using UnityEngine;

public class Bloqueio : MonoBehaviour
{
    //Chamados de outro objeto
    public TMP_Text texto;
    public Player player;
    public Enemy enemy;

    //Variáveis que precisa
    public int TuOuOutro;


    //Função que escreve a quantidade de escudo que o personagem tem na tela
    void Update()
    {
        if (TuOuOutro == 0)
        {
            texto.text = player.efeitosAtivos[1].ToString();
        }
        else if (TuOuOutro == 1)
        {
            texto.text = enemy.efeitosAtivos[1].ToString();
        }
    }
}
