using UnityEngine;

public class Fase : MonoBehaviour
{
    [SerializeField]
    PlayerMovement player;
    public int numFase;
    public Sprite[] sprites = new Sprite[6];

    //Status da fase (Bloqueada, Desbloqueada, Finalizada. +Todos esses versão boss)
    //Está no personagem selecionado

    //Informações da fase
    public int regiao;
    public Inimigos[] inimigos = new Inimigos[6];
    public int anyBoss;
    //Salvar tudo isso no Personagem Selecionado pra poder ir do mapa pro combate com as informações

    void OnMouseDown()
    {
            Debug.Log("Clicou N:" + numFase);
            player.inicial = numFase;
            player.Andar();
    }

    public void MudarStatus()
    {
        if(PersonagemSelecionado.instance.fasesBloqueio[numFase] == 0) GetComponent<SpriteRenderer>().sprite = sprites[0];

        if(PersonagemSelecionado.instance.fasesBloqueio[numFase] == 1) GetComponent<SpriteRenderer>().sprite = sprites[1];

        if(PersonagemSelecionado.instance.fasesBloqueio[numFase] == 2) GetComponent<SpriteRenderer>().sprite = sprites[2];
    }
}