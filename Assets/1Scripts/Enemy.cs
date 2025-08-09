using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string nomeinimigo;

    public float maxHealth;
    public float currentHealth;
    public int maxCharge;
    public int currentCharge;


    public int materialInimigo;  //1==Papel, 2==Plastico, 3==Vidro, 4==Metal, 5==Organico


    //Efeito de dano
    public GameObject danoTxt;

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
    public AttacksEfeitos list;
    public EnemyList enemyList;
    public Player enemy;
    public Controle control;
    public TMP_Text textoAtaque;
    public GameObject simBoss;
    public TMP_Text nomeTela;
    public AttacksList lista;

    public GameObject upgrade;

    public TelaUpgrade[] novosAtaques = new TelaUpgrade[3];
    public TelaUpgrade[] ataquesAntigos = new TelaUpgrade[6];


    int i;
    public float attackPublic;
    public float danoPublic;
    public int ataqueUsado;
    public int quantBlock;
    public int idAtaqueUsado;

    int cont;
    public int forcaAtual = 0;
    bool isBoss = false;
    public EnemiesSO inimigoEscolhido;
    public PersonagemSelecionado escolha;
    public SpriteRenderer cor;

    public int[] attackID = new int[6];
    [HideInInspector]
    int[] chance = new int[6];
    [HideInInspector]
    public string[] nome = new string[6];
    [HideInInspector]
    public string[] desc = new string[6];
    [HideInInspector]
    public Attacks.Tipo[] tipo1 = new Attacks.Tipo[6];
    [HideInInspector]
    public Attacks.Tipo[] tipo2 = new Attacks.Tipo[6];
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
    [HideInInspector]
    public int maximo = 0;


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

    public void InicializarInimigo()
    {
        escolha = PersonagemSelecionado.instance;

        if (control.inimigoAtual == 1)
        {
            forcaAtual = 0;
        }

        if (control.inimigoAtual % 5 == 0)
        {
            simBoss.SetActive(true);
            isBoss = true;
        }
        else
        {
            simBoss.SetActive(false);
            isBoss = false;
        }


        for (i = 0; i < 6; i++)
        {
            attackID[i] = 0;
        }

        for (i = 1; i < 19; i++)
        {
            efeitosAtivos[i] = 0;
        }

        switch (escolha.regiao)
        {
            case 0: //costa
                if (control.inimigoAtual < 5)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.costaDeCacosNL1[UnityEngine.Random.Range(0, enemyList.costaDeCacosNL1.Count)];
                }
                else if (control.inimigoAtual >= 5 && control.inimigoAtual < 10)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.costaDeCacosNL2[UnityEngine.Random.Range(0, enemyList.costaDeCacosNL2.Count)];
                }
                else if (control.inimigoAtual >= 10)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.costaDeCacosNL3[UnityEngine.Random.Range(0, enemyList.costaDeCacosNL3.Count)];
                }
                break;

            case 1: //coração
                if (control.inimigoAtual < 5)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.coracaoDaIlhaNL1[UnityEngine.Random.Range(0, enemyList.coracaoDaIlhaNL1.Count)];
                }
                else if (control.inimigoAtual >= 5 && control.inimigoAtual < 10)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.coracaoDaIlhaNL2[UnityEngine.Random.Range(0, enemyList.coracaoDaIlhaNL2.Count)];
                }
                else if (control.inimigoAtual >= 10)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.coracaoDaIlhaNL3[UnityEngine.Random.Range(0, enemyList.coracaoDaIlhaNL3.Count)];
                }
                break;

            case 2: //comunidade
                if (control.inimigoAtual < 5)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.comunidadeAbandonadaNL1[UnityEngine.Random.Range(0, enemyList.comunidadeAbandonadaNL1.Count)];
                }
                else if (control.inimigoAtual >= 5 && control.inimigoAtual < 10)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.comunidadeAbandonadaNL2[UnityEngine.Random.Range(0, enemyList.comunidadeAbandonadaNL2.Count)];
                }
                else if (control.inimigoAtual >= 10)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.comunidadeAbandonadaNL3[UnityEngine.Random.Range(0, enemyList.comunidadeAbandonadaNL3.Count)];
                }
                break;

            case 3: //arquivos
                if (control.inimigoAtual < 5)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.osArquivosNL1[UnityEngine.Random.Range(0, enemyList.osArquivosNL1.Count)];
                }
                else if (control.inimigoAtual >= 5 && control.inimigoAtual < 10)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.osArquivosNL2[UnityEngine.Random.Range(0, enemyList.osArquivosNL2.Count)];
                }
                else if (control.inimigoAtual >= 10)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.osArquivosNL3[UnityEngine.Random.Range(0, enemyList.osArquivosNL3.Count)];
                }
                break;

            case 4: //floresta
                if (control.inimigoAtual < 5)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.florestaCompostaNL1[UnityEngine.Random.Range(0, enemyList.florestaCompostaNL1.Count)];
                }
                else if (control.inimigoAtual >= 5 && control.inimigoAtual < 10)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.florestaCompostaNL2[UnityEngine.Random.Range(0, enemyList.florestaCompostaNL2.Count)];
                }
                else if (control.inimigoAtual >= 10)
                {
                    inimigoEscolhido = (EnemiesSO)enemyList.florestaCompostaNL3[UnityEngine.Random.Range(0, enemyList.florestaCompostaNL3.Count)];
                }
                break;
        }

        //Funcionalidade para todo o inimigo
        modPhiDamage = 0;
        modPhiDefense = 0;
        modSpeDamage = 0;
        modSpeDefense = 0;

        nomeinimigo = inimigoEscolhido.nome;
        nomeTela.text = nomeinimigo;
        maxHealth = inimigoEscolhido.maxHealth + (inimigoEscolhido.maxHealth * forcaAtual);
        maxCharge = inimigoEscolhido.maxCharge + (forcaAtual * 2);
        materialInimigo = inimigoEscolhido.material;

        phiDamage = inimigoEscolhido.pDamage + forcaAtual;
        phiDefense = inimigoEscolhido.pDefense + forcaAtual;
        speDamage = inimigoEscolhido.sDamage + forcaAtual;
        speDefense = inimigoEscolhido.sDefense + forcaAtual;

        switch (inimigoEscolhido.mainStatus)
        {
            case 0:
                maxHealth += inimigoEscolhido.maxHealth * forcaAtual;
                if (isBoss)
                {
                    maxHealth += inimigoEscolhido.maxHealth;
                }
                break;
            case 1:
                phiDamage += forcaAtual;
                if (isBoss)
                {
                    phiDamage += 1;
                }
                break;
            case 2:
                phiDefense += forcaAtual;
                if (isBoss)
                {
                    phiDefense += 1;
                }
                break;
            case 3:
                speDamage += forcaAtual;
                if (isBoss)
                {
                    speDamage += 1;
                }
                break;
            case 4:
                speDefense += forcaAtual;
                if (isBoss)
                {
                    speDefense += 1;
                }
                break;
        }

        //Coisa de boss
        if (isBoss)
        {
            maxHealth *= 2;
            maxCharge += 2;
            phiDamage += 1 + forcaAtual;
            phiDefense += 1 + forcaAtual;
            speDamage += 1 + forcaAtual;
            speDefense += 1 + forcaAtual;
        }

        cont = 0;
        for (cont = 0; cont < 6; cont++)
        {
            if (control.inimigoAtual < 5)
            {
                attackID[cont] = inimigoEscolhido.listaAtaquesNvl1[cont];
            }
            else if (control.inimigoAtual >= 5 && control.inimigoAtual < 10)
            {
                attackID[cont] = inimigoEscolhido.listaAtaquesNvl2[cont];
            }
            else if (control.inimigoAtual >= 10)
            {
                attackID[cont] = inimigoEscolhido.listaAtaquesNvl3[cont];
            }

            Debug.Log(attackID[cont]);

            for (int sla = 0; sla < 6; sla++)
            {
                if (cont != sla && attackID[cont] == attackID[sla] && attackID[cont] != 0)
                {
                    attackID[sla] = 0;
                    break;
                }
            }
        }

        currentHealth = maxHealth;
        currentCharge = 1;
        healthbar.MaximoVida(maxHealth);
        healthbar.MudarBarra(currentHealth);
        AtaquesSelecionados();

        if (efeitosAtivos[7] > 0)
        {
            quantBlock = efeitosAtivos[1];
        }

        list.AtaquesComEfeitos(true, (escolha.perso.id + 10) * -1, 6, enemy, this);
        list.AtaquesComEfeitos(true, (escolha.regiao + 1) * -1, 6, enemy, this);
        list.AtaquesComEfeitos(false, (escolha.regiao + 1) * -1, 6, enemy, this);

        for (i = 0; i < 6; i++)
        {
            if (isPassive[i] == true)
            {
                list.AtaquesComEfeitos(false, attackID[i], 6, enemy, this);
            }

            if (enemy.isPassive[i] == true && control.turno != 0 && control.turno != 1)
            {
                if (control.inimigoAtual > 1)
                {
                    enemy.list.AtaquesComEfeitos(true, attackID[i], 6, enemy, this);
                }
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

        if (inimigoEscolhido.imgPadrao != null)
        {
            GetComponent<SpriteRenderer>().sprite = inimigoEscolhido.imgPadrao;
        }

        GetComponent<SpriteRenderer>().enabled = true;
        cor.enabled = true;

        if (inimigoEscolhido.cor != null)
        {
            cor.sprite = inimigoEscolhido.cor;
            CorDetalhes();
        }
    }


    public void CausarDano(float attackDamage)
    {
        currentHealth -= attackDamage;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthbar.MudarBarra(currentHealth);
    }


    public IEnumerator Morto()
    {
        control.ColocarPontosInimigoDerrotado();

        if (control.inimigoAtual % 5 == 0)
        {
            forcaAtual += 1;
        }

        control.turno = 0;
        control.inimigoTurno.text = "Inimigo: " + control.inimigoAtual + "       Turno: " + control.turno;
        control.DesativarBotao();
        control.texto.text = "INIMIGO PURIFICADO\nEsperando input";

        while (!Input.GetKeyUp(KeyCode.Space) && !Input.GetKeyUp(KeyCode.Mouse0))
        {
            yield return null;
        }

        if (control.inimigoAtual == ((forcaAtual * 5) + 2) || control.inimigoAtual == ((forcaAtual * 5) + 4) || control.inimigoAtual == ((forcaAtual * 5) + 1))
        {
            enemy.telaUpgradeOn = true;
            control.texto.enabled = false;
            upgrade.SetActive(true);
            for (i = 0; i < 3; i++)
            {
                novosAtaques[i].FazerAtaques();

            }
            for (i = 0; i < 6; i++)
            {
                ataquesAntigos[i].FazerAtaquesAntigo(i);
            }

            upgrade.GetComponent<TelaUpgrade>().telaInicial.SetActive(true);
            upgrade.GetComponent<TelaUpgrade>().telaAtaques.SetActive(false);
            upgrade.GetComponent<TelaUpgrade>().telaAtributos.SetActive(false);
            yield return control.TelaUpgrade();
        }


        InicializarInimigo();
        enemy.currentCharge = Mathf.Min(enemy.currentCharge + 2, enemy.maxCharge);
        enemy.controlConheci.SpawnConhecimento(enemy.maxCharge, enemy.currentCharge);
        control.AtivarBotao();
        control.texto.enabled = false;
    }

    void AtaquesSelecionados()
    {
        for (i = 0; i < 6; i++)
        {
            Attacks ataque = lista.CriarAtaques(attackID[i]);
            nome[i] = ataque.nome;
            desc[i] = ataque.desc;
            tipo1[i] = ataque.tipo1;
            tipo2[i] = ataque.tipo2;
            material[i] = ataque.material;
            dano[i] = ataque.dano;
            phispe[i] = ataque.phispe;
            alvo[i] = ataque.alvo;
            quantidade[i] = ataque.quantidade;
            carga[i] = ataque.carga;
            temEfeito[i] = ataque.temEfeito;
            isPassive[i] = ataque.isPassiva;

            //Debug.Log("Ataque selecionado Id: " + attackID[i] + " (" + nome[i] + ")");
        }
    }

    public IEnumerator UsarAtaque(int id)
    {
        int materialSemNome;
        if (material[id] == 0)
        {
            materialSemNome = materialInimigo;
        }
        else
        {
            materialSemNome = material[id];
        }

        currentCharge -= carga[id];

        float attackDamage = 0;
        idAtaqueUsado = id;
        ataqueUsado = attackID[id];

        if (efeitosAtivos[7] > 0)
        {
            quantBlock = efeitosAtivos[1];
        }

        list.AtaquesComEfeitos(false, (escolha.regiao + 1) * -1, 0, enemy, this);

        list.AtaquesComEfeitos(false, attackID[id], 0, enemy, this);
        for (i = 0; i < 6; i++)
        {
            if (isPassive[i] == true)
            {
                list.AtaquesComEfeitos(false, attackID[i], 0, enemy, this);
            }
        }

        list.AtaquesComEfeitos(true, (escolha.perso.id + 10) * -1, 1, enemy, this);

        for (i = 0; i < 6; i++)
        {
            if (enemy.isPassive[i] == true)
            {
                list.AtaquesComEfeitos(true, enemy.attackID[i], 1, enemy, this);
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


        Debug.Log("Ataque usado: " + nome[id]);

        //Caso cause dano
        for (int quant = 0; quant < quantidade[id]; quant++)
        {
            if (alvo[id] == true)
            {
                if (dano[id] != 0)
                {
                    //yield return StartCoroutine(enemy.CorDano(id, attackDamage));

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

                        if (materialSemNome == enemy.materialPlayer)
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

                        if (materialSemNome == enemy.materialPlayer)
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
                        enemy.cor.enabled = false;
                        enemy.GetComponent<SpriteRenderer>().enabled = false;
                        textoAtaque.text = nomeinimigo + " usou: " + nome[id];
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
                    //StartCoroutine(CorDanoSelf(id));

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

            list.AtaquesComEfeitos(false, (escolha.regiao + 1) * -1, 2, enemy, this);

            if (temEfeito[id] == true)
            {
                list.AtaquesComEfeitos(false, attackID[id], 2, enemy, this);
            }
            for (i = 0; i < 6; i++)
            {
                if (isPassive[i] == true)
                {
                    list.AtaquesComEfeitos(false, attackID[i], 2, enemy, this);
                }
            }


            list.AtaquesComEfeitos(true, (escolha.perso.id + 10) * -1, 3, enemy, this);
            for (i = 0; i < 6; i++)
            {
                if (enemy.isPassive[i] == true)
                {
                    enemy.list.AtaquesComEfeitos(true, enemy.attackID[i], 3, enemy, this);
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

        Fraquezas(id);

        textoAtaque.text = nomeinimigo + " usou: " + nome[id];

    }

    public void EscolherAtaque()
    {
        int ataqueEscolhido;
        maximo = 0;
        int maiorDano = 0;
        int maiorDanoTemporario = 4;
        int maiorCura = 0;
        int maiorCuraTemporario = 4;
        bool temAtaqueFraco = false;

        //Zerando tudo
        for (i = 0; i < 6; i++)
        {
            chance[i] = 0;
        }
        maximo = 0;

        //Colocando chance nos ataques e regras para mudar a chance
        for (i = 0; i < 6; i++)
        {
            if (attackID[i] != 0)
            {
                chance[i] += 25;
            }
        }

        //regra 0: Conferir se ele tem um ataque que causa dano e tem 1 ou menos de carga
        for (i = 0; i < 6; i++)
        {
            if (attackID[i] != 0 && alvo[i] == true && dano[i] > 0 && carga[i] <= 1)
            {
                temAtaqueFraco = true;
            }
        }

        //regra 1: Ataque com maior dano mais chance
        for (i = 0; i < 6; i++)
        {
            if (attackID[i] != 0 && alvo[i] == true && dano[i] > 0 && currentCharge >= carga[i])
            {
                if (dano[i] * quantidade[i] > maiorDano)
                {
                    maiorDano = dano[i] * quantidade[i];
                    maiorDanoTemporario = i;
                }
            }
        }
        if (maiorDanoTemporario != 6 && nome[maiorDanoTemporario] != "- -")
        {
            chance[maiorDanoTemporario] += 25;
            Debug.Log(nome[maiorDanoTemporario] + " chance aumentada por ser o maior dano");
        }

        //regra 2: Ataque com maior cura mais chance
        for (i = 0; i < 6; i++)
        {
            int subida = 0;

            if (attackID[i] != 0 && alvo[i] == false && dano[i] < 0 && currentCharge >= carga[i])
            {
                if (tipo1[i] == Attacks.Tipo.cura || tipo2[i] == Attacks.Tipo.cura)
                {
                    subida = 2;
                }
                if (dano[i] * quantidade[i] - subida < maiorCura)
                {
                    maiorCura = dano[i] * quantidade[i];
                    maiorCuraTemporario = i;
                }
            }
        }
        if (maiorCuraTemporario != 6 && nome[maiorCuraTemporario] != "- -")
        {
            chance[maiorCuraTemporario] += 25;
            Debug.Log(nome[maiorCuraTemporario] + " chance aumentada por ser a maior cura");
        }

        //regra 3: Ataques de cura caso abaixo de 50% vida mais chance
        for (i = 0; i < 6; i++)
        {
            if (attackID[i] != 0 && alvo[i] == false && (dano[i] < 0 || tipo1[i] == Attacks.Tipo.cura || tipo2[i] == Attacks.Tipo.cura) && currentHealth <= (maxHealth / 4))
            {
                chance[i] += 25;
                Debug.Log(nome[i] + " Chance aumentada por estar abaixo de 50% de vida e ser uma cura");
            }
        }

        //regra 4: ataques com efeito tem mais chance de usar nos primeiros 2 turnos
        for (i = 0; i < 6; i++)
        {
            if (attackID[i] != 0 && control.turno < 5 && temEfeito[i] == true)
            {
                chance[i] += 25;
                Debug.Log(nome[i] + " Chance aumentada por ser um dos dois primeiros turnos e ser um ataque de status");
            }
        }

        //regra 5: Ataques de cura são evitados com bastante vida
        for (i = 0; i < 6; i++)
        {
            if (attackID[i] != 0 && (dano[i] < 0 || tipo1[i] == Attacks.Tipo.cura || tipo2[i] == Attacks.Tipo.cura) && currentHealth >= (maxHealth / 4))
            {
                Debug.Log(nome[i] + " Chance diminuida por ser cura com bastante vida");
                chance[i] -= 25;
            }
        }

        //regra 6: Ataques de cura são evitados após 40 turnos
        for (i = 0; i < 6; i++)
        {
            if (attackID[i] != 0 && (dano[i] < 0 || tipo1[i] == Attacks.Tipo.cura || tipo2[i] == Attacks.Tipo.cura) && control.turno >= 40)
            {
                Debug.Log(nome[i] + " chance diminuida por ser uma cura depois de 40 turnos");
                chance[i] -= 25;
            }
        }

        //regra final 1: Se é passiva não tem como escolher
        for (i = 0; i < 6; i++)
        {
            if (attackID[i] != 0 && isPassive[i] == true)
            {
                Debug.Log(nome[i] + " Chance eliminada por ser passiva");
                chance[i] = 0;
            }
        }

        //regra final 2: Se carga maior que currentcharge não tem como escolher
        for (i = 0; i < 6; i++)
        {
            if (attackID[i] != 0 && currentCharge < carga[i])
            {
                Debug.Log(nome[i] + " Chance eliminada por não ter carga o suficiente");
                chance[i] = 0;
            }
        }

        //Regra final 3: Ataques com chance negativa viram zero
        for (i = 0; i < 6; i++)
        {
            if (attackID[i] != 0 && chance[i] < 0)
            {
                Debug.Log(nome[i] + " Chance zerada por estar negativa");
                chance[i] = 0;
            }
        }


        for (i = 0; i < 6; i++)
        {
            Debug.Log("Chance do ataque " + i + ": " + chance[i]);
        }

        //Regra final 4: Caso tenha algum ataque com mais carga do que tem atualmente chance de pular turno
        for (i = 0; i < 6; i++)
        {
            if (attackID[i] != 0 && carga[i] > currentCharge)
            {
                Debug.Log("Tem chance de pular por ter ataque que custa mais carga do que tem");

                int tentarPular = UnityEngine.Random.Range(1, 21);
                if (tentarPular <= 8)
                {
                    Debug.Log("Inimigo pulou o proprio turno");
                    textoAtaque.text = "Inimigo pulou o proprio turno";
                    StartCoroutine(control.Turno(true));
                    return;
                }
            }
        }


        //Escolher o ataque e usa-lo
        for (i = 0; i < 6; i++)
        {
            maximo += chance[i];
        }

        if (maximo == 0)
        {
            Debug.Log("Inimigo pulou o proprio turno");
            textoAtaque.text = "Inimigo pulou o proprio turno";
            StartCoroutine(control.Turno(true));
            return;
        }
        else
        {
            ataqueEscolhido = UnityEngine.Random.Range(1, maximo + 1);
            Debug.Log("Numero escolhido: " + ataqueEscolhido);
            for (i = 0; i < 6; i++)
            {
                if (ataqueEscolhido > chance[i])
                {
                    ataqueEscolhido -= chance[i];
                }
                else
                {
                    if (currentCharge <= 2)
                    {
                        int tentarPular = UnityEngine.Random.Range(1, 21);
                        if (tentarPular <= 10 && temAtaqueFraco == false)
                        {
                            Debug.Log("Inimigo pulou o proprio turno");
                            textoAtaque.text = "Inimigo pulou o proprio turno";
                            StartCoroutine(control.Turno(true));
                            return;
                        }
                        else
                        {
                            StartCoroutine(UsarAtaque(i));
                            StartCoroutine(control.Turno(true));
                            return;
                        }
                    }
                    else
                    {
                        StartCoroutine(UsarAtaque(i));
                        StartCoroutine(control.Turno(true));
                        return;
                    }
                }
            }
        }


    }

    public void EfeitoCausado(int i, float attackDamage, int dano)
    {
        for (int us = 1; us < 19; us++)
        {
            efeitosUsados[us] = false;
        }
        if (i == 0) //logo após calcular o dano
        {
            //0. Bloqueio
            if (enemy.efeitosAtivos[1] > 0)
            {
                if (dano > 0)
                {
                    attackDamage = 0;
                    Debug.Log("Ataque bloqueado");
                    enemy.efeitosAtivos[1] -= 1;
                }
            }
        }

        if (i == 1) //No final do turno
        {
            //16. Cacos
            if (efeitosAtivos[16] > 0)
            {
                attackDamage = Mathf.Round(maxHealth * 0.125f);
                CausarDano(attackDamage);
                Debug.Log(attackDamage + " Dano causado pelos cacos");
                efeitosAtivos[16] -= 1;
                textoAtaque.text = "Dano recebido por cacos";
                efeitosUsados[16] = true;

                if (currentHealth <= 0)
                {
                    StartCoroutine(Morto());
                }
            }
        }

        if (i == 2) //No final do turno tbm só que separado pro nutrindo
        {
            //18.Cacos
            if (efeitosAtivos[18] > 0)
            {
                attackDamage = Mathf.Round((maxHealth * 0.125f) * -1);
                CausarDano(attackDamage);
                Debug.Log(attackDamage + "Vida Recuperada pelo nutrindo");
                efeitosAtivos[18] -= 1;
                textoAtaque.text = "Vida Recuperada pelo nutrindo";
                efeitosUsados[18] = true;
                //Arrumar essa bosta
                //healthbar.MudarBarra(currentHealth);
            }
        }

        if (i == 3)
        {
            //entre 2 e 12 (Todos os efeitos que passam no final do turno)
            for (int fo = 2; fo <= 12; fo++)
            {
                if (efeitosAtivos[fo] > 0)
                {
                    efeitosAtivos[fo] -= 1;
                }
            }
        }
    }

    public IEnumerator CorDano(int id, float danoAqui)
    {
        GameObject obj;

        obj = Instantiate(danoTxt, transform.position, Quaternion.identity);
        obj.GetComponent<DanoTxt>().dano = danoAqui;
        obj.transform.SetParent(GameObject.Find("Canvas").transform);

        if (enemy.dano[id] > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (enemy.dano[id] > 0 && efeitosAtivos[1] > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (enemy.dano[id] < 0)
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
        if (efeitosAtivos[1] > 0)
        {
            danoAqui = 0;
            obj.GetComponent<DanoTxt>().dano = danoAqui;
        }
        obj.transform.SetParent(GameObject.Find("Canvas").transform);

        if (dano[id] > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (dano[id] > 0 && efeitosAtivos[1] > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (dano[id] < 0)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }

        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.1f);
    }

    public void Fraquezas(int id)
    {
        //Metal -> Papel
        if (dano[id] > 0 && enemy.materialPlayer == 1 && (material[id] == 4 || (material[id] == 0 && materialInimigo == 4)))
        {
            float dano;

            dano = Mathf.Round((float)phiDamage * 0.5f * (UnityEngine.Random.Range(0.8f, 1.2f)));

            if (dano < 1)
                dano = 1;

            if (enemy.efeitosAtivos[1] > 0)
            {
                dano = 0;
                enemy.efeitosAtivos[1] -= 1;
            }

            Debug.Log("Dano causado pelo efeito: " + dano);

            enemy.CausarDano(dano);
            Debug.Log("Fraqueza Metal -> Papel Ativada");
        }
    }
    
    public void CorDetalhes()
    {
        if (materialInimigo == 1)
        {
            cor.color = new Color32(51, 58, 99, 255);
        }
        else if (materialInimigo == 2)
        {
            cor.color = new Color32(86, 7, 13, 240);
        }else if (materialInimigo == 3)
        {
            cor.color = new Color32(0, 54, 0, 255);
        }else if (materialInimigo == 4)
        {
            cor.color = new Color32(136, 98, 22, 255);
        }else if (materialInimigo == 5)
        {
            cor.color = new Color32(90, 78, 53, 255);
        }
        
    }
}
