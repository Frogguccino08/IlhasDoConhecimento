using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string nomePlayer;
    public string nickName;
    public float maxHealth;
    public float currentHealth;
    public int materialPlayer;  //1==Papel, 2==Plastico, 3==Vidro, 4==Metal, 5==Organico
    public int maxCharge;
    public int currentCharge;
    public int currentR;

    //Texto de dano
    public GameObject danoTxt;


    public bool usingR = false;
    public bool using3R = false;
    public bool segundo3R = false;

    //[HideInInspector]
    public int phiDamage;
    //[HideInInspector]
    public int phiDefense;
    //[HideInInspector]
    public int speDamage;
    //[HideInInspector]
    public int speDefense;

    public float modPhiDamage = 0;
    public float modPhiDefense = 0;
    public float modSpeDamage = 0;
    public float modSpeDefense = 0;

    public int[] efeitosAtivos = new int[19];
    public bool[] efeitosUsados = new bool[19];

    public HealthBar healthbar;
    public TMP_Text text;
    public AttacksEfeitos list;
    public Enemy enemy;
    public TMP_Text textoAtaque;
    public Controle control;
    public ConhecimentoControl controlConheci;
    public AttacksList lista;

    public PersonagemSelecionado perso;
    public PCsSO pc;

    public GameObject descri;
    
    int i;
    public float attackPublic;
    public float danoPublic;
    public int ataqueUsado;
    public int quantBlock;
    public int idAtaqueUsado;
    public bool rAgora;
    public bool telaUpgradeOn = false;
    public bool butaoClicado = false;

    public int[] attackID = new int[6];
    [HideInInspector]
    public string[] nome = new string[6];
    [HideInInspector]
    public string[] desc = new string[6];
    [HideInInspector]
    public int[] material = new int[6];
    [HideInInspector]
    public int[] dano = new int[6];
    [HideInInspector]
    public bool[] phispe = new bool[6];
    [HideInInspector]
    public bool[] alvo = new bool[6];
    [HideInInspector]
    public int[] quantidade = new int[6];
    [HideInInspector]
    public int[] carga = new int[6];
    [HideInInspector]
    public bool[] temEfeito = new bool[6];
    [HideInInspector]
    public bool[] isPassive = new bool[6];



    void Update()
    {
        if (efeitosAtivos[1] > 15)
        {
            efeitosAtivos[1] = 15;
        }

        modPhiDamage = 0;
        enemy.modPhiDefense = 0;
        modSpeDamage = 0;
        enemy.modSpeDefense = 0;

        if (rAgora == true)
        {
            modPhiDamage = 1;
            modSpeDamage = 1;
        }
        

        if (efeitosAtivos[2] > 0) //Aumentar defesa a distancia
        {
            modSpeDefense += 2;
        }
        if (efeitosAtivos[3] > 0) //Aumentar defesa fisica
        {
            modPhiDefense += 2;
        }
        if (efeitosAtivos[4] > 0) //Aumentar ataque a distancia
        {
            modSpeDamage += 1;
        }
        if (efeitosAtivos[5] > 0) //Aumentar ataque fisico
        {
            modPhiDamage += 1;
        }
        if (efeitosAtivos[8] > 0) //Diminuir dano a distancia
        {
            modSpeDamage -= 1;
        }
        if (efeitosAtivos[9] > 0) //Diminuir dano fisico
        {
            modPhiDamage -= 1;
        }
        if (efeitosAtivos[10] > 0) //Diminuir defesa a distancia
        {
            modSpeDefense -= 2;
        }
        if (efeitosAtivos[11] > 0) //Diminuir defesa física
        {
            modPhiDefense -= 2;
        }
    }

    public void InicializarPlayer()
    {
        perso = PersonagemSelecionado.instance;
        pc = perso.perso;

        control.pontMax.text = "Pontuação Máxima: " + perso.pontos;

        nomePlayer = pc.nome;
        nickName = pc.nickName;
        maxHealth = pc.maxHealth;
        materialPlayer = pc.material;

        maxCharge = pc.maxCharge;

        GetComponent<SpriteRenderer>().sprite = pc.imgCombate;


        phiDamage = pc.pDamage;
        phiDefense = pc.pDefense;
        speDamage = pc.sDamage;
        speDefense = pc.sDefense;

        for(i=1; i<19; i++)
        {
            efeitosAtivos[i] = 0;
        }

        currentCharge = 1;
        currentR = 0;
        currentHealth = maxHealth;
        healthbar.MaximoVida(maxHealth);
        text.text = nickName + " " + currentHealth + "/" + maxHealth;
        healthbar.MudarBarra(currentHealth);
        

        for(i=0; i<4; i++)
        {
            attackID[i] = pc.listaAtaquesIniciais[i];
        }

        AtaquesSelecionados();
        controlConheci.SpawnConhecimento(maxCharge, currentCharge);

        if(efeitosAtivos[7] > 0 )
        {
            quantBlock = efeitosAtivos[1];
        }
        
        for(i = 0; i < 6; i++)
        {
            if(isPassive[i] == true)
            {
                list.AtaquesComEfeitos(true, attackID[i], 6, this, enemy);
            }
        }

        if(efeitosAtivos[7] > 0 && quantBlock < efeitosAtivos[1])
        {
            int num = efeitosAtivos[1] - quantBlock;
            efeitosAtivos[1] = quantBlock;

            for (int i = 0; i < num; i++)
            {
                if (efeitosAtivos[7] > 0)
                {
                    efeitosAtivos[7] -= 1;
                }
                else
                {
                    efeitosAtivos[1] += 1;
                }
            }
        }
    }


    public void CausarDano(float attackDamage)
    {
        currentHealth -= attackDamage;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }else if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthbar.MudarBarra(currentHealth);
        text.text = nickName + " " + currentHealth + "/" + maxHealth;
    }


    public IEnumerator Morto()
    {
        control.turno = 0;
        control.inimigoTurno.text = "Inimigo: " + control.inimigoAtual +"       Turno: " + control.turno;
        control.DesativarBotao();
        control.texto.text = "Você foi derrotado\nEsperando input para voltar ao menu";

        if(control.pontosRodada >= perso.pontos)
        {
            perso.pontos = control.pontosRodada;
        }

        yield return new WaitForSeconds(0.01f);
    }


    public void AtaquesSelecionados()
    {
        for (int i = 0; i < 6; i++)
        {
            Attacks ataque = lista.CriarAtaques(attackID[i]);

            attackID[i] = ataque.id;
            nome[i] = ataque.nome;
            desc[i] = ataque.desc;
            material[i] = ataque.material;
            dano[i] = ataque.dano;
            phispe[i] = ataque.phispe;
            alvo[i] = ataque.alvo;
            quantidade[i] = ataque.quantidade;
            carga[i] = ataque.carga;
            temEfeito[i] = ataque.temEfeito;
            isPassive[i] = ataque.isPassiva;
        }
    }

    public IEnumerator UsarAtaque(int id)
    {
        int materialSemNome;
        if (material[id] == 0)
        {
            materialSemNome = materialPlayer;
        }
        else
        {
            materialSemNome = material[id];
        }

        descri.SetActive(false);
        descri.GetComponent<Descricao>().rEmConta = 0;

        if (using3R == false)
        {
            currentCharge -= carga[id];
            controlConheci.SpawnConhecimento(maxCharge, currentCharge);
        }

        float attackDamage = 0;
        idAtaqueUsado = id;
        ataqueUsado = attackID[id];

        rAgora = false;

        Debug.Log("Ataque usado: " + nome[id]);


        if (alvo[id] == true && dano[id] > 0 && usingR == false && using3R == false)
        {
            if (currentR < 3)
            {
                currentR++;
                controlConheci.SpawnRs();
            }
        }

        if (usingR == true)
        {
            rAgora = true;
            usingR = false;
            currentR -= 1;
            controlConheci.SpawnRs();
        }
        
        if (efeitosAtivos[7] > 0)
        {
            quantBlock = efeitosAtivos[1];
        }

        list.AtaquesComEfeitos(true, (perso.regiao + 1) * -1, 0, this, enemy);
        list.AtaquesComEfeitos(true, (pc.id + 10) * -1, 0, this, enemy);

        list.AtaquesComEfeitos(true, attackID[id], 0, this, enemy);

        for (i = 0; i < 6; i++)
        {
            if (isPassive[i] == true)
            {
                list.AtaquesComEfeitos(true, attackID[i], 0, this, enemy);
            }
        }

        for (i = 0; i < 6; i++)
        {
            if (enemy.isPassive[i] == true)
            {
                enemy.list.AtaquesComEfeitos(false, enemy.attackID[i], 1, this, enemy);
            }
        }

        if (efeitosAtivos[7] > 0 && quantBlock < efeitosAtivos[1])
        {
            int num = efeitosAtivos[1] - quantBlock;
            efeitosAtivos[1] = quantBlock;

            for (int i = 0; i < num; i++)
            {
                if (efeitosAtivos[7] > 0)
                {
                    efeitosAtivos[7] -= 1;
                }
                else
                {
                    efeitosAtivos[1] += 1;
                }
            }
        }


        //Caso cause dano
        for (int quant = 0; quant < quantidade[id]; quant++)
        {
            if (alvo[id] == true)
            {
                if (dano[id] != 0)
                {
                    //yield return StartCoroutine(enemy.CorDano(id));

                    if (phispe[id] == true)
                    {
                        if (dano[id] > 0)
                        {
                            attackDamage = Mathf.Round((float)phiDamage * (modPhiDamage + dano[id]) * UnityEngine.Random.Range(0.9f, 1.1f) - (enemy.phiDefense + enemy.modPhiDefense));
                        }
                        else if (dano[id] < 0)
                        {
                            attackDamage = Mathf.Round((float)phiDamage * ((modPhiDamage * -1) + dano[id]) * UnityEngine.Random.Range(0.9f, 1.1f) + (enemy.phiDefense + enemy.modPhiDefense));
                        }

                        if (materialSemNome == enemy.materialInimigo)
                        {
                            attackDamage = Mathf.Round(attackDamage * 0.8f);
                        }
                        if (attackDamage <= 0 && dano[id] > 0)
                        {
                            attackDamage = 1;
                        }
                        Debug.Log("Dano causado foi físico");
                    }
                    else if (phispe[id] == false)
                    {
                        if (dano[id] > 0)
                        {
                            attackDamage = Mathf.Round((float)speDamage * (modSpeDamage + dano[id]) * UnityEngine.Random.Range(0.9f, 1.1f) - (enemy.speDefense + enemy.modSpeDefense));
                        }
                        else if (dano[id] < 0)
                        {
                            attackDamage = Mathf.Round((float)speDamage * ((modSpeDamage * -1) + dano[id]) * UnityEngine.Random.Range(0.9f, 1.1f) - (enemy.speDefense - enemy.modSpeDefense));
                        }

                        if (materialSemNome == enemy.materialInimigo)
                        {
                            attackDamage = Mathf.Round(attackDamage * 0.8f);
                        }
                        if (attackDamage <= 0 && dano[id] > 0)
                        {
                            attackDamage = 1;
                        }
                        Debug.Log("Dano causado foi especial");
                    }

                    yield return StartCoroutine(enemy.CorDano(id, attackDamage));

                    if (enemy.efeitosAtivos[1] > 0)
                    {
                        EfeitoCausado(0, attackDamage, dano[id]);
                        attackDamage = 0;
                    }
                    else
                    {
                        Debug.Log("Dano causado ou curado: " + attackDamage);
                        enemy.CausarDano(attackDamage);
                    }

                    if (enemy.currentHealth <= 0)
                    {
                        rAgora = false;

                        if (using3R == true)
                        {
                            segundo3R = false;
                            currentR = 0;
                            controlConheci.SpawnRs();
                            using3R = false;
                            textoAtaque.text = nickName + " usou: " + nome[id] + " DUAS VEZES!!!";
                        }
                        else
                        {
                            textoAtaque.text = nickName + " usou: " + nome[id];
                        }

                        enemy.GetComponent<SpriteRenderer>().enabled = false;
                        StartCoroutine(control.Turno(false));
                        yield break;
                    }

                }
                else
                {
                    Debug.Log("Esse ataque não causa dano");
                }
            }
            else if (alvo[id] == false)
            {
                if (dano[id] != 0)
                {
                    //StartCoroutine(CorDanoSelf(id, attackDamage));

                    if (phispe[id] == true)
                    {
                        if (dano[id] > 0)
                        {
                            attackDamage = Mathf.Round((float)phiDamage * (modPhiDamage + dano[id]) * (UnityEngine.Random.Range(0.8f, 1.2f)));
                        }
                        else if (dano[id] < 0)
                        {
                            attackDamage = Mathf.Round((float)phiDamage * ((modPhiDamage * -1) + dano[id]) * (UnityEngine.Random.Range(0.8f, 1.2f)));
                        }

                        if (attackDamage <= 0 && dano[id] > 0)
                        {
                            attackDamage = 1;
                        }
                        Debug.Log("Dano causado foi físico");
                    }
                    else if (phispe[id] == false)
                    {
                        if (dano[id] > 0)
                        {
                            attackDamage = Mathf.Round((float)speDamage * (modSpeDamage + dano[id]) * (UnityEngine.Random.Range(0.8f, 1.2f)));
                        }
                        else if (dano[id] < 0)
                        {
                            attackDamage = Mathf.Round((float)speDamage * ((modSpeDamage * -1) + dano[id]) * (UnityEngine.Random.Range(0.8f, 1.2f)));
                        }

                        if (attackDamage <= 0 && dano[id] > 0)
                        {
                            attackDamage = 1;
                        }
                        Debug.Log("Dano causado foi especial");
                    }

                    StartCoroutine(CorDanoSelf(id, attackDamage));

                    Debug.Log("Dano causado ou curado: " + attackDamage);
                    CausarDano(attackDamage);
                }
                else
                {
                    Debug.Log("Esse ataque não causa dano");
                }
            }

            danoPublic = attackDamage;



            if (efeitosAtivos[7] > 0)
            {
                quantBlock = efeitosAtivos[1];
            }

            list.AtaquesComEfeitos(true, (perso.regiao + 1) * -1, 2, this, enemy);
            list.AtaquesComEfeitos(true, (pc.id + 10) * -1, 2, this, enemy);

            if (temEfeito[id] == true)
            {
                list.AtaquesComEfeitos(true, attackID[id], 2, this, enemy);
            }
            for (i = 0; i < 6; i++)
            {
                if (isPassive[i] == true)
                {
                    list.AtaquesComEfeitos(true, attackID[i], 2, this, enemy);
                }
            }

            for (i = 0; i < 6; i++)
            {
                if (enemy.isPassive[i] == true)
                {
                    enemy.list.AtaquesComEfeitos(false, enemy.attackID[i], 3, this, enemy);
                }
            }

            if (efeitosAtivos[7] > 0 && quantBlock < efeitosAtivos[1])
            {
                int num = efeitosAtivos[1] - quantBlock;
                efeitosAtivos[1] = quantBlock;

                for (int i = 0; i < num; i++)
                {
                    if (efeitosAtivos[7] > 0)
                    {
                        efeitosAtivos[7] -= 1;
                    }
                    else
                    {
                        efeitosAtivos[1] += 1;
                    }
                }
            }
        }

        rAgora = false;

        textoAtaque.text = nickName + " usou: " + nome[id];

        if (using3R == false)
            {
                if (dano[id] == 0)
                {
                    yield return StartCoroutine(control.EsperarTeclaEspaco());
                }
                StartCoroutine(control.Turno(false));
            }
            else if (using3R == true)
            {
                using3R = false;
                if (dano[id] != 0)
                {
                    currentR = -1;
                }
                else
                {
                    currentR = 0;
                }
                segundo3R = true;
                controlConheci.SpawnRs();
                yield return StartCoroutine(UsarAtaque(id));
                
            }
        
        control.AtaqueFeito();
        butaoClicado = false;
        if (segundo3R == true)
        {
            textoAtaque.text = nickName + " usou: " + nome[id] + " DUAS VEZES!!!";
        }
        segundo3R = false; 
    }

    public void EfeitoCausado(int i, float attackDamage, int dano)
    {
        for(int us = 1; us < 19; us++)
        {
            efeitosUsados[us] = false;
        }

        if(i == 0) //logo após calcular o dano
        {
            //0. Bloqueio
            if(enemy.efeitosAtivos[1] > 0)
            {
                if(dano > 0)
                {
                    attackDamage = 0;
                    Debug.Log("Ataque bloqueado");
                    enemy.efeitosAtivos[1] -= 1;
                }
            }
        }

        if(i == 1) //No final do turno
        {
            //entre 2 e 12 (Todos os efeitos que passam no final do turno)
            for(int fo = 2; fo <= 12; fo++)
            {
                if(efeitosAtivos[fo] > 0)
                {
                    efeitosAtivos[fo] -= 1;
                }
            }

            //16.Cacos
            if(efeitosAtivos[16] > 0)
            {
                attackDamage = Mathf.Round(maxHealth * 0.125f);
                CausarDano(attackDamage);
                Debug.Log(attackDamage + " Dano causado pelos cacos");
                efeitosAtivos[16] -= 1;
                textoAtaque.text = "Dano recebido por cacos";
                efeitosUsados[16] = true;
            }
        }
        if(i == 2) //No final do turno tbm só que separado pro nutrindo
        {
            //18.Nutrindo
            if(efeitosAtivos[18] > 0)
            {
                attackDamage = Mathf.Round((maxHealth * 0.125f) * -1);
                CausarDano(attackDamage);
                Debug.Log(attackDamage + "Vida Recuperada pelo nutrindo");
                efeitosAtivos[18] -= 1;
                textoAtaque.text = "Vida Recuperada pelo nutrindo";
                efeitosUsados[18] = true;
            }
        }
    }

    public IEnumerator CorDano(int id, float danoAqui)
    {
        GameObject obj;

        obj = Instantiate(danoTxt, transform.position, Quaternion.identity);
        obj.GetComponent<DanoTxt>().dano = danoAqui;
        if (efeitosAtivos[1] > 0)
        {
            danoAqui = 0;
            obj.GetComponent<DanoTxt>().dano = danoAqui;
        }
        obj.transform.SetParent(GameObject.Find("Canvas").transform);

        if (enemy.dano[id] > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if(enemy.dano[id] > 0 && efeitosAtivos[1] > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if(enemy.dano[id] < 0)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }

            yield return new WaitForSeconds(0.2f);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.1f);
    }
    
    public IEnumerator CorDanoSelf(int id, float danoAqui)
    {
        GameObject obj;

        obj = Instantiate(danoTxt, transform.position, Quaternion.identity);
        obj.GetComponent<DanoTxt>().dano = danoAqui;
        obj.transform.SetParent(GameObject.Find("Canvas").transform);

        if (dano[id] > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if(dano[id] > 0 && efeitosAtivos[1] > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if(dano[id] < 0)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }

            yield return new WaitForSeconds(0.2f);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.1f);
    }
}