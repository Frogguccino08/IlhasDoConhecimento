using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Recompensa : MonoBehaviour
{
    //Lembrar de salvar no final de todas as recompensas
    
    //Conexões
    public GameObject[] avisos = new GameObject[6];
    public Enemy enemy;
    public PersonagemSelecionado perso;
    InfoPlayer info;
    public Controle control;

    //Telas
    public GameObject telaMaterial;
    public GameObject telaPersonagem;

    //Recompensas de Material
    public float[] materiais = new float[6];

    //Recompensa de personagens
    public GameObject boneco;
    public GameObject[] personagens = new GameObject[6];
    public int quantBoneco = 0;
    public GameObject salvamento;

    void Awake()
    {
        perso = PersonagemSelecionado.instance;
        info = InfoPlayer.instance;

    }

    public IEnumerator RecebaMaterial()
    {
        telaMaterial.SetActive(true);

        for (int i = 0; i < 6; i++)
        {
            float variacao = UnityEngine.Random.Range(0.8f, 1.2f);
            avisos[i].GetComponent<MaterialGanho>().Ajustes(i, MathF.Round(perso.recompensaMaterial[i] * variacao));
        }

        info.SalvarInfo();

        yield return StartCoroutine(control.EsperarTeclaEspaco());
        yield return new WaitForSeconds(0.1f);
        telaMaterial.SetActive(false);
    }

    public IEnumerator ReceberPersonagem()
    {
        int nPerso = 0;
        telaPersonagem.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        for(int i = 0; i < perso.recompensaPersonagem.Length; i++)
        {
            if(perso.recompensaPersonagem[i] != 0 && info.unlock[perso.recompensaPersonagem[i]] == false)
            {
                personagens[i] = Instantiate(boneco, salvamento.transform);
                personagens[i].GetComponent<RecompensaPerso>().NumBoneco = perso.recompensaPersonagem[i];
                personagens[i].GetComponent<RecompensaPerso>().ArrumarBoneco();
                info.unlock[perso.recompensaPersonagem[i]] = true;
                quantBoneco++;
            }
        }

        for(int o = 0; o < 6; o++)
        {
            if(personagens[o] != null)
            {
                personagens[o].transform.position = new Vector3(-1.5f * (quantBoneco - 1), 0, 0);
                personagens[o].transform.Translate(3f * nPerso, 0, 0);
                nPerso++;
            }
        }

        info.SalvarInfo();

        if(quantBoneco != 0)
        {
            yield return StartCoroutine(control.EsperarTeclaEspaco());
            yield return new WaitForSeconds(0.1f);
        }
        telaPersonagem.SetActive(false);
    }

    public void LiberarFases()
    {
        for(int i = 0; i < 6; i++)
        {
            if(perso.recompensaFase[i] != 0 && info.fasesBloqueio[perso.recompensaFase[i] - 1] == 0) info.fasesBloqueio[perso.recompensaFase[i] - 1] = 1;
        }
    }
}
