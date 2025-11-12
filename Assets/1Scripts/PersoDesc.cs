using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PersoDesc : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject telaDesc;
    public GameObject descRegiao;
    public TMP_Text texto;
    public Player player;
    public GameObject descHabilidade;
    public DescRegiao regis;

    public TMP_Text regiaoTopo;
    public string extra;

    void Start()
    {
        regis = descRegiao.GetComponent<DescRegiao>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        telaDesc.SetActive(true);
        telaDesc.transform.SetSiblingIndex(20);
        texto.text = "Dano físico: " + player.phiDamage + "\nDano a dist: " + player.speDamage + "\nDefesa física: " + player.phiDefense + "\nDefesa a dist: " + player.speDefense;
        descHabilidade.SetActive(true);
        descHabilidade.GetComponent<Descricao>().BotandoDescricao(player.perso.perso.id, true);

        extra = regiaoTopo.text;

        descRegiao.SetActive(true);
        regis.nome.text = regis.lista.listaRegiao[PersonagemSelecionado.instance.regiao].nome;
        regis.descri.text = regis.lista.listaRegiao[PersonagemSelecionado.instance.regiao].desc;

        switch (regis.lista.listaRegiao[PersonagemSelecionado.instance.regiao].material)
        {
            case 1:
                regis.material.text = "Papel";
                regiaoTopo.text = "Os Arquivos";
                break;
            case 2:
                regis.material.text = "Plástico";
                regiaoTopo.text = "Comunidade Abandonada";
                break;
            case 3:
                regis.material.text = "Vidro";
                regiaoTopo.text = "Costa de Cacos";
                break;
            case 4:
                regis.material.text = "Metal";
                regiaoTopo.text = "Coração da Ilha";
                break;
            case 5:
                regis.material.text = "Orgânico";
                regiaoTopo.text = "Floresta Orgânica";
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        telaDesc.SetActive(false);
        descHabilidade.SetActive(false);
        descRegiao.SetActive(false);
        regiaoTopo.text = extra;
    }
}
