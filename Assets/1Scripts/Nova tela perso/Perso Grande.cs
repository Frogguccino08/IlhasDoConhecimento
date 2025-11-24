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
    public Image corPersonagem;
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

    //Coisas para a Lore do personagem
    public bool oJogo = true;
    public GameObject jogar;
    public GameObject lore;
    public GameObject transPin;
    public TMP_Text pronome;
    public TMP_Text idade;
    public TMP_Text historia;
    public TMP_Text textoBt;



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
        imgPersonagem.sprite = pc.perso.imgCombate;
        corPersonagem.sprite = pc.perso.Cor;

        CorDetalhes();

        //Parte escrita tranquila
        nome.text = pc.perso.nome;

        switch (pc.perso.material)
        {
            case 1:
                material.text = "Papel";
                imgMaterial.GetComponent<Image>().color = new Color32(65, 105, 225, 255);
                break;
            case 2:
                material.text = "Plástico";
                imgMaterial.GetComponent<Image>().color = new Color32(155, 17, 30, 255);
                break;
            case 3:
                material.text = "Vidro";
                imgMaterial.GetComponent<Image>().color = new Color32(0, 100, 0, 255);
                break;
            case 4:
                material.text = "Metal";
                imgMaterial.GetComponent<Image>().color = new Color32(238, 173, 45, 255);
                break;
            case 5:
                material.text = "Orgânico";
                imgMaterial.GetComponent<Image>().color = new Color32(120, 64, 8, 255);
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

        for (int o = 0; o < quads.Count; o++)
        {
            quads[o].transform.SetParent(jogar.transform);
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
        if (pc.modoHistoria == false)
        {
            pc.regiao = UnityEngine.Random.Range(0, 5);
        }
        else
        {
            pc.regiao = pc.perso.regioes[0];
        }

        SceneManager.LoadScene("Combate", LoadSceneMode.Single);
    }

    public void CorDetalhes()
    {
        corPersonagem.enabled = false;

        if (pc.perso.Cor != null)
        {
            corPersonagem.enabled = true;

            if (pc.perso.material == 1)
            {
                corPersonagem.color = new Color32(51, 58, 99, 255);
            }
            else if (pc.perso.material == 2)
            {
                corPersonagem.color = new Color32(86, 7, 13, 240);
            }
            else if (pc.perso.material == 3)
            {
                corPersonagem.color = new Color32(0, 54, 0, 255);
            }
            else if (pc.perso.material == 4)
            {
                corPersonagem.color = new Color32(136, 98, 22, 255);
            }
            else if (pc.perso.material == 5)
            {
                corPersonagem.color = new Color32(90, 78, 53, 255);
            }
        }
    }

    public void First()
    {
        jogar.SetActive(true);
        lore.SetActive(false);
        oJogo = true;
        textoBt.text = "Lore";
    }

    public void BtLoreCombate()
    {
        if(oJogo)
        {
            jogar.SetActive(false);
            lore.SetActive(true);
            oJogo = false;
            textoBt.text = "Combate";

            if (pc.perso.isTrans)
                transPin.transform.rotation = Quaternion.identity;
                transPin.transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(-45, 45)));
        }
        else
        {
            jogar.SetActive(true);
            lore.SetActive(false);
            oJogo = true;
            textoBt.text = "Lore";
        }
    }
}
