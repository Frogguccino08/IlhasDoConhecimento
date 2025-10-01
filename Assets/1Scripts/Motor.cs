using TMPro;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public TMP_Text[] pontos = new TMP_Text[2];
    public GameObject[] materiais = new GameObject[6];

    void Start()
    {
        ColocarPontos();
        Materiais();
    }

    public void ColocarPontos()
    {
        pontos[0].text = "Recorde do Modo História: " + PersonagemSelecionado.instance.maxHistoria;
        pontos[1].text = "Recorde do Modo Rush: " + PersonagemSelecionado.instance.maxRush;
    }

    public void Materiais()
    {
        for (int i = 0; i < 6; i++)
        {
            materiais[i].GetComponent<MaterialGanho>().Ajustes(i, PersonagemSelecionado.instance.material[i]);
        }
    }
}
