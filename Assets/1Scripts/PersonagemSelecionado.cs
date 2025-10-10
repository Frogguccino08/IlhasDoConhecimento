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

    public int maxRush;
    public int maxHistoria;
    
    public List<bool> unlock = new List<bool>();
    public bool modoHistoria = false;

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
}
