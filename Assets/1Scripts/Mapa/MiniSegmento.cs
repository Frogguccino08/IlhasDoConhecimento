using UnityEngine;

public class MiniSegmento : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[4];
    public int enemyNum;

    void Start()
    {
        PersonagemSelecionado pc = PersonagemSelecionado.instance;
        Controle control = GameObject.Find("Controlador").GetComponent<Controle>();

        if(pc.anyBoss != enemyNum)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
    }

    public void Vitoria()
    {
        PersonagemSelecionado pc = PersonagemSelecionado.instance;

        if(pc.anyBoss != enemyNum)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
    }
}
