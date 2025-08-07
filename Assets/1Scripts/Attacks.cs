[System.Serializable]
public class Attacks
{
    public enum Tipo {golpe, suporte, bloqueio, passiva, cura, zero}

    public int id;
    public string nome;
    public string desc;
    public Tipo tipo1;
    public Tipo tipo2;
    public int material; // 0 - personagem, 1 - papel, 2 - plástico, 3 - vidro, 4 - metal, 5 - orgânico
    public int dano;
    public bool phispe; // true = físico, false = especial
    public bool alvo;   // true = inimigo, false = próprio
    public int quantidade;
    public int carga;
    public bool temEfeito;
    public bool isPassiva;

    public Attacks(int id, string nome, string desc, Tipo tipo1, Tipo tipo2, int material, int dano, bool phispe, bool alvo, int quantidade, int carga, bool temEfeito, bool isPassiva)
    {
        this.id = id;
        this.nome = nome;
        this.desc = desc;
        this.tipo1 = tipo1;
        this.tipo2 = tipo2;
        this.material = material;
        this.dano = dano;
        this.phispe = phispe;
        this.alvo = alvo;
        this.quantidade = quantidade;
        this.carga = carga;
        this.temEfeito = temEfeito;
        this.isPassiva = isPassiva;
    }
}
