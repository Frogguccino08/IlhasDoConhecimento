using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
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
    public GameObject habilidade;

    public GameObject descri;


    void Awake()
    {
        pc = PersonagemSelecionado.instance;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Voltando();
        }
    }


    public void ColocarPersonagem()
    {
        //Imagem
        imgPersonagem.sprite = pc.perso.imgMenu;

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

        for (int i = 0; i < 4; i++)
        {
            attacks[i].GetComponent<Ataques>().id = pc.perso.listaAtaquesIniciais[i];
            attacks[i].GetComponent<Ataques>().ColocarAtaque();

            if (attacks[i].GetComponent<Ataques>().id == 0)
            {
                attacks[i].SetActive(false);
            }
            else
            {
                attacks[i].SetActive(true);
            }
        }

        habilidade.GetComponent<Ataques>().ColocarAtaque();

        //Quadrados

        //Conhecimento
        for (int i = 1; i <= 5; i++)
        {
            if (i <= pc.perso.maxCharge)
            {
                quads.Add(Instantiate(quadCheio, new Vector3(3 + ((i - 1) * 0.4f), 3.94f, 0), quaternion.identity));
            }
            else
            {
                quads.Add(Instantiate(quadVazio, new Vector3(3 + ((i - 1) * 0.4f), 3.94f, 0), quaternion.identity));
            }
            quads[quads.Count - 1].transform.SetParent(esseCanva.transform);
        }
        //Dano físico
        for (int i = 1; i <= 5; i++)
        {
            if (i <= pc.perso.pDamage)
            {
                quads.Add(Instantiate(quadCheio, new Vector3(3 + ((i - 1) * 0.4f), 3.34f, 0), quaternion.identity));
            }
            else
            {
                quads.Add(Instantiate(quadVazio, new Vector3(3 + ((i - 1) * 0.4f), 3.34f, 0), quaternion.identity));
            }
            quads[quads.Count - 1].transform.SetParent(esseCanva.transform);
        }
        //Defesa física
        for (int i = 1; i <= 5; i++)
        {
            if (i <= pc.perso.pDefense)
            {
                quads.Add(Instantiate(quadCheio, new Vector3(3 + ((i - 1) * 0.4f), 2.74f, 0), quaternion.identity));
            }
            else
            {
                quads.Add(Instantiate(quadVazio, new Vector3(3 + ((i - 1) * 0.4f), 2.74f, 0), quaternion.identity));
            }
            quads[quads.Count - 1].transform.SetParent(esseCanva.transform);
        }
        //Dano à distância
        for (int i = 1; i <= 5; i++)
        {
            if (i <= pc.perso.sDamage)
            {
                quads.Add(Instantiate(quadCheio, new Vector3(3 + ((i - 1) * 0.4f), 2.14f, 0), quaternion.identity));
            }
            else
            {
                quads.Add(Instantiate(quadVazio, new Vector3(3 + ((i - 1) * 0.4f), 2.14f, 0), quaternion.identity));
            }
            quads[quads.Count - 1].transform.SetParent(esseCanva.transform);
        }
        //Defesa à distância
        for (int i = 1; i <= 5; i++)
        {
            if (i <= pc.perso.sDefense)
            {
                quads.Add(Instantiate(quadCheio, new Vector3(3 + ((i - 1) * 0.4f), 1.54f, 0), quaternion.identity));
            }
            else
            {
                quads.Add(Instantiate(quadVazio, new Vector3(3 + ((i - 1) * 0.4f), 1.54f, 0), quaternion.identity));
            }
            quads[quads.Count - 1].transform.SetParent(esseCanva.transform);
        }
    }


    public void Voltando()
    {
        descri.SetActive(false);
        Debug.Log("Clicado");
        if (quads != null)
        {
            foreach (GameObject obj in quads)
            {
                Destroy(obj);
            }
            quads.Clear();
        }
        canva.SetActive(true);
        esseCanva.SetActive(false);
        pc.perso = null;
    }

    public void Jogando()
    {
        pc.regiao = UnityEngine.Random.Range(0, 5);
        SceneManager.LoadScene("Combate", LoadSceneMode.Single);
    }
}
