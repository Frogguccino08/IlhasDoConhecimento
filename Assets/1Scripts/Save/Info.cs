using UnityEngine;

[System.Serializable]
public class Info
{
    public float[] material;
    public string nomeMax;
    public int pontoMax;
    public bool[] bloqueados;

    public Info (InfoPlayer perso)
    {
        material = new float[6];
        material[0] = perso.material[0];
        material[1] = perso.material[1];
        material[2] = perso.material[2];
        material[3] = perso.material[3];
        material[4] = perso.material[4];
        material[5] = perso.material[5];

        nomeMax = perso.persoMax;
        pontoMax = perso.maxRush;

        bloqueados = new bool[6];
        bloqueados[0] = perso.unlock[0];
        bloqueados[1] = perso.unlock[1];
        bloqueados[2] = perso.unlock[2];
        bloqueados[3] = perso.unlock[3];
        bloqueados[4] = perso.unlock[4];
        bloqueados[5] = perso.unlock[5];
    }
}
