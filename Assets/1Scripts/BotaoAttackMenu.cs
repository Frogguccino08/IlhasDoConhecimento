using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BotaoAttackMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public PCsSO pc;
    public GameObject itself;
    public int id;

    public Descricao descri;
    public GameObject desc;
    public TMP_Text textNome;
    public TMP_Text textCarga;
    public AttackList list;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        descri.BotandoDescricao(pc.listaAtaquesIniciais[id]);

        if(pc.id > 3)
        {
            desc.transform.position = new Vector3(this.transform.position.x - 4.5f, 0f, this.transform.position.z);
        }else
        {
            desc.transform.position = new Vector3(this.transform.position.x + 4.5f, 0f, this.transform.position.z);
        }
        desc.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        desc.SetActive(false);
    }
}
