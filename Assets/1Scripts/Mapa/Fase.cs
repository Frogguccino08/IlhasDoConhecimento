using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase : MonoBehaviour
{
    [SerializeField]
    PlayerMovement player;
    public int numFase;
    public Sprite[] sprites = new Sprite[6];

    //Status da fase (Bloqueada, Desbloqueada, Finalizada. +Todos esses versão boss)
    //Está no personagem selecionado
    //0 = bloqueada
    //1 = Desbloqueada
    //2 = Finalizada

    //Informações da fase
    public int regiao;
    public Inimigos[] inimigos = new Inimigos[6];
    public bool hasBoss;
    public int anyBoss;
    public bool highLevel;

    //Recompensas
    public int[] recompensaMaterial = new int[6];
    public int recompensaPersonagem;
    public int[] recompensaFase = new int[6]; 

    void OnMouseUp()
    {
        if(player.inicial == numFase)
        {
            PersonagemSelecionado pc = PersonagemSelecionado.instance;

            pc.faseAtual = numFase;

            pc.regiao = regiao;
            pc.hasBoss = hasBoss;
            pc.anyBoss = anyBoss;
            pc.highLevel = highLevel;
            pc.inimigos = inimigos;
            pc.recompensaMaterial = recompensaMaterial;
            pc.recompensaPersonagem = recompensaPersonagem;
            pc.recompensaFase = recompensaFase;
            SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
        }

        if(PersonagemSelecionado.instance.fasesBloqueio[numFase - 1] != 0)
        {
            player.inicial = numFase;
            player.Andar();
        }
    }

    public void MudarStatus()
    {
        if(PersonagemSelecionado.instance.fasesBloqueio[numFase - 1] == 0) GetComponent<SpriteRenderer>().sprite = sprites[0];

        if(PersonagemSelecionado.instance.fasesBloqueio[numFase - 1] == 1) GetComponent<SpriteRenderer>().sprite = sprites[1];

        if(PersonagemSelecionado.instance.fasesBloqueio[numFase - 1] == 2) GetComponent<SpriteRenderer>().sprite = sprites[2];
    }
}