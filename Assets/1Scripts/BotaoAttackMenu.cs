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
    public AttacksEfeitos list;
    public AttacksList lista;

    //Variáveis dos ataques
    public string nome;
    public string descA;
    public int material;
    public int dano;
    public bool phispe;
    public bool alvo;
    public int quantidade;
    public int carga;
    public bool temEfeito;
    public bool isPassiva;
    //lista.CriarAtaques(Id, nome, descA, material, dano, phispe, alvo, quantidade, carga, temEfeito, isPassiva);
    //lista = GameObject.Find("AttackList").GetComponent<AttacksList>();

    //Função ao iniciar, Coloca os ataques dos personagens no menu
    void Start()
    {
        Attacks ataque = lista.CriarAtaques(pc.listaAtaquesIniciais[id]);
        nome = ataque.nome;
        descA = ataque.desc;
        material = ataque.material;
        dano = ataque.dano;
        phispe = ataque.phispe;
        alvo = ataque.alvo;
        quantidade = ataque.quantidade;
        carga = ataque.carga;
        temEfeito = ataque.temEfeito;
        isPassiva = ataque.isPassiva;

        textNome.text = nome;
        textCarga.text = carga.ToString();

        descri = desc.GetComponent<Descricao>();

        if(pc.listaAtaquesIniciais[id] == 0 && nome == "- -")
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
