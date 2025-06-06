using UnityEngine;

public class PersonagemSelecionado : MonoBehaviour
{
    public static PersonagemSelecionado instance;
    public PCsSO perso;
    public int regiao;
    public int pontos;

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

    public void Resetar()
    {
        if (perso != null)
    {
        perso = null;
        regiao = 0;
    }
    }
}
