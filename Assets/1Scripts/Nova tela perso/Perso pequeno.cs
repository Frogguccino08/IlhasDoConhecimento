using TMPro;
using UnityEngine;

public class Persopequeno : MonoBehaviour
{
    public GameObject personagem;
    public TMP_Text nome;
    public GameObject material;
    public TMP_Text materialTxt;

    public PCsSO pc;

    GameObject canva;
    PersonagemSelecionado perso;
    public GameObject descCompleta;

    void Awake()
    {
        perso = PersonagemSelecionado.instance;
    }

    void Start()
    {
        canva = GameObject.Find("Canvas");
        descCompleta = canva.GetComponent<TelaSelecao>().descCompleta;
    }

    public void OnClickPequeno()
    {
        perso.perso = pc;
        if (perso.unlock[perso.perso.id] == true)
        {
        canva.SetActive(false);
        descCompleta.SetActive(true);
        descCompleta.GetComponent<PersoGrande>().ColocarPersonagem();
        }
    }
}
