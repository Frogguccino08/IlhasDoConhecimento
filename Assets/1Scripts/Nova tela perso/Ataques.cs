using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Ataques : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int id;
    public bool habilidade = false;
    public TMP_Text nome;
    public TMP_Text carga;
    public GameObject descri;
    public AttacksList list;
    public PersonagemSelecionado pc;

    void Awake()
    {
        pc = PersonagemSelecionado.instance;

        if (SceneManager.GetActiveScene().name == "Combate")
        {
            ColocarAtaque();
        }
    }

    public void ColocarAtaque()
    {
        if (habilidade == false)
        {
            nome.text = list.listaAtaques[id].nome;
            if (carga != null)
            {
                carga.text = list.listaAtaques[id].carga.ToString();
            }
        }
        else
        {
            id = pc.perso.id;
            nome.text = list.listaHabilidades[id].nome;
        }
    }

    public void OnPointerEnter(PointerEventData pointerEvent)
    {
        descri.SetActive(true);
        if (habilidade == false)
        {
            descri.GetComponent<Descricao>().BotandoDescricao(id, false);
        }
        else
        {
            descri.GetComponent<Descricao>().BotandoDescricao(id, true);
        }
        
    }

    public void OnPointerExit(PointerEventData pointerEvent)
    {
        descri.SetActive(false);
    }
}
