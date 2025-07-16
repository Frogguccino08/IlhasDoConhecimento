using System.Collections.Generic;
using UnityEngine;

public class AttacksList : MonoBehaviour
{
    public static List<Attacks> listaAtaques = new List<Attacks>();
    public Attacks attacks;

    void Awake()
    {
        //int Id, string Nome, string Desc, int Material, int Dano, bool Phispe, bool Alvo, int Quantidade, int Carga, bool TemEfeito, bool IsPassiva
        listaAtaques.Add(new Attacks(0, "- -", "Esse ataque não existe", 0, 0, true, true, 0, 0, false, false));
        listaAtaques.Add(new Attacks(1, "- -1", "Esse ataque não existe", 0, 0, true, true, 0, 0, false, false));
    }

    public void CriarAtaques(int Id, string Nome, string Desc, int Material, int Dano, bool Phispe, bool Alvo, int Quantidade, int Carga, bool TemEfeito, bool IsPassiva)
    {
        Id = listaAtaques[Id].id;
        Nome = listaAtaques[Id].nome;
        Desc = listaAtaques[Id].desc;
        Material = listaAtaques[Id].material;
        Dano = listaAtaques[Id].dano;
        Phispe = listaAtaques[Id].phispe;
        Alvo = listaAtaques[Id].alvo;
        Quantidade = listaAtaques[Id].quantidade;
        Carga = listaAtaques[Id].carga;
        TemEfeito = listaAtaques[Id].temEfeito;
        IsPassiva = listaAtaques[Id].isPassiva;
    }
}
