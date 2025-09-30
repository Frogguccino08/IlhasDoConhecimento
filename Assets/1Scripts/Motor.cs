using TMPro;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public TMP_Text[] pontos = new TMP_Text[2];

    void Start()
    {
        ColocarPontos();
    }

    public void ColocarPontos()
    {
        pontos[0].text = "Recorde do Modo História: " + PersonagemSelecionado.instance.maxHistoria;
        pontos[1].text = "Recorde do Modo Rush: " + PersonagemSelecionado.instance.maxRush;
    }
}
