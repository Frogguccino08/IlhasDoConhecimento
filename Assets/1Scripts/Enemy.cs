using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string nomeinimigo;

    public float maxHealth;
    public float currentHealth;
    public int maxCharge;
    public int ModCharge;
    public bool emModPapel = false;
    public int currentCharge;


    public int materialInimigo;  //1==Papel, 2==Plastico, 3==Vidro, 4==Metal, 5==Organico

    //Variaveis para recompensa
    public GameObject telaRecompensa;

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
    public bool pulouTurno = true;
    public bool bloqTurno = false;

    int cont;
    public int forcaAtual = 0;
    public bool isBoss = false;
    public EnemiesSO inimigoEscolhido;
    public PersonagemSelecionado escolha;
    public SpriteRenderer cor;

    public int[] attackID = new int[6];
    [HideInInspector]
    int[] chance = new int[7];
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

        pulouTurno = true;
        
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


        if (escolha.modoHistoria == true)
        {
            inimigoEscolhido = escolha.perso.inimigos[control.inimigoAtual - 1];
        }
        else
        {
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
        }
        

        //Funcionalidade para todo o inimigo
        modPhiDamage = 0;
        modPhiDefense = 0;
        modSpeDamage = 0;
        modSpeDefense = 0;

        nomeinimigo = inimigoEscolhido.nome;
        nomeTela.text = nomeinimigo;
        if (nomeinimigo.Length <= 15)
        {
            nomeTela.fontSize = 0.6f;
        }
        else
        {
            nomeTela.fontSize = 0.5f;
        }

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
                if (forcaAtual > 0)
                {
                    maxHealth += inimigoEscolhido.maxHealth * (forcaAtual - 1);
                }
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
        currentCharge = 1 + forcaAtual;
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

        if (inimigoEscolhido.cor != null)
        {
            cor.enabled = true;
            cor.sprite = inimigoEscolhido.cor;
            CorDetalhes();
        }
        else
        {
            cor.enabled = false;
        }

        //Efeitos iniciais número 9
        list.AtaquesComEfeitos(false, (escolha.regiao + 1) * -1, 9, enemy, this);
        list.AtaquesComEfeitos(true, (escolha.regiao + 1) * -1, 9, enemy, this);
        if(escolha.regiao != 3)
        {
            enemy.ModCharge = 0;
            enemy.emModPapel = false;
            ModCharge = 0;
            emModPapel = false;
            enemy.controlConheci.SpawnConhecimento(enemy.maxCharge + enemy.ModCharge, enemy.currentCharge);
        }

        for (i = 0; i < 6; i++)
        {
            if (isPassive[i] == true)
            {
                list.AtaquesComEfeitos(false, attackID[i], 9, enemy, this);
            }
        }
        
        for (i = 0; i < 6; i++)
        {
            if (enemy.isPassive[i] == true)
            {
                list.AtaquesComEfeitos(true, attackID[i], 10, enemy, this);
            }
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

        yield return new WaitForSeconds(0.01f);

        while (!Input.GetKeyUp(KeyCode.Space) && !Input.GetKeyUp(KeyCode.Mouse0))
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.01f);

        //Parte das recompensas
        telaRecompensa.SetActive(true);
        telaRecompensa.GetComponent<Recompensa>().Receba();

        while (!Input.GetKeyUp(KeyCode.Space) && !Input.GetKeyUp(KeyCode.Mouse0))
        {
            yield return null;
        }

        telaRecompensa.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        if (control.inimigoAtual == 21 && escolha.modoHistoria == true)
        {
            control.vitoriaOn = true;
            control.TelaVitoria();

            while (!Input.GetKeyUp(KeyCode.Escape) && !Input.GetKeyUp(KeyCode.KeypadEnter) && control.vitoriaOn != false)
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.02f);

            if (escolha.perso.unlockable != 0 && escolha.unlock[escolha.perso.unlockable] == false)
            {
                control.TelaPersoOn = true;
                control.TelaPerso();

                while (!Input.GetKeyUp(KeyCode.Escape) && !Input.GetKeyUp(KeyCode.KeypadEnter) && control.TelaPersoOn != false)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(0.02f);

                escolha.unlock[escolha.perso.unlockable] = true;
            }

            control.VoltarMenu();

            yield break;
        }

        if (control.inimigoAtual != (forcaAtual * 5) + 1)
        {
            enemy.currentCharge = Mathf.Min(enemy.currentCharge + 2, enemy.maxCharge + enemy.ModCharge);
            enemy.controlConheci.SpawnConhecimento(enemy.maxCharge + enemy.ModCharge, enemy.currentCharge);
        }
        else
        {
            enemy.reroll += 1;
            enemy.currentHealth = enemy.maxHealth;
            enemy.healthbar.MudarBarra(enemy.currentHealth);
            enemy.text.text = enemy.nickName + " " + enemy.currentHealth + "/" + enemy.maxHealth;

            for (i = 1; i <= 18; i++)
            {
                enemy.efeitosAtivos[i] = 0;
            }

            for (i = 1; i <= 18; i++)
            {
                efeitosAtivos[i] = 0;
            }

            control.texto.enabled = true;
            control.texto.text = "Seu personagem descansou recuperando vida mas não Conhecimento. Efeitos também foram zerados";

            while (!Input.GetKeyUp(KeyCode.Space) && !Input.GetKeyUp(KeyCode.Mouse0))
            {
                yield return null;
            }
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

        if (control.inimigoAtual == (forcaAtual * 5) + 1 && forcaAtual > 0 && escolha.modoHistoria == false)
        {
            int pre;
            pre = escolha.regiao;
            escolha.regiao = UnityEngine.Random.Range(0, 5);
            if (pre != escolha.regiao)
            {
                yield return StartCoroutine(control.LigarTela());
            }
        }

        if (control.inimigoAtual == (forcaAtual * 5) + 1 && forcaAtual > 0 && escolha.modoHistoria == true)
        {
            escolha.regiao = escolha.perso.regioes[forcaAtual];
            yield return StartCoroutine(control.LigarTela());
        }


        InicializarInimigo();

        control.AtivarBotao();
        control.texto.enabled = false;
    }

    void AtaquesSelecionados()
    {
        for (i = 0; i < 6; i++)
        {
            Attacks ataque = lista.CriarAtaques(attackID[i], false);
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
        pulouTurno = false;
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
            //Efeito número 7 e 8 do player
            list.AtaquesComEfeitos(false, (escolha.regiao + 1) * -1, 7, enemy, this);
            list.AtaquesComEfeitos(false, attackID[id], 7, enemy, this);

            for (i = 0; i < 6; i++)
            {
                if (isPassive[i] == true)
                {
                    list.AtaquesComEfeitos(false, attackID[i], 7, enemy, this);
                }
            }

            list.AtaquesComEfeitos(true, (escolha.perso.id + 10) * -1, 8, enemy, this);

            for (i = 0; i < 6; i++)
            {
                if (enemy.isPassive[i] == true)
                {
                    list.AtaquesComEfeitos(true, enemy.attackID[i], 8, enemy, this);
                }
            }

            //Modificadores facilitados
            float danoAtual = 0;
            float defesaAtual = 0;

            if (dano[id] != 0)
            {
                if (phispe[id] == true)
                {
                    danoAtual = Mathf.Round(phiDamage * (modPhiDamage + Mathf.Abs(dano[id])));
                    if (alvo[id] == true)
                        defesaAtual = enemy.modPhiDamage + enemy.phiDefense;
                    else
                        defesaAtual = modPhiDamage + phiDefense;
                }
                else
                {
                    danoAtual = Mathf.Round(speDamage * (modSpeDamage + Mathf.Abs(dano[id])));
                    if (alvo[id] == true)
                        defesaAtual = enemy.modSpeDamage + enemy.speDefense;
                    else
                        defesaAtual = modSpeDamage + speDefense;
                }

                if (material[id] == materialInimigo)
                {
                    danoAtual += 1;
                }

                if (material[id] == enemy.materialPlayer || (material[id] == 0 && materialInimigo == enemy.materialPlayer))
                {
                    danoAtual -= 1;
                }

                if (dano[id] < 0)
                {
                    danoAtual *= -1;
                    defesaAtual = 0;
                }
            }

            if (alvo[id] == true)
            {
                bloqTurno = false;
                
                if (dano[id] != 0)
                {
                    attackDamage = Mathf.Round(danoAtual * UnityEngine.Random.Range(0.8f, 1.2f)) - defesaAtual;

                    if (attackDamage <= 0 && dano[id] > 0)
                    {
                        attackDamage = 1;
                    }

                    if (enemy.efeitosAtivos[1] > 0 && ataqueUsado != 77)
                    {
                        bloqTurno = true;
                        EfeitoCausado(0, attackDamage, dano[id]);
                        if (enemy.materialPlayer == 2 && (material[idAtaqueUsado] == 3 || (material[idAtaqueUsado] == 0 && materialInimigo == 3)))
                        {
                            attackDamage = Mathf.Round(attackDamage / 4);
                            enemy.CausarDano(attackDamage);
                            Debug.Log("Ataque não foi bloqueado completamente");
                        }
                        else
                        {
                            attackDamage = 0;
                            Debug.Log("Ataque bloqueado");
                        }
                        enemy.efeitosAtivos[1] -= 1;
                    }
                    else
                    {
                        Debug.Log("Dano causado ou curado: " + attackDamage);
                        enemy.CausarDano(attackDamage);
                    }

                    yield return StartCoroutine(enemy.CorDano(id, attackDamage));

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
                    attackDamage = Mathf.Round(danoAtual * UnityEngine.Random.Range(0.8f, 1.2f)) - defesaAtual;

                    if (attackDamage <= 0 && dano[id] > 0)
                    {
                        attackDamage = 1;
                    }

                    yield return StartCoroutine(CorDanoSelf(id, attackDamage));

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

        bool podeUsar(int i) => attackID[i] != 0 && !isPassive[i] && currentCharge >= carga[i];
        bool tipoAtaque(Attacks.Tipo tipo, int i) => tipo1[i] == tipo || tipo2[i] == tipo;

        chance[6] = 0;
        maximo = 0;

        for (int i = 0; i < 6; i++)
        {
            chance[i] = 0;
            if (!podeUsar(i)) continue;
            chance[i] += 25;

            //Regra 1: Ataques de cura caso abaixo de 25% vida mais chance
            if (!alvo[i] && dano[i] < 0 || tipoAtaque(Attacks.Tipo.cura, i) && currentHealth <= (maxHealth / 4))
            {
                chance[i] += 25;
                Debug.Log(nome[i] + " chance aumentada por ser uma cura abaixo de 25% de vida");
            }

            //Regra 2: ataques com efeito tem mais chance de usar nos primeiros 2 turnos
            if (control.turno < 5 && temEfeito[i])
            {
                chance[i] += 25;
                Debug.Log(nome[i] + " Chance aumentada por ser um dos dois primeiros turnos e ser um ataque de status");
            }

            //Regra 3: Ataques de cura são evitados com bastante vida
            if (!alvo[i] && dano[i] < 0 || tipoAtaque(Attacks.Tipo.cura, i) && currentHealth >= (maxHealth / 4))
            {
                chance[i] -= 25;
                Debug.Log(nome[i] + " Chance diminuida por ser cura com bastante vida");
            }

            //Regra 4: Ataques de cura são evitados após 40 turnos
            if (!alvo[i] && dano[i] < 0 || tipoAtaque(Attacks.Tipo.cura, i) && control.turno >= 40)
            {
                chance[i] -= 25;
                Debug.Log(nome[i] + " chance diminuida por ser uma cura depois de 40 turnos");
            }

            //regra 5: Evitar usar escudo quando já estiver com bastante
            if(efeitosAtivos[1] >= 5 && tipoAtaque(Attacks.Tipo.bloqueio, i))
            {
                chance[i] -= 25;
                Debug.Log(nome[i] + " chance diminuida por ser um escudo já com bastante escudo");
            }

            //Regra Final 1: chance negativa vira zero
            if (chance[i] < 0) chance[i] = 0;

        }

        //regra Principal 1: Ataque com maior dano mais chance
        for (i = 0; i < 6; i++)
        {
            if (podeUsar(i) && alvo[i] == true && dano[i] > 0)
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

        //regra Principal 2: Ataque com maior cura mais chance
        for (i = 0; i < 6; i++)
        {
            int subida = 0;

            if (podeUsar(i) && alvo[i] == false && dano[i] < 0)
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

        //Regra Pular Turno 1: Caso tenha algum ataque com mais carga do que tem atualmente chance de pular turno
        for (i = 0; i < 6; i++)
        {
            if (attackID[i] != 0 && carga[i] > currentCharge && carga[i] <= (maxCharge + ModCharge))
            {
                chance[6] += 50;
                Debug.Log("Tem chance de pular por ter ataque que custa mais carga do que tem");
                break;
            }
        }

        //Debug apenas
        for (i = 0; i < 6; i++)
        {
            Debug.Log("Chance do ataque " + nome[i] + ": " + chance[i]);
        }
        Debug.Log("Chance de pular: " + chance[6]);


        //Escolher o ataque e usa-lo
        for (i = 0; i <= 6; i++)
        {
            maximo += chance[i];
        }

        if (maximo == 0)
        {
            Debug.Log("Inimigo pulou o proprio turno");
            textoAtaque.text = "Inimigo pulou o proprio turno";
            
            list.AtaquesComEfeitos(false, (escolha.regiao + 1) * -1, 0, enemy, this);
                    
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

            StartCoroutine(control.Turno(true));
            pulouTurno = true;
            return;
        }
        else
        {
            ataqueEscolhido = UnityEngine.Random.Range(1, maximo + 1);
            Debug.Log("Numero escolhido: " + ataqueEscolhido);
            for (i = 0; i < 7; i++)
            {
                if (i == 6)
                {
                    Debug.Log("Inimigo pulou o proprio turno");
                    textoAtaque.text = "Inimigo pulou o proprio turno";
                    list.AtaquesComEfeitos(false, (escolha.regiao + 1) * -1, 0, enemy, this);

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

                    StartCoroutine(control.Turno(true));
                    pulouTurno = true;
                    return;
                }else if (ataqueEscolhido > chance[i])
                {
                    ataqueEscolhido -= chance[i];
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

    public void EfeitoCausado(int i, float attackDamage, int dano)
    {
        for (int us = 1; us < 19; us++)
        {
            efeitosUsados[us] = false;
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
                    GetComponent<SpriteRenderer>().enabled = false;
                    cor.enabled = false;
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
            cor.color = Color.red;
        }
        if (enemy.dano[id] > 0 && enemy.bloqTurno == true)
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
            cor.color = Color.grey;
        }
        if (enemy.dano[id] < 0)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            cor.color = Color.green;
        }

        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
        CorDetalhes();
        yield return new WaitForSeconds(0.1f);
    }

    public IEnumerator CorDanoSelf(int id, float danoAqui)
    {
        GameObject obj;

        obj = Instantiate(danoTxt, transform.position, Quaternion.identity);
        obj.GetComponent<DanoTxt>().dano = danoAqui;
        if (efeitosAtivos[1] > 0 && enemy.ataqueUsado != 77)
        {
            danoAqui = 0;
            obj.GetComponent<DanoTxt>().dano = danoAqui;
        }
        obj.transform.SetParent(GameObject.Find("Canvas").transform);

        if (dano[id] > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            cor.color = Color.red;
        }
        if (dano[id] > 0 && efeitosAtivos[1] > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
            cor.color = Color.grey;
        }
        if (dano[id] < 0)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
            cor.color = Color.green;
        }

        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;
        CorDetalhes();
        yield return new WaitForSeconds(0.1f);
    }

    public void Fraquezas(int id)
    {
        //Orgânico -> Metal (3 no efeito)
        if (dano[id] > 0 && enemy.materialPlayer == 4 && (material[id] == 5 || (material[id] == 0 && materialInimigo == 5)))
        {
            int rand = UnityEngine.Random.Range(1, 21);

            enemy.efeitosAtivos[9] += 1;
            if (rand >= 15)
            {
                enemy.efeitosAtivos[12] += 1;
                StartCoroutine(list.AparecerPassiva(3, "Enferrujar", "Ataque físico foi diminuído e ganho de conhecimento abaixou"));
            }
            else
            {
                StartCoroutine(list.AparecerPassiva(3, "Enferrujar", "Ataque físico foi diminuído"));
            }
        }
        //Metal -> Papel (4 no efeito)
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

            StartCoroutine(list.AparecerPassiva(4, "Fácil de cortar", "Um pequeno segundo ataque aconteceu"));
        }
        //Vidro -> Plástico (5 no efeito)
        if (dano[id] > 0 && enemy.materialPlayer == 2 && (material[id] == 3 || material[id] == 0 && materialInimigo == 3) && bloqTurno == true)
        {
            StartCoroutine(list.AparecerPassiva(5, "Risco de arranhão", "Escudo não bloqueou ataque completamente"));
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
