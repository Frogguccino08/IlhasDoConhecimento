using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sair : MonoBehaviour
{
    public GameObject tela;
    public Controle control;
    public TMP_Text motivacao;

    public List<string> frases = new List<string>();

    public bool btOn;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && control.telaSair == false && control.vitoriaOn == false)
        {
            if(control.butao[0].GetComponent<Button>().enabled)
            {
                btOn = true;
            }
            else
            {
                btOn = false;
            }

            control.telaSair = true;
            control.descricao.SetActive(false);
            tela.SetActive(true);
            control.DesvisuTela();

            motivacao.text = frases[UnityEngine.Random.Range(0, frases.Count)];
            control.DesativarBotao();
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && control.telaSair == true)
        {
            if(btOn)
            {
                control.AtivarBotao();
            }

            control.telaSair = false;
            tela.SetActive(false);
            control.VisuTela();
        }
    }

    public void Voltar()
    {
        if(btOn)
            {
                control.AtivarBotao();
            }

            control.telaSair = false;
            tela.SetActive(false);
            control.VisuTela();
    }

    public void Quitar()
    {
        if(PersonagemSelecionado.instance.maxRush < control.pontosRodada)
        {
            PersonagemSelecionado.instance.maxRush = control.pontosRodada;
            PersonagemSelecionado.instance.pontos = PersonagemSelecionado.instance.maxRush;
            PersonagemSelecionado.instance.persoMax = PersonagemSelecionado.instance.perso.nome;

            PersonagemSelecionado.instance.SalvarInfo();
        }

        SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
        
    }

    public void VitoriaSair()
    {
        control.vitoriaOn = false;
    }

    public void PersoSair()
    {
        control.TelaPersoOn = false;
    }
}
