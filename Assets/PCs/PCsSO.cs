using UnityEngine;

[CreateAssetMenu(fileName = "New Playable Character", menuName = "Character")]
public class PCsSO : ScriptableObject
{
    //Necessidades personagem  
    public int id;
    public string nome;
    public string nickName;
    public int material; //1==Papel, 2==Plastico, 3==Vidro, 4==Metal, 5==Organico
    public Sprite imgMenu;
    public Sprite imgCombate;
    public Sprite Cor;


    //Parte de lore
    public string lore;


    //Personagem para ser liberado
    public int unlockable;


    //Atributos para combate
    public float maxHealth;
    public int maxCharge;
    public int pDamage;
    public int pDefense;
    public int sDamage;
    public int sDefense;


    //Parte de ataques
    public int[] listaAtaquesIniciais = new int[4];
    public int[] listaAtaquesAprendiveis;


    //Modo história
    public int[] regioes = new int[4];
    public EnemiesSO[] inimigos = new EnemiesSO[20];
}
