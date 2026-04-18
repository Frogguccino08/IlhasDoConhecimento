using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecompensaPerso : MonoBehaviour
{
    public Image img;
    public TMP_Text nome;
    public int NumBoneco;

    public void ArrumarBoneco()
    {
        img.sprite = PersonagemSelecionado.instance.persos[NumBoneco].imgMenu;
        nome.text = PersonagemSelecionado.instance.persos[NumBoneco].nome;
    }
}
