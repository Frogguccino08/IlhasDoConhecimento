using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersoGrande : MonoBehaviour
{
    public TMP_Text nome;
    public TMP_Text material;

    public Image imgPersonagem;
    public Image imgMaterial;

    public TMP_Text vida;

    public GameObject quadCheio;
    public GameObject quadVazio;

    public List<GameObject> quads = new List<GameObject>();

    public GameObject canva;
    public GameObject esseCanva;
    public PersonagemSelecionado pc;
    public AttacksList list;

    public GameObject[] attacks = new GameObject[4];


    void Awake()
    {
        pc = PersonagemSelecionado.instance;
    }


    public void ColocarPersonagem()
    {
        //Parte escrita tranquila
        nome.text = pc.perso.nome;

        switch (pc.perso.material)
        {
            case 1:
                material.text = "Papel";
                break;
            case 2:
                material.text = "Plástico";
                break;
            case 3:
                material.text = "Vidro";
                break;
            case 4:
                material.text = "Metal";
                break;
            case 5:
                material.text = "Orgânico";
                break;
        }

        vida.text = "Vida: " + pc.perso.maxHealth;
    }


    public void Voltando()
    {
        Debug.Log("Clicado");
        if (quads != null)
        {
            foreach (GameObject obj in quads)
            {
                Destroy(obj);
                quads.Remove(obj);
            }
        }
        canva.SetActive(true);
        esseCanva.SetActive(false);
        pc.perso = null;
    }

    public void Jogando()
    {
        pc.regiao = Random.Range(0, 5);
        SceneManager.LoadScene("Combate", LoadSceneMode.Single);
    }
}
