using System.Collections.Generic;
using UnityEngine;

public class InfoPlayer : MonoBehaviour
{
    //Variaveis necessarias para o objeto não destrutivo
    public static InfoPlayer instance;
    public string username;
    public float[] material = new float[6];

    public string persoMax;
    public int maxRush;
    
    public List<bool> unlock = new List<bool>();
    public int[] fasesBloqueio = new int[30];

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

    //Exclui toda informa��o
    public void HardReset()
    {
        username = "";
        persoMax = "";
        maxRush = 0;

        for(int i = 0; i < 6; i++)
        {
            material[i] = 0;
        }

        unlock[5] = false;

        SalvarInfo();
    }

    public void CleanReset()
    {
        username = "";
        persoMax = "";
        maxRush = 0;

        for(int i = 0; i < 6; i++)
        {
            material[i] = 0;
        }

        unlock[5] = false;
    }

    public void SalvarInfo()
    {
        SaveSystem.Save(this);
    }

    public void CarregarInfo()
{
    SaveSystem.Load((data) =>
    {
        username = data.username;

        if(data != null)
        {
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

            Debug.Log("Dados carregados!");
        }
    });
}
}
