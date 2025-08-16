using TMPro;
using UnityEngine;

public class Persopequeno : MonoBehaviour
{
    public TMP_Text nome;
    public GameObject material;
    public TMP_Text materialTxt;

    public PCsSO pc;

    GameObject canva;
    PersonagemSelecionado perso;
    public GameObject descCompleta;

    void Start()
    {
        perso = PersonagemSelecionado.instance;
        canva = GameObject.Find("Canvas");
        descCompleta = canva.GetComponent<TelaSelecao>().descCompleta;
    }

    public void OnClickPequeno()
    {
        perso.perso = pc;
        canva.SetActive(false);
        descCompleta.SetActive(true);
        descCompleta.GetComponent<PersoGrande>().ColocarPersonagem();
    }
}
