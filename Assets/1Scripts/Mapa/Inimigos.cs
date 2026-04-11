[System.Serializable]
public class Inimigos
{
    public int id;

    public int vida;
    public int conhecimento;

    public int atqFisico;
    public int atqDistancia;
    public int defFisica;
    public int defDistancia;
    public int velocidade;

    public int[] atq = new int[6];

    public Inimigos(int id, int vida, int conhecimento, int atqFisico, int atqDistancia, int defFisica, int defDistancia, int velocidade, int[] atq)
    {
        this.id = id;
        this.vida = vida;
        this.conhecimento = conhecimento;
        this.atqFisico = atqFisico;
        this.atqDistancia = atqDistancia;
        this.defFisica = defFisica;
        this.defDistancia = defDistancia;
        this.velocidade = velocidade;

        this.atq = atq;
        
    }
}
