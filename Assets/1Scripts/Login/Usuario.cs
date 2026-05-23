[System.Serializable]
public class Usuario
{
    public string nome;
    public string email;

    public Usuario(string nome, string email)
    {
        this.nome = nome;
        this.email = email;
    }
}