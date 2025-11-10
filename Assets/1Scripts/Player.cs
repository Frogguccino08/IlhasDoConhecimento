using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string nomePlayer;
    public string nickName;
    public float maxHealth;
    public float currentHealth;
    public int materialPlayer;  //1==Papel, 2==Plastico, 3==Vidro, 4==Metal, 5==Organico
    public int maxCharge = 0;
    public bool emModPapel = false;
    public int ModCharge;
    public int currentCharge;
    public int currentR;
    public int reroll;
    public bool teveReroll;
    public int[] rerolados = new int[3];

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
    public SpriteRenderer cor;

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
    public bool bloqTurno = false;
    public bool pulouTurno = false;

    public bool errouAtq = false;


    public int[] attackID = new int[6];
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
        reroll = 1;

        GetComponent<SpriteRenderer>().sprite = pc.imgCombate;

        if (pc.Cor != null)
        {
            cor.sprite = pc.Cor;
            CorDetalhes();
        }


        phiDamage = pc.pDamage;
        phiDefense = pc.pDefense;
        speDamage = pc.sDamage;
        speDefense = pc.sDefense;

        for (i = 1; i < 19; i++)
        {
            efeitosAtivos[i] = 0;
        }

        currentCharge = 1;
        currentR = 0;
        currentHealth = maxHealth;
        healthbar.MaximoVida(maxHealth);
        text.text = nickName + " " + currentHealth + "/" + maxHealth;
        healthbar.MudarBarra(currentHealth);


        for (i = 0; i < 4; i++)
        {
            attackID[i] = pc.listaAtaquesIniciais[i];
        }

        AtaquesSelecionados();
        controlConheci.SpawnConhecimento(maxCharge + ModCharge, currentCharge);

        if (efeitosAtivos[7] > 0)
        {
            quantBlock = efeitosAtivos[1];
        }

        for (i = 0; i < 6; i++)
        {
            if (isPassive[i] == true)
            {
                list.AtaquesComEfeitos(true, attackID[i], 6, this, enemy);
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
        text.text = nickName + " " + currentHealth + "/" + maxHealth;
    }


    public IEnumerator Morto()
    {
        control.turno = 0;
        control.inimigoTurno.text = "Inimigo: " + control.inimigoAtual + "       Turno: " + control.turno;
        control.DesativarBotao();
        control.texto.text = "Você foi derrotado\nEsperando input para voltar ao menu";
        
        if (perso.modoHistoria == true && control.pontosRodada >= perso.maxHistoria)
        {
            perso.maxHistoria = control.pontosRodada;
            perso.pontos = perso.maxHistoria;
        }
        else if (perso.modoHistoria == false && control.pontosRodada >= perso.maxRush)
        {
            perso.maxRush = control.pontosRodada;
            perso.pontos = perso.maxRush;
        }

        while (!Input.GetKeyUp(KeyCode.Mouse0) && !Input.GetKeyUp(KeyCode.Space))
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.01f);
    }


    public void AtaquesSelecionados()
    {
        for (int i = 0; i < 6; i++)
        {
            Attacks ataque = lista.CriarAtaques(attackID[i], false);

            attackID[i] = ataque.id;
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
        }
    }

    public IEnumerator UsarAtaque(int id)
    {
        pulouTurno = false;

        if (temEfeito[id]) control.escreverEfeito = false;

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

        if (segundo3R == false)
        {
            currentCharge -= carga[id];
            controlConheci.SpawnConhecimento(maxCharge + ModCharge, currentCharge);
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

        if (!errouAtq)
        {
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
                bloqTurno = false;

                //Efeito número 7 e 8 pra inimigo
                list.AtaquesComEfeitos(true, (perso.regiao + 1) * -1, 7, this, enemy);
                list.AtaquesComEfeitos(true, (pc.id + 10) * -1, 7, this, enemy);

                list.AtaquesComEfeitos(true, attackID[id], 7, this, enemy);

                for (i = 0; i < 6; i++)
                {
                    if (isPassive[i] == true)
                    {
                        list.AtaquesComEfeitos(true, attackID[i], 7, this, enemy);
                    }
                }

                for (i = 0; i < 6; i++)
                {
                    if (enemy.isPassive[i] == true)
                    {
                        enemy.list.AtaquesComEfeitos(false, enemy.attackID[i], 8, this, enemy);
                    }
                }

                //Modificadores facilitados
                float danoAtual = 0;
                float defesaAtual = 0;

                if (dano[id] != 0)
                {
                    if (rAgora == true)
                    {
                        modPhiDamage += 1;
                        modSpeDamage += 1;
                    }

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

                    if (material[id] == materialPlayer)
                    {
                        danoAtual += 1;
                    }

                    if (material[id] == enemy.materialInimigo || (material[id] == 0 && materialPlayer == enemy.materialInimigo))
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
                            if (enemy.materialInimigo == 2 && (material[idAtaqueUsado] == 3 || (material[idAtaqueUsado] == 0 && materialPlayer == 3)))
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
                            rAgora = false;

                            if (segundo3R == true)
                            {
                                segundo3R = false;
                                using3R = false;
                                currentR = 0;
                                controlConheci.SpawnRs();
                                textoAtaque.text = nickName + " usou: " + nome[id] + " DUAS VEZES!!!";
                            }
                            else
                            {
                                if (using3R == true)
                                {
                                    currentR = 0;
                                    controlConheci.SpawnRs();
                                }

                                using3R = false;
                                segundo3R = false;
                                textoAtaque.text = nickName + " usou: " + nome[id];
                            }

                            enemy.cor.enabled = false;
                            enemy.GetComponent<SpriteRenderer>().enabled = false;
                            enemy.cor.enabled = false;
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

            Fraquezas(id);
            textoAtaque.text = nickName + " usou: " + nome[id];
        }
        else
        {
            errouAtq = false;
            if (using3R) currentR = 0;
            if (usingR) currentR = -1;
            if (using3R) using3R = false;
            if (usingR) usingR = false;
            if (dano[id] > 0) currentR -= 1;
            controlConheci.SpawnRs();

            textoAtaque.text = nickName + " Errou o Ataque";
            yield return StartCoroutine(control.EsperarTeclaEspaco());
        }

        rAgora = false;

        if (!using3R)
        {
            if (dano[id] == 0)
            {
                yield return StartCoroutine(control.EsperarTeclaEspaco());
            }
            StartCoroutine(control.Turno(false));
        }
        else if (using3R && !errouAtq)
        {
            using3R = false;
            if (dano[id] > 0)
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
        if (segundo3R && !errouAtq)
        {
            textoAtaque.text = nickName + " usou: " + nome[id] + " DUAS VEZES!!!";
        }
        segundo3R = false;
    }

    public void EfeitoCausado(int i, float attackDamage, int dano)
    {
        for (int us = 1; us < 19; us++)
        {
            efeitosUsados[us] = false;
        }

        if (i == 1) //No final do turno
        {
            //16.Cacos
            if (efeitosAtivos[16] > 0)
            {
                attackDamage = Mathf.Round(maxHealth * 0.125f);
                CausarDano(attackDamage);
                Debug.Log(attackDamage + " Dano causado pelos cacos");
                efeitosAtivos[16] -= 1;
                textoAtaque.text = "Dano recebido por cacos";
                efeitosUsados[16] = true;
            }
        }
        if (i == 2) //No final do turno tbm só que separado pro nutrindo
        {
            //18.Nutrindo
            if (efeitosAtivos[18] > 0)
            {
                attackDamage = Mathf.Round((maxHealth * 0.125f) * -1);
                CausarDano(attackDamage);
                Debug.Log(attackDamage + "Vida Recuperada pelo nutrindo");
                efeitosAtivos[18] -= 1;
                textoAtaque.text = "Vida Recuperada pelo nutrindo";
                efeitosUsados[18] = true;
            }
        }

        if (i == 3) //No final do turno de todos
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
        if (efeitosAtivos[1] > 0 && enemy.ataqueUsado != 77)
        {
            danoAqui = 0;
            obj.GetComponent<DanoTxt>().dano = danoAqui;
        }
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
        if (dano[id] > 0 && enemy.materialInimigo == 4 && (material[id] == 5 || (material[id] == 0 && materialPlayer == 5)))
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
        if (dano[id] > 0 && enemy.materialInimigo == 1 && (material[id] == 4 || (material[id] == 0 && materialPlayer == 4)))
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
        if (dano[id] > 0 && enemy.materialInimigo == 2 && (material[id] == 3 || material[id] == 0 && materialPlayer == 3) && bloqTurno == true)
        {
            StartCoroutine(list.AparecerPassiva(5, "Risco de arranhão", "Escudo não bloqueou ataque completamente"));
        }
    }

    public void CorDetalhes()
    {
        if (materialPlayer == 1)
        {
            cor.color = new Color32(51, 58, 99, 255);
        }
        else if (materialPlayer == 2)
        {
            cor.color = new Color32(86, 7, 13, 240);
        }else if (materialPlayer == 3)
        {
            cor.color = new Color32(0, 54, 0, 255);
        }else if (materialPlayer == 4)
        {
            cor.color = new Color32(136, 98, 22, 255);
        }else if (materialPlayer == 5)
        {
            cor.color = new Color32(90, 78, 53, 255);
        }
        
    }
}