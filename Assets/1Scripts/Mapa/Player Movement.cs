using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int inicial;
    int index = 1;
    public GameObject[] fases = new GameObject[30];

    void Start()
    {
        inicial = PersonagemSelecionado.instance.faseAtual;
        
        foreach(GameObject obj in fases)
        {
            if(obj)
            {
                obj.GetComponent<Fase>().numFase = index;
                obj.GetComponent<Fase>().MudarStatus();
                index++;
            }
        }

        Andar();
    }

    public void Andar()
    {
        transform.position = fases[inicial - 1].transform.position;
    }
}
