using UnityEngine;

public class Segmento : MonoBehaviour
{
    public GameObject inimigo;
    public GameObject player;
    public GameObject objPlayer;
    public GameObject[] obj = new GameObject[6];
    int tamanho = 0;

    void Start()
    {
        PersonagemSelecionado pc = PersonagemSelecionado.instance;

        objPlayer = Instantiate(player, transform);

        for(int i = 0; i < 6; i++)
        {
            if(pc.inimigos[i].id != 0)
            {
                obj[i] = Instantiate(inimigo, transform);
                obj[i].GetComponent<MiniSegmento>().enemyNum = i + 1;
                tamanho++;
            }
        }

        for(int o = 0; o < 6; o++)
        {
            if(obj[o] != null)
            {
                obj[o].transform.localPosition = new Vector3(-0.5f * (tamanho - 1), 0, 0);
                obj[o].transform.Translate(1f * o, 0, 0);
            }
        }

        MexerPlayer();
    }

    public void MexerPlayer()
    {
        Controle control = GameObject.Find("Controlador").GetComponent<Controle>();

        if(control.inimigoAtual <= 6) objPlayer.transform.position = obj[control.inimigoAtual - 1].transform.position + new Vector3(0, -0.5f, 0);
    }
}
