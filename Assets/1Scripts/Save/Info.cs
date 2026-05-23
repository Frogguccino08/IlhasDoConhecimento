using Firebase.Auth;
using UnityEngine;

[System.Serializable]
public class Info
{
    public string username;
    public float[] material;
    public string nomeMax;
    public int pontoMax;
    public bool[] bloqueados;

    public Info (InfoPlayer perso)
    {
        FirebaseUser user = FirebaseAuth.DefaultInstance.CurrentUser;
        username = user != null ? user.DisplayName : "Jogador";

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

    public Info(string username)
    {
        this.username = username;

        material = new float[6];

        for(int i = 0; i < 6; i++)
        {
            material[i] = 0;
        }

        nomeMax = "";

        pontoMax = 0;

        bloqueados = new bool[6];

        bloqueados[0] = true;
        bloqueados[1] = true;
        bloqueados[2] = true;
        bloqueados[3] = true;
        bloqueados[4] = true;
        bloqueados[5] = false;
    }
}
