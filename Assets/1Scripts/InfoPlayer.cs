using System.Collections.Generic;
using UnityEngine;

public class InfoPlayer : MonoBehaviour
{
    //Variaveis necessarias para o objeto não destrutivo
    public static InfoPlayer instance;
    public string username;

    public string persoMax;
    public int maxRush;
    
    public List<bool> unlock = new List<bool>();

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
        unlock[5] = false;

        SalvarInfo();
    }

    public void CleanReset()
    {
        username = "";
        persoMax = "";
        maxRush = 0;

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
