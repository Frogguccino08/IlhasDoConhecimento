using System.Collections.Generic;
using UnityEngine;

public class PersonagemSelecionado : MonoBehaviour
{
    //Variaveis necessarias para o objeto não destrutivo
    public static PersonagemSelecionado instance;
    public PCsSO perso;
    public int regiao;
    public int pontos;
    
    public List<PCsSO> persos = new List<PCsSO>();

    //Modo historia
    public bool isHistoria;
    public int faseAtual;
    public Inimigos[] inimigos = new Inimigos[6];
    public bool hasBoss;
    public int anyBoss;
    public bool highLevel;

    //Recompensas história
    public int[] recompensaMaterial = new int[6];
    public int[] recompensaPersonagem = new int[6];
    public int[] recompensaFase = new int[6]; 

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
            for(int i = 0; i < 6; i++)
            {
                if (inimigos[i] == null)
                {
                    inimigos[i] = new Inimigos();
                }

                if (inimigos[i].atq == null || inimigos[i].atq.Length != 6)
                {
                    inimigos[i].atq = new int[6];
                }
            }
        }
    }

    public void GarantirInimigos()
    {
        for(int i = 0; i < 6; i++)
        {
            if (inimigos[i] == null)
                inimigos[i] = new Inimigos();

            if (inimigos[i].atq == null || inimigos[i].atq.Length != 6)
                inimigos[i].atq = new int[6];
        }
    }

    //Função que limpa toda a informação do objeto que não será mais usada após acabar o combate
    public void Resetar()
    {
        if (perso != null && !isHistoria)
        {
            perso = null;
            regiao = 0;
        }

        if(perso != null && isHistoria)
        {
            perso = null;

            for(int i = 0; i < 6; i++)
            {
                inimigos[i] = null;
                recompensaMaterial[i] = 0;
                recompensaFase[i] = 0;
                recompensaPersonagem[i] = 0;
            }
            

            hasBoss = false;
            anyBoss = 0;
            highLevel = false;
        }
    }
}
