using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sair : MonoBehaviour
{
    public GameObject tela;
    public Controle control;

    public bool btOn;
    public bool fraquezas = false;

    //Botões
    public GameObject btContinuar;
    public GameObject btFraquezas;
    public GameObject fraqs;
    public GameObject btSair;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && control.telaSair == false)
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

            control.DesativarBotao();
            AtivarMenu();
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && control.telaSair == true)
        {
            if(btOn)
            {
                control.AtivarBotao();
            }
            
            if(!fraquezas)
            {
                control.telaSair = false;
                tela.SetActive(false);
                control.VisuTela();
            }
            else
            {
                AtivarMenu();
            }
            
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
        if(InfoPlayer.instance.maxRush < control.pontosRodada)
        {
            InfoPlayer.instance.maxRush = control.pontosRodada;
            PersonagemSelecionado.instance.pontos = InfoPlayer.instance.maxRush;
            InfoPlayer.instance.persoMax = PersonagemSelecionado.instance.perso.nome;

            InfoPlayer.instance.SalvarInfo();
        }

        SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
        
    }

    public void AtivarMenu()
    {
        btContinuar.SetActive(true);
        btFraquezas.SetActive(true);
        btSair.SetActive(true);
        fraqs.SetActive(false);
        fraquezas = false;
    }

    public void AtivarFraquezas()
    {
        btContinuar.SetActive(false);
        btFraquezas.SetActive(false);
        btSair.SetActive(false);
        fraqs.SetActive(true);
        fraquezas = true;
    }
}
