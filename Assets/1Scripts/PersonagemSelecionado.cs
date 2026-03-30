using System.Collections.Generic;
using UnityEngine;

public class PersonagemSelecionado : MonoBehaviour
{
    //Variaveis necessarias para o objeto não destrutivo
    public static PersonagemSelecionado instance;
    public PCsSO perso;
    public int regiao;
    public int pontos;
    public float[] material = new float[6];

    public string persoMax;
    public int maxRush;
    
    public List<bool> unlock = new List<bool>();

    public List<PCsSO> persos = new List<PCsSO>();

    //Função awake que checa se já existe um objeto não destrutivo, destroi ele caso tenha e mantem o novo
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject); // Elimina o duplicado
        }
    else
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject); // Persiste o objeto
    }
    }

    //Função que limpa toda a informação do objeto que não será mais usada após acabar o combate
    public void Resetar()
    {
        if (perso != null)
        {
            perso = null;
            regiao = 0;
        }
    }

    //Exclui toda informa��o
    public void HardReset()
    {
            perso = null;
            regiao = 0;
            pontos = 0;
            persoMax = "";
            maxRush = 0;

            for(int i = 0; i < 6; i++)
            {
                material[i] = 0;
            }

            unlock[5] = false;

            SalvarInfo();
    }

    public void SalvarInfo()
    {
        SaveSystem.Save(this);
    }

    public void CarregarInfo()
    {
        Info data = SaveSystem.Load();

        for(int i = 0; i < 6; i++)
        {
            material[i] = data.material[i];
        }

        persoMax = data.nomeMax;
        maxRush = data.pontoMax;

        for(int i = 0; i < 6; i++)
        {
            unlock[i] = data.bloqueados[i];
        }
    }
}
