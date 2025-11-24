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
    public void BotandoDescricao(int id, bool habilidade)
    {
        cena = SceneManager.GetActiveScene();
        Attacks ataque;

        if (cena.name == "Combate")
        {
            player = GameObject.Find("Player").GetComponent<Player>();
            upgradeAtivo = player.telaUpgradeOn;
        }

        perso = PersonagemSelecionado.instance;
        if (habilidade == false)
        {
            ataque = lista.CriarAtaques(id, false);
        }
        else
        {
            ataque = lista.CriarAtaques(id, true);
        }

        nomeAtq.text = ataque.nome;

        switch (ataque.material)
        {
            case 0:
                material.text = " Sem Material";
                imgMaterial.GetComponent<Image>().color = new Color32(135, 135, 135, 255);

                if (player != null && player.telaUpgradeOn == false)
                {
                    switch (player.materialPlayer)
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
                imgMaterial.GetComponent<Image>().color = new Color32(65, 105, 225, 255);
                break;
            case 2:
                material.text = "Plástico";
                imgMaterial.GetComponent<Image>().color = new Color32(155, 17, 30, 255);
                break;
            case 3:
                material.text = "Vidro";
                imgMaterial.GetComponent<Image>().color = new Color32(0, 100, 0, 255);
                break;
            case 4:
                material.text = "Metal";
                imgMaterial.GetComponent<Image>().color = new Color32(238, 173, 45, 255);
                break;
            case 5:
                material.text = "Orgânico";
                imgMaterial.GetComponent<Image>().color = new Color32(120, 64, 8, 255);
                break;
        }

        if (phispepas != null)
        {
            if (ataque.isPassiva == true)
            {
                phispepas.enabled = true;
                phispepas.text = "Pas";
            }
            else
            {
                if (ataque.phispe == true)
                {
                    phispepas.enabled = true;
                    phispepas.text = "Fís";
                }
                else if (ataque.phispe == false)
                {
                    phispepas.enabled = true;
                    phispepas.text = "Dis";
                }
                else if (ataque.dano == 0)
                {
                    phispepas.enabled = false;
                }
            }
        }

        if (carga != null)
        {
            carga.text = "Carga: " + ataque.carga;
        }

        if (dano != null)
        {
            if (ataque.dano != 0)
            {
                if (player == null)
                {
                    dano.enabled = true;
                    dano.text = ataque.quantidade + " x " + ataque.dano;
                    dano.color = Color.black;
                }
                else if (player != null && player.telaUpgradeOn == true)
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
                        if (ataque.dano > 0)
                            dano.text = ataque.quantidade + " x " + (ataque.dano + player.modPhiDamage + rEmConta);
                        else
                            dano.text = ataque.quantidade + " x " + (ataque.dano + (player.modPhiDamage * -1) + rEmConta);



                        if (ataque.dano > ataque.dano + player.modPhiDamage + rEmConta && ataque.dano > 0)
                        {
                            dano.color = Color.red;
                        }
                        else if (ataque.dano < ataque.dano + player.modPhiDamage + rEmConta && ataque.dano > 0)
                        {
                            dano.color = Color.green;
                        }
                        else if (ataque.dano > ataque.dano + player.modPhiDamage + rEmConta && ataque.dano < 0)
                        {
                            dano.color = Color.green;
                        }
                        else if (ataque.dano < ataque.dano + player.modPhiDamage + rEmConta && ataque.dano < 0)
                        {
                            dano.color = Color.red;
                        }
                        else
                        {
                            dano.color = Color.black;
                        }
                    }
                    else
                    {
                        if (ataque.dano > 0)
                            dano.text = ataque.quantidade + " x " + (ataque.dano + player.modSpeDamage + rEmConta);
                        else
                            dano.text = ataque.quantidade + " x " + (ataque.dano + (player.modSpeDamage * -1) + rEmConta);

                        if (ataque.dano > ataque.dano + player.modSpeDamage + rEmConta && ataque.dano > 0)
                        {
                            dano.color = Color.red;
                        }
                        else if (ataque.dano > ataque.dano + (player.modSpeDamage * -1) + rEmConta && ataque.dano < 0)
                        {
                            dano.color = Color.green;
                        }
                        else if (ataque.dano < ataque.dano + player.modSpeDamage + rEmConta && ataque.dano > 0)
                        {
                            dano.color = Color.green;
                        }
                        else if (ataque.dano < ataque.dano + (player.modSpeDamage * -1) + rEmConta && ataque.dano < 0)
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
        }
        

        desc.text = ataque.desc;
    }
}
