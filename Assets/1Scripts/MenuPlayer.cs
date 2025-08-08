using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class MenuPlayer : MonoBehaviour
{
    //Variáveis do player
    int id;
    string nome;
    int material; //1==Papel, 2==Plastico, 3==Vidro, 4==Metal, 5==Organico
    Sprite imgCombate;

    float maxHealth;
    int maxCharge, pDamage, pDefense, sDamage, sDefense;

    public int[] listaAtaquesIniciais = new int[4];

    //Chamado de objetos
    public PCsSO pc;

    public TMP_Text textNome;
    public Image imgMain;
    public TMP_Text textMaterial;
    public TMP_Text textVida;
    public PersonagemSelecionado selecionado;
    public AttacksEfeitos list;

    public GameObject Vazio;
    public GameObject Cheio;
    public GameObject Ataque;


    //Função Start que procura pelo objeto não destrutivo que salva o player que foi selecionado e também coloca as informações do personagem no espaço
    void Start()
    {
        selecionado = PersonagemSelecionado.instance;
        EscolhendoPlayer();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("TelaInicial", LoadSceneMode.Single);
        }
    }

    //Função que coloca as informações do personagem no espaço dele no menu de seleção
    public void EscolhendoPlayer()
    {
        id = pc.id;
        nome = pc.nome;
        material = pc.material;
        if (pc.imgMenu != null)
        {
            imgMain.GetComponent<Image>().sprite = pc.imgMenu;
        }
        imgCombate = pc.imgCombate;

        maxHealth = pc.maxHealth;
        maxCharge = pc.maxCharge;
        pDamage = pc.pDamage;
        pDefense = pc.pDefense;
        sDamage = pc.sDamage;
        sDefense = pc.sDefense;


        textNome.text = nome;
        switch (material)
        {
            case 1:
                textMaterial.text = "Papel";
                break;
            case 2:
                textMaterial.text = "Plástico";
                break;
            case 3:
                textMaterial.text = "Vidro";
                break;
            case 4:
                textMaterial.text = "Metal";
                break;
            case 5:
                textMaterial.text = "Orgânico";
                break;
        }
        textVida.text = "Vida: " + maxHealth;


        //Quadrados
        //Conhecimento
        for (int i = 1; i <= 5; i++)
        {
            GameObject obj;

            if (i <= maxCharge)
            {
                obj = Instantiate(Cheio, new Vector3(-8.5f + (id * 4) + (i * 0.4f), 0.7f, 0f), quaternion.identity);
            }
            else
            {
                obj = Instantiate(Vazio, new Vector3(-8.5f + (id * 4) + (i * 0.4f), 0.7f, 0f), quaternion.identity);
            }

            obj.transform.SetParent(this.transform);
        }

        //Dano Físico
        for (int i = 1; i <= 5; i++)
        {
            GameObject obj;

            if (i <= pDamage)
            {
                obj = Instantiate(Cheio, new Vector3(-8.5f + (id * 4) + (i * 0.4f), 0.2f, 0f), quaternion.identity);
            }
            else
            {
                obj = Instantiate(Vazio, new Vector3(-8.5f + (id * 4) + (i * 0.4f), 0.2f, 0f), quaternion.identity);
            }

            obj.transform.SetParent(this.transform);
        }

        //Defesa Físico
        for (int i = 1; i <= 5; i++)
        {
            GameObject obj;

            if (i <= pDefense)
            {
                obj = Instantiate(Cheio, new Vector3(-8.5f + (id * 4) + (i * 0.4f), -0.3f, 0f), quaternion.identity);
            }
            else
            {
                obj = Instantiate(Vazio, new Vector3(-8.5f + (id * 4) + (i * 0.4f), -0.3f, 0f), quaternion.identity);
            }

            obj.transform.SetParent(this.transform);
        }

        //Dano Especial
        for (int i = 1; i <= 5; i++)
        {
            GameObject obj;

            if (i <= sDamage)
            {
                obj = Instantiate(Cheio, new Vector3(-8.5f + (id * 4) + (i * 0.4f), -0.8f, 0f), quaternion.identity);
            }
            else
            {
                obj = Instantiate(Vazio, new Vector3(-8.5f + (id * 4) + (i * 0.4f), -0.8f, 0f), quaternion.identity);
            }

            obj.transform.SetParent(this.transform);
        }

        //Dano Especial
        for (int i = 1; i <= 5; i++)
        {
            GameObject obj;

            if (i <= sDefense)
            {
                obj = Instantiate(Cheio, new Vector3(-8.5f + (id * 4) + (i * 0.4f), -1.3f, 0f), quaternion.identity);
            }
            else
            {
                obj = Instantiate(Vazio, new Vector3(-8.5f + (id * 4) + (i * 0.4f), -1.3f, 0f), quaternion.identity);
            }

            obj.transform.SetParent(this.transform);
        }

    }

    //Função que faz quando clicar no personagem salvar no objeto não destrutivo e passa para a cena do combate
    public void Onclick()
    {
        PersonagemSelecionado.instance.regiao = UnityEngine.Random.Range(0, 5);
        PersonagemSelecionado.instance.perso = pc;
        SceneManager.LoadScene("Combate", LoadSceneMode.Single);
    }

    public void Voltar()
    {
        SceneManager.LoadScene("TelaInicial", LoadSceneMode.Single);
    }
}
