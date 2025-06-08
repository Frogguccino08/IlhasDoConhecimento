using TMPro;
using UnityEngine;

public class Bloqueio : MonoBehaviour
{
    public int TuOuOutro;
    public TMP_Text texto;
    public Player player;
    public Enemy enemy;

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
