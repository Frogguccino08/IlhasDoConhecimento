using UnityEngine;

public class Recompensa : MonoBehaviour
{
    public float[] materiais = new float[6];
    public Enemy enemy;
    public bool teste = true;
    public PersonagemSelecionado perso;

    void Start()
    {
        perso = PersonagemSelecionado.instance;
    }

    public void Receba()
    {
        int bonus = 0;
        if (enemy.isBoss)
        {
            bonus = 2;
        }
        //Recompensas
        materiais[0] = Mathf.Round((enemy.forcaAtual + 1 + bonus) * 5 * UnityEngine.Random.Range(0.7f, 1.3f));
        Debug.Log("Material padrão ganho: " + materiais[0]);
        perso.material[0] += materiais[0];

        materiais[enemy.materialInimigo] = Mathf.Round((enemy.forcaAtual + 1 + bonus) * 3 * UnityEngine.Random.Range(0.7f, 1.3f));
        Debug.Log("Material especifoc ganho: " + materiais[enemy.materialInimigo]);
        perso.material[enemy.materialInimigo] += materiais[enemy.materialInimigo];
    }
}
