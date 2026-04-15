using System;
using System.Collections;
using UnityEngine;

public class Recompensa : MonoBehaviour
{
    //Lembrar de salvar no final de todas as recompensas
    
    //Conexões
    public GameObject[] avisos = new GameObject[6];
    public Enemy enemy;
    public PersonagemSelecionado perso;
    public Controle control;

    //Telas
    public GameObject telaMaterial;

    //Recompensas de Material
    public float[] materiais = new float[6];

    void Awake()
    {
        perso = PersonagemSelecionado.instance;
    }

    public IEnumerator RecebaMaterial()
    {
        telaMaterial.SetActive(true);

        for (int i = 0; i < 6; i++)
        {
            float variacao = UnityEngine.Random.Range(0.8f, 1.2f);
            avisos[i].GetComponent<MaterialGanho>().Ajustes(i, MathF.Round(perso.recompensaMaterial[i] * variacao));
        }

        yield return StartCoroutine(control.EsperarTeclaEspaco());
        yield return new WaitForSeconds(0.1f);
    }
}
