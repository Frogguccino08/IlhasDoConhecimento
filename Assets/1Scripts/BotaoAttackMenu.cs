using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BotaoAttackMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Chamado de outros objetos (Realmente de fora)
    public PCsSO pc;
    public GameObject itself;
    public int id;

    //De dentro dele
    public Descricao descri;
    public GameObject desc;
    public TMP_Text textNome;
    public TMP_Text textCarga;
    public AttackList list;

    //Função ao iniciar, Coloca os ataques dos personagens no menu
    void Awake()
    {
        list.CriarAtaque(pc.listaAtaquesIniciais[id]);
        textNome.text = list.nome;
        textCarga.text = list.carga.ToString();

        descri = desc.GetComponent<Descricao>();

        if(pc.listaAtaquesIniciais[id] == 0 && list.nome == "- -")
        {
            itself.SetActive(false);
        }
    }

    //Função que faz aparecer a descrição do ataque ao passar o mouse
    public void OnPointerEnter(PointerEventData eventData)
    {
        descri.BotandoDescricao(pc.listaAtaquesIniciais[id]);

        if (pc.id > 3)
        {
            desc.transform.position = new Vector3(this.transform.position.x - 4.5f, 0f, this.transform.position.z);
        }
        else
        {
            desc.transform.position = new Vector3(this.transform.position.x + 4.5f, 0f, this.transform.position.z);
        }
        desc.SetActive(true);
    }

    //Função que faz sumir a descrição quando tira o mouse
    public void OnPointerExit(PointerEventData eventData)
    {
        desc.SetActive(false);
    }
}
