using UnityEngine;

[CreateAssetMenu(fileName = "New enemy", menuName = "Enemy")]
public class EnemiesSO : ScriptableObject
{
    public int id;
    public string nome;
    public int material; //1==Papel, 2==Plastico, 3==Vidro, 4==Metal, 5==Organico
    public Sprite imgPadrao;

    public float maxHealth;
    public int maxCharge;
    public int pDamage;
    public int pDefense;
    public int sDamage;
    public int sDefense;

    public int mainStatus;

    public int[] listaAtaquesNvl1 = new int[6];
    public int[] listaAtaquesNvl2 = new int[6];
    public int[] listaAtaquesNvl3 = new int[6];
}
