[System.Serializable]
public class Attacks
{
    public int id;
    public string nome;
    public string desc;
    public int material; // 0 - personagem, 1 - papel, 2 - plástico, 3 - vidro, 4 - metal, 5 - orgânico
    public int dano;
    public bool phispe; // true = físico, false = especial
    public bool alvo;   // true = inimigo, false = próprio
    public int quantidade;
    public int carga;
    public bool temEfeito;
    public bool isPassiva;

    public Attacks(int id, string nome, string desc, int material, int dano, bool phispe, bool alvo, int quantidade, int carga, bool temEfeito, bool isPassiva)
    {
        this.id = id;
        this.nome = nome;
        this.desc = desc;
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
