using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Escrever : MonoBehaviour
{
    public static Escrever instance;

    //Objetos
    [SerializeField] TMP_Text dialogo;
    [SerializeField] Image imagem;

    //Variaveis necessarias
    float velocidade = 0.02f;
    bool esperando = false;
    int dialogoAtual = 0;
    string nomeAtual = "";
    public bool emDialogo = false;

    //Listas que salvam os nomes e imagens
    public List<Sprite> imgs = new List<Sprite>();
    public List<string> nomes = new List<string>();

    //Listas que serão utilizadas no dialogo
    public List<string> falas = new List<string>();
    public List<Sprite> imgsUtilizadas = new List<Sprite>();
    public List<string> nomesUtilizados = new List<string>();

    

    //Função awake que checa se já existe um objeto não destrutivo, destroi ele caso tenha e mantem o novo
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        if((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0)) && emDialogo)
        {
            if(esperando)
            {
                esperando = false;
                dialogoAtual++;

                if(dialogoAtual < falas.Count())
                {
                    imagem.sprite = imgsUtilizadas[dialogoAtual];
                    nomeAtual = nomesUtilizados[dialogoAtual];

                    if(imagem.sprite == null) imagem.gameObject.SetActive(false);
                    if(imagem.sprite != null) imagem.gameObject.SetActive(true);

                    if(nomeAtual != "") dialogo.text = nomeAtual + ":\n" + falas[dialogoAtual];
                    if(nomeAtual == "") dialogo.text = falas[dialogoAtual];
                    StartCoroutine(TypeWriter());
                }
                else
                {
                    dialogo.text = "";
                    emDialogo = false;
                    if(GameObject.Find("Controlador") != null)GameObject.Find("Controlador").GetComponent<Controle>().emDialogo = false;
                    gameObject.GetComponent<Canvas>().enabled = false;
                }
                
            }
            else
            {
                dialogo.maxVisibleCharacters = dialogo.text.Count();
                esperando = true;
            }
        }
    }

    IEnumerator TypeWriter()
    {
        int max = dialogo.text.Count();
        int charAtual = 0;
        if(nomeAtual != "") charAtual = nomeAtual.Length + 1;

        do
        {
            dialogo.maxVisibleCharacters = charAtual;
            charAtual++;
            yield return new WaitForSeconds(velocidade);
        }while(charAtual <= max && !esperando);

        esperando = true;
    }

    void IniciarDialogos()
    {
        gameObject.GetComponent<Canvas>().enabled = true;
        dialogoAtual = 0;
        emDialogo = true;

        if(falas != null)
        {
            imagem.sprite = imgsUtilizadas[dialogoAtual];
            nomeAtual = nomesUtilizados[dialogoAtual];

            if(imagem.sprite == null) imagem.gameObject.SetActive(false);
            if(imagem.sprite != null) imagem.gameObject.SetActive(true);

            if(nomeAtual != "") dialogo.text = nomeAtual + ":\n" + falas[dialogoAtual];
            if(nomeAtual == "") dialogo.text = falas[dialogoAtual];
        }

        StartCoroutine(TypeWriter());
    }

    public void NovoDialogo(string[] dialogos)
    {
        falas.Clear();
        for(int i = 0; i < dialogos.Count(); i++)
        {
            falas.Add(dialogos[i]);
        }

        IniciarDialogos();
    }

    public void NovoPersonagens(int[] n)
    {
        imgsUtilizadas.Clear();
        nomesUtilizados.Clear();
        nomeAtual = "";

        foreach(int nu in n)
        {
            imgsUtilizadas.Add(imgs[nu]);
            nomesUtilizados.Add(nomes[nu]);
        }
    }
}
