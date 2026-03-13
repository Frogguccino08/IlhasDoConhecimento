using UnityEngine;

public class AnaSpheres : MonoBehaviour
{
    //Movimento
    float velocidade = 0.3f;
    int direcao = 0;
    float chao = 1;
    float teto = 1.5f;
    public bool esquerda;

    //Cores
    public Player player;
    public SpriteRenderer cor;
    public int mainColor = 0;
    public Color32 corEspecial;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, 1.25f, transform.position.z);

        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        if(transform.position.y >= teto)
            direcao = -1;

        if(transform.position.y <= chao)
            direcao = 1;

        if(direcao == 0)
        {
            if(!esquerda)
            {
                transform.Translate(0, velocidade * Time.deltaTime, 0);
            }
                
            if(esquerda)
            {
                transform.Translate(0, -1 * velocidade * Time.deltaTime, 0);
            }
        }
        else
        {
            transform.Translate(0, velocidade * Time.deltaTime * direcao, 0);
        }

        if(player.materialPlayer != mainColor)
        {
            cor.color = new Color32(147, 115, 80, 255);
            transform.localScale = new Vector3(0.9f, 0.9f, 1);
        }
        else
        {
            cor.color = corEspecial;
            transform.localScale = new Vector3(1.1f, 1.1f, 1);
        }
            
    }
}
