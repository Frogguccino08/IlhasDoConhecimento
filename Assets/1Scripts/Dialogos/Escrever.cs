using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Escrever : MonoBehaviour
{
    public static Escrever instance;

    //Objetos
    [SerializeField] TMP_Text dialogo;
    [SerializeField] Image imagem;

    //Variaveis necessarias
    float velocidade = 0.03f;
    bool esperando = false;

    public List<string> falas = new List<string>();
    int dialogoAtual = 0;

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

    void Start()
    {
        IniciarDialogos();

        NovoDialogo(new string[]
        {"Esse é um texto de exemplo e \"<color=green>Vidro</color>\" está escrito em verde\nE esse texto vai aparecer na linha de baixo",
        "Esse é mais um texto de tentativa",
        "Mds eu não sei o que escrever"});
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0))
        {
            if(esperando)
            {
                esperando = false;
                dialogoAtual++;

                if(dialogoAtual < falas.Count())
                {
                    dialogo.text = falas[dialogoAtual];
                    StartCoroutine(TypeWriter());
                }
                else
                {
                    dialogo.text = "";
                    gameObject.SetActive(false);
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
        dialogoAtual = 0;

        if(falas != null)
        {
            dialogo.text = falas[dialogoAtual];
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
}
