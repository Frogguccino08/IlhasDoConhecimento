using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Descricao : MonoBehaviour
{
    //Chamado de outros objetos
    public AttacksEfeitos list;
    public PersonagemSelecionado perso;
    public Player player;
    public Scene cena;
    public AttacksList lista;

    //Variáveis dos ataques
    public string nome;
    public string descA;
    public int materialA;
    public int danoA;
    public bool phispe;
    public bool alvo;
    public int quantidade;
    public int cargaA;
    public bool temEfeito;
    public bool isPassiva;
    //lista.CriarAtaques(Id, nome, descA, material, dano, phispe, alvo, quantidade, carga, temEfeito, isPassiva);

    //Chamado de objetos dentro da própria descrição
    public TMP_Text nomeAtq;
    public TMP_Text material;
    public Image imgMaterial;
    public TMP_Text phispepas;
    public TMP_Text carga;
    public TMP_Text dano;
    public TMP_Text desc;

    //Variável
    public int rEmConta = 0;
    public bool upgradeAtivo = false;


    //Função responsável por toda a parte de escrever toda a descrição
    public void BotandoDescricao(int id)
    {
        cena = SceneManager.GetActiveScene();

        if (cena.name == "Combate")
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            upgradeAtivo = player.telaUpgradeOn;
        }

        perso = PersonagemSelecionado.instance;
        Attacks ataque = lista.CriarAtaques(id);

        nomeAtq.text = ataque.nome;

        switch (ataque.material)
        {
            case 0:
                material.text = " Sem Material";

                if (perso.perso != null && player.telaUpgradeOn == false)
                {
                    switch (perso.perso.material)
                    {
                        default:
                            material.text = "Sem Material *";
                            break;
                        case 1:
                            material.text = "Papel *";
                            break;
                        case 2:
                            material.text = "Plástico *";
                            break;
                        case 3:
                            material.text = "Vidro *";
                            break;
                        case 4:
                            material.text = "Metal *";
                            break;
                        case 5:
                            material.text = "Orgânico *";
                            break;
                    }
                }

                break;
            case 1:
                material.text = "Papel";
                break;
            case 2:
                material.text = "Plástico";
                break;
            case 3:
                material.text = "Vidro";
                break;
            case 4:
                material.text = "Metal";
                break;
            case 5:
                material.text = "Orgânico";
                break;
        }

        if (ataque.isPassiva == true)
        {
            phispepas.enabled = true;
            phispepas.text = "Pas";
        }
        else
        {
            if (ataque.phispe == true && ataque.dano != 0)
            {
                phispepas.enabled = true;
                phispepas.text = "Fís";
            }
            else if (ataque.phispe == false && ataque.dano != 0)
            {
                phispepas.enabled = true;
                phispepas.text = "Dis";
            }
            else if (ataque.dano == 0)
            {
                phispepas.enabled = false;
            }
        }

        carga.text = "Carga: " + ataque.carga;

        if (ataque.dano != 0 && upgradeAtivo == false)
        {
                if (player == null)
                {
                    dano.enabled = true;
                    dano.text = ataque.quantidade + " x " + ataque.dano;
                    dano.color = Color.black;
                }
                else
                {
                    dano.enabled = true;
                    if (ataque.phispe == true)
                    {
                        dano.text = ataque.quantidade + " x " + (ataque.dano + player.modPhiDamage + rEmConta);

                        if (ataque.dano > ataque.dano + player.modPhiDamage + rEmConta)
                        {
                            dano.color = Color.red;
                        }
                        else if (ataque.dano < ataque.dano + player.modPhiDamage + rEmConta)
                        {
                            dano.color = Color.green;
                        }
                        else
                        {
                            dano.color = Color.black;
                        }
                    }
                    else
                    {
                        dano.text = ataque.quantidade + " x " + (ataque.dano + player.modSpeDamage + rEmConta);

                        if (ataque.dano > ataque.dano + player.modSpeDamage + rEmConta && ataque.dano > 0)
                        {
                            dano.color = Color.red;
                        }
                        else if (ataque.dano > ataque.dano + player.modSpeDamage + rEmConta && ataque.dano < 0)
                        {
                            dano.color = Color.green;
                        }
                        else if (ataque.dano < ataque.dano + player.modSpeDamage + rEmConta && ataque.dano > 0)
                        {
                            dano.color = Color.green;
                        }
                        else if (ataque.dano < ataque.dano + player.modSpeDamage + rEmConta && ataque.dano < 0)
                        {
                            dano.color = Color.red;
                        }
                        else
                        {
                            dano.color = Color.black;
                        }
                    }

                }

        }
        else
        {
            dano.enabled = false;
        }

        desc.text = ataque.desc;
    }
}
