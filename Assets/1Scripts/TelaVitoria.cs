using TMPro;
using UnityEngine;

public class TelaVitoria : MonoBehaviour
{
    public TMP_Text texto;

    public void ColocarNome()
    {
        texto.text = "Você chegou ao final da história como " + PersonagemSelecionado.instance.perso.nome + ".";
    }
}
