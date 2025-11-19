using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AttacksEfeitos : MonoBehaviour
{
    //Chamado de outro objeto
    public Canvas canvas;
    public Controle control;
    public GameObject pas;
    public List<GameObject> pasList = new List<GameObject>();

    public IEnumerator AparecerPassiva(int quem, string nomePas, string desc)
    {
        GameObject obj;
        obj = Instantiate(pas, new Vector3(), quaternion.identity);
        obj.transform.SetParent(canvas.transform);
        obj.transform.SetSiblingIndex(7);
        pasList.Add(obj);

        obj.GetComponent<Passiva>().titulo.text = nomePas;
        obj.GetComponent<Passiva>().desc.text = desc;

        if (quem == 0)
        {
            obj.GetComponent<Passiva>().nomeChar.text = control.player.nickName;
        }
        else if (quem ==1)
        {
            obj.GetComponent<Passiva>().nomeChar.text = control.enemy.nomeinimigo;
        }
        else if (quem == 2)
        {
            string regis = "???";

            switch (control.escolha.regiao)
            {
                case 0:
                    regis = "Costa de vidro";
                    break;
                case 1:
                    regis = "Coração da ilha";
                    break;
                case 2:
                    regis = "Comunidade abandonada";
                    break;
                case 3:
                    regis = "Os arquivos";
                    break;
                case 4:
                    regis = "Floresta composta";
                    break;
            }

            obj.GetComponent<Passiva>().nomeChar.text = regis;
            if(regis.Length > 16)
            {
                obj.GetComponent<Passiva>().nomeChar.fontSize = 0.15f;
            }
            else
            {
                obj.GetComponent<Passiva>().nomeChar.fontSize = 0.22f;
            }
        }
        else
        {
            string weak = "???";

            switch (quem)
            {
                default:
                    break;
                case 3:
                    weak = "Orgânico -> Metal";
                    break;
                case 4:
                    weak = "Metal -> Papel";
                    break;
                case 5:
                    weak = "Vidro -> Plástico";
                    break;
                case 6:
                    weak = "Plástico -> Orgânico";
                    break;
                case 7:
                    weak = "papel -> Vidro";
                    break;
            }

            obj.GetComponent<Passiva>().nomeChar.text = weak;

            if(weak.Length > 16)
            {
                obj.GetComponent<Passiva>().nomeChar.fontSize = 0.15f;
            }
            else
            {
                obj.GetComponent<Passiva>().nomeChar.fontSize = 0.22f;
            }
        }
        

        foreach (GameObject kct in pasList)
        {
            kct.transform.position = new Vector3(0, -0.04f, 0);
            kct.transform.position = kct.transform.position + new Vector3(0, (0.8f * pasList.IndexOf(kct)), 0);
        }

        yield return new WaitForSeconds(3.5f);

        Destroy(pasList[0]);
        pasList.RemoveAt(0);
        
        foreach (GameObject kct in pasList)
        {
            kct.transform.position = new Vector3(0, -0.04f, 0);
            kct.transform.position = kct.transform.position + new Vector3(0, (0.8f * pasList.IndexOf(kct)), 0);
        }
    }
    
    //Especiais:               //Papel:                     //Plastico:                 //Vidro:                        //Metal:                    //Organico
    //1.Bloquear(Added)        //2.Informado(+defDis)       //3.Duradouro(+defFis)      //4.perfurante(+AtqDis)         //5.Afiado(+atqFis)         //6.Adubando(+Conhec)
    //7.Exposto                //8.Desisformado(-AtqDis)    //9.Estagnado(-atqFis)      //10.tenderizado(-defDis)       //11.Derretido(-defFis)     //12.Desperdiçando(-Conhec)
    //13.                      //14.                        //15.                       //16.Cacos(-Vida)               //17.                       //18.nutrindo(+Vida)

    //Função que usa efeitos caso o ataque tenha
    public void AtaquesComEfeitos(bool quem, int o, int quando, Player player, Enemy enemy)
    {
        //'quem' true == player, false == enemy.

        /*
        Novos tempos de efeito
        0 == Ao inicializar qualquer um dos dois 
        1 == Assim que inicia o turno               7 == (Inimigo) Assim que inicia o turno
        2 == Antes do ataque mesmo se errou         8 == (Inimigo) Antes do ataque mesmo se errou 
        3 == Antes do ataque só se acertar          9 == (Inimigo) Antes do ataque só se acertar
        4 == Antes de cada golpe do ataque          10 == (Inimigo) Antes de cada golpe do ataque
        5 == após calcular o dano                   11 == (Inimigo) após calcular o dano
        6 == No final do turno                      12 == (Inimigo) No final do turno

        */
        switch (o)
        {
            //Yoko (Metal/Papel)
            case -15:
                if (quando == 0)
                {
                    Debug.Log("Yoko Passiva Ativada");
                }
                break;
            //Jayden (Orgânico)
            case -14:
                if (quando == 3)
                {
                    if (player.using3R == true && player.dano[player.idAtaqueUsado] == 0)
                    {
                        player.CausarDano(Mathf.Round(player.maxHealth * 0.125f * -1));
                        Debug.Log("Mistura energética ativada");
                        StartCoroutine(AparecerPassiva(0, "Mistura energética", "Curou um pouco de vida com esse ataque"));
                    }
                }
                break;
            //Renan (Metal) //Sobreaquecer
            case -13:
                if (quando == 4)
                {
                    if ((player.using3R == true || player.segundo3R == true) && player.phispe[player.idAtaqueUsado] == true && player.dano[player.idAtaqueUsado] > 0)
                    {
                        player.modPhiDamage += 1;
                        Debug.Log("Sobreaquecer Ativado");
                    }
                }
                if (quando == 3)
                {
                    if (player.using3R == true && player.phispe[player.idAtaqueUsado] == true && player.dano[player.idAtaqueUsado] > 0)
                    {
                        StartCoroutine(AparecerPassiva(0, "Sobreaquecer", "O ataques ficaram ficou mais forte"));
                    }
                }
                break;
            //Kai (Vidro) //Vidro de Cal-Soda
            case -12:
                if (quando == 3)
                {
                    if (player.using3R == true && player.phispe[player.idAtaqueUsado] == false && player.dano[player.idAtaqueUsado] > 0)
                    {
                        enemy.efeitosAtivos[16] += 1;
                        StartCoroutine(AparecerPassiva(0, "Vidro de Cal-Soda", "Ataque causou uma carga da cacos no inimigo"));
                    }
                }
                break;
            //Vlad (Plástico) //Camuflagem de lixo
            case -11:
                if (quando == 2)
                {
                    if (player.using3R && player.dano[player.idAtaqueUsado] == 0 && player.temEfeito[player.idAtaqueUsado] == true && player.efeitosAtivos[1] < 15)
                    {
                        player.efeitosAtivos[1] += 1;
                        StartCoroutine(AparecerPassiva(0, "Camuflagem de Lixo", "Ataque de efeito aumentou seu escudo em +1"));
                    }
                }
                break;
            //Amélia (Papel) //Conhecimento Amplo
            case -10:
                if (quando == 2)
                {
                    if (player.using3R && !player.temEfeito[player.idAtaqueUsado])
                    {
                        player.efeitosAtivos[2] += 3;
                        StartCoroutine(AparecerPassiva(0, "Conhecimento Amplo", "Ganhou defesa a distância por usar um ataque sem efeito"));
                    }
                }
                break;


            //Floresta Orgânica //Nutrientes do chão
            case -5:
                if (quando == 1)
                {
                    if (quem == true && control.turno > 1)
                    {
                        int rand = UnityEngine.Random.Range(1, 21);

                        if (rand > 10 && rand < 16)
                        {
                            player.efeitosAtivos[6] += 1;
                            enemy.efeitosAtivos[6] += 1;
                            StartCoroutine(AparecerPassiva(2, "Nutrientes do chão", "Todos ganharam mais conhecimento nesse turno"));
                        }
                        else if (rand > 15 && rand < 21)
                        {
                            if (player.materialPlayer != 5)
                            {
                                player.efeitosAtivos[12] += 1;

                            }
                            if (enemy.materialInimigo != 5)
                            {
                                enemy.efeitosAtivos[12] += 1;
                            }

                            if (player.materialPlayer != 5 || enemy.materialInimigo != 5)
                            {
                                StartCoroutine(AparecerPassiva(2, "Nutrientes do chão", "Todos, menos orgânicos, ganharam menos conhecimento"));
                            }
                        }
                    }
                }
                break;
            //Os Arquivos //Área de desinformação
            case -4:
                if (quando == 1)
                {
                    if (quem == true)
                    {
                        if ((player.materialPlayer != 1 && !player.emModPapel) || (enemy.materialInimigo != 1 && !enemy.emModPapel)) StartCoroutine(AparecerPassiva(2, "Área de desinformação", "Conhecimento máximo de personagens não Plástico foi diminuído"));


                        //Player
                        if (player.materialPlayer != 1 && !player.emModPapel)
                        {
                            player.ModCharge = -1;
                            player.emModPapel = true;
                            player.controlConheci.SpawnConhecimento(player.maxCharge + player.ModCharge, player.currentCharge);
                        }
                        else if (player.materialPlayer == 1)
                        {
                            player.ModCharge = 0;
                            player.emModPapel = false;
                        }

                        //Inimigo
                        if (enemy.materialInimigo != 1 && !enemy.emModPapel)
                        {
                            enemy.ModCharge = -1;
                            enemy.emModPapel = true;
                        }
                        else if (enemy.materialInimigo == 1)
                        {
                            enemy.ModCharge = 0;
                            enemy.emModPapel = false;
                        }

                    }
                }
                break;
            //Comunidade Abandonada
            case -3:
                if (quem == true)
                {
                    if (quando == 2 && player.materialPlayer != 2)
                    {
                        int random = UnityEngine.Random.Range(1, 21);

                        if(random > 17)
                        {
                            player.errouAtq = true;
                            StartCoroutine(AparecerPassiva(2, "Névoa de Microplástico", "Você errou o ataque através da névoa"));
                        }
                    }
                    else if(quando == 8 && enemy.materialInimigo != 2)
                    {
                        int random = UnityEngine.Random.Range(1, 21);

                        if(random > 17)
                        {
                            enemy.errouAtq = true;
                            StartCoroutine(AparecerPassiva(2, "Névoa de Microplástico", "O inimigo errou o ataque através da névoa"));
                        }
                    }
                }
                break;
            //Coração da Ilha //Calor de derreter
            case -2:
                if (quando == 1)
                {
                    if (quem == true)
                    {
                        if (player.materialPlayer != 4)
                        {
                            player.efeitosAtivos[11] += 1;
                            Debug.Log("Calor de derreter Ativado");
                            StartCoroutine(AparecerPassiva(2, "Calor de derreter", "Sua defesa física diminuiu por não ser metal"));
                        }
                    }
                    else
                    {
                        if (enemy.materialInimigo != 4)
                        {
                            enemy.efeitosAtivos[11] += 1;
                            Debug.Log("Calor de derreter Ativado");
                            StartCoroutine(AparecerPassiva(2, "Calor de derreter", "Defesa física do inimigo diminuiu por não ser metal"));
                        }
                    }
                }
                break;
            //Costa de cacos //Piso afiado
            case -1:
                if (quando == 1)
                {
                    if (quem == true)
                    {
                        int rand = UnityEngine.Random.Range(1, 21);

                        if (rand > 15)
                        {
                            if (player.materialPlayer != 3)
                            {
                                player.efeitosAtivos[16] += 1;
                            }

                            if (enemy.materialInimigo != 3)
                            {
                                enemy.efeitosAtivos[16] += 1;
                            }

                            if (player.materialPlayer != 3 && enemy.materialInimigo != 3)
                            {
                                StartCoroutine(AparecerPassiva(2, "Piso Afiado", "Personagens receberam cacos"));
                            }
                            else if (player.materialPlayer != 3 && enemy.materialInimigo == 3)
                            {
                                StartCoroutine(AparecerPassiva(2, "Piso Afiado", "Você recebeu cacos"));
                            }
                            else if (player.materialPlayer == 3 && enemy.materialInimigo != 3)
                            {
                                StartCoroutine(AparecerPassiva(2, "Piso Afiado", "Inimigo recebeu cacos"));
                            }
                        }
                    }
                }
                break;



            case 3: //Bloquear
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ganhou Escudo";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[1] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[1] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ganhou Escudo";
                    }
                }
                break;
            case 4: //Expor inimigo
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[7] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou exposto";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[7] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[7] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou exposto";
                    }
                }
                break;
            case 5: //Leitura
                if (quando == 11)
                {
                    int rand;

                    if (quem == true)
                    {
                        if (enemy.dano[enemy.idAtaqueUsado] > 0)
                        {
                            rand = UnityEngine.Random.Range(1, 21);
                            if (rand > 15)
                            {
                                player.efeitosAtivos[2] += 2;
                                StartCoroutine(AparecerPassiva(0, "Leitura", "Defesa a distância aumentou após ser atingido"));
                            }
                        }
                    }
                    else
                    {
                        if (player.dano[player.idAtaqueUsado] > 0)
                        {
                            rand = UnityEngine.Random.Range(1, 21);
                            if (rand > 15)
                            {
                                enemy.efeitosAtivos[2] += 2;
                                StartCoroutine(AparecerPassiva(1, "Leitura", "Defesa a distância aumentou após ser atingido"));
                            }
                        }
                    }
                }
                break;
            case 6: //Corte de Papel
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[8] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos ataque a distância";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[8] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[8] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com menos ataque a distância";
                    }
                }
                break;
            case 8: //Capa grossa
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 2;
                        player.efeitosAtivos[2] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ganhou escudo e defesa a distância";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[1] += 1;
                            player.efeitosAtivos[2] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[1] += 2;
                        enemy.efeitosAtivos[2] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ganhou escudo e defesa a distância";
                    }
                }
                break;
            case 9: //Material resistênte
                if (quando == 11)
                {
                    int rand;

                    if (quem == true)
                    {
                        if (enemy.dano[enemy.idAtaqueUsado] > 0)
                        {
                            rand = UnityEngine.Random.Range(1, 21);
                            if (rand > 15)
                            {
                                player.efeitosAtivos[3] += 2;
                                StartCoroutine(AparecerPassiva(0, "Material resistênte", "Defesa física aumentou após ser atingido"));
                            }
                        }
                    }
                    else
                    {
                        if (player.dano[player.idAtaqueUsado] > 0)
                        {
                            rand = UnityEngine.Random.Range(1, 21);
                            if (rand > 15)
                            {
                                enemy.efeitosAtivos[3] += 2;
                                StartCoroutine(AparecerPassiva(1, "Material resistênte", "Defesa física aumentou após ser atingido"));
                            }
                        }
                    }
                }
                break;
            case 10: //Arremesso de material
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[9] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos ataque físico";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[9] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[9] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com menos ataque físico";
                    }
                }
                break;
            case 12: //Barreira de montar
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 2;
                        player.efeitosAtivos[3] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ganhou escudo e defesa física";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[1] += 1;
                            player.efeitosAtivos[3] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[1] += 2;
                        enemy.efeitosAtivos[3] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ganhou escudo e defesa física";
                    }
                }
                break;
            case 13: //Quebrar espelho
                if (quando == 5)
                {
                    int rand;

                    if (quem == true)
                    {
                        if (player.material[player.idAtaqueUsado] == 3 || (player.material[player.idAtaqueUsado] == 0 && player.materialPlayer == 3))
                        {
                            rand = UnityEngine.Random.Range(1, 21);

                            if (rand > 15)
                            {
                                player.efeitosAtivos[4] += 3;
                                StartCoroutine(AparecerPassiva(0, "Quebrar espelho", "Dano a distância aumentou após esse ataque"));
                            }
                        }
                    }
                    else
                    {
                        if (enemy.material[enemy.idAtaqueUsado] == 3 || (enemy.material[enemy.idAtaqueUsado] == 0 && enemy.materialInimigo == 3))
                        {
                            rand = UnityEngine.Random.Range(1, 21);

                            if (rand > 15)
                            {
                                enemy.efeitosAtivos[4] += 3;
                                StartCoroutine(AparecerPassiva(1, "Quebrar espelho", "Dano a distância aumentou após esse ataque"));
                            }
                        }
                    }
                }
                break;
            case 14: //Atirar agulhas
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[10] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com menos defesa a distância";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[10] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[10] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos defesa a distância";
                    }
                }
                break;
            case 16: //Barreira refletora
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 2;
                        player.efeitosAtivos[4] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ganhou escudo e ataque a distância";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[1] += 1;
                            player.efeitosAtivos[4] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[1] += 2;
                        enemy.efeitosAtivos[4] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ganhou escudo e defesa física";
                    }
                }
                break;
            case 17: //Pontas afiadas
                if (quando == 5)
                {
                    int rand;

                    if (quem == true)
                    {
                        if (player.material[player.idAtaqueUsado] == 4 || (player.material[player.idAtaqueUsado] == 0 && player.materialPlayer == 4))
                        {
                            rand = UnityEngine.Random.Range(1, 21);

                            if (rand > 15)
                            {
                                player.efeitosAtivos[5] += 3;
                                StartCoroutine(AparecerPassiva(0, "Pontas afiadas", "Dano físico aumentou após esse ataque"));
                            }
                        }
                    }
                    else
                    {
                        if (enemy.material[enemy.idAtaqueUsado] == 4 || (enemy.material[enemy.idAtaqueUsado] == 0 && enemy.materialInimigo == 4))
                        {
                            rand = UnityEngine.Random.Range(1, 21);

                            if (rand > 15)
                            {
                                enemy.efeitosAtivos[5] += 3;
                                StartCoroutine(AparecerPassiva(1, "Pontas afiadas", "Dano físico aumentou após esse ataque"));
                            }
                        }
                    }
                }
                break;
            case 18: //Lâmina afiada
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[11] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos defesa física";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[11] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[11] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com menos defesa física";
                    }
                }
                break;
            case 20: //Casca de metal
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 2;
                        player.efeitosAtivos[5] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ganhou escudo e ataque físico";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[1] += 1;
                            player.efeitosAtivos[5] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[1] += 2;
                        enemy.efeitosAtivos[5] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ganhou escudo e ataque físico";
                    }
                }
                break;
            case 21: //Absorção
                if (quando == 5)
                {
                    int rand;

                    if (quem == true)
                    {
                        if (player.material[player.idAtaqueUsado] == 5 || (player.material[player.idAtaqueUsado] == 0 && player.materialPlayer == 5))
                        {
                            rand = UnityEngine.Random.Range(1, 21);

                            if (rand > 15)
                            {
                                player.efeitosAtivos[6] += 2;
                                StartCoroutine(AparecerPassiva(0, "Absorção", "Aumentou ganho de conhecimento após esse ataque"));
                            }
                        }
                    }
                    else
                    {
                        if (enemy.material[enemy.idAtaqueUsado] == 5 || (enemy.material[enemy.idAtaqueUsado] == 0 && enemy.materialInimigo == 5))
                        {
                            rand = UnityEngine.Random.Range(1, 21);

                            if (rand > 15)
                            {
                                enemy.efeitosAtivos[6] += 2;
                                StartCoroutine(AparecerPassiva(1, "Absorção", "Aumentou ganho de conhecimento após esse ataque"));
                            }
                        }
                    }
                }
                break;
            case 22: //Golpe de restos
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[12] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos conhecimento";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[12] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[12] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com menos conhecimento";
                    }
                }
                break;
            case 24: //Bloqueio vivo
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 2;
                        player.efeitosAtivos[6] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ganhou escudo e mais conhecimento";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[1] += 1;
                            player.efeitosAtivos[6] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[1] += 2;
                        enemy.efeitosAtivos[6] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ganhou escudo e mais conhecimento";
                    }
                }
                break;
            case 25: //Aumentar Marcha
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[5] += 3;
                        player.efeitosAtivos[11] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Aumentou o dano físico porém diminuiu defesa física";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[5] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[5] += 3;
                        enemy.efeitosAtivos[11] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Aumentou o dano físico porém diminuiu defesa física";
                    }
                }
                break;
            case 26: //Espalhar cacos
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[16] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com cacos";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[16] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[16] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com cacos";
                    }
                }
                break;
            case 27: //Reciclar vida
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[18] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Esta se nutrindo";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[18] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[18] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Esta se nutrindo";
                    }
                }
                break;
            case 28: //Estilhaços
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[16] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com cacos";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[16] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[16] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com cacos";
                    }
                }
                break;
            case 29: //Suco ácido
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[10] += 3;
                        enemy.efeitosAtivos[11] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos defesa física e a distância";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[10] += 1;
                            enemy.efeitosAtivos[11] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[10] += 3;
                        player.efeitosAtivos[11] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com menos defesa física e a distância";
                    }
                }
                break;
            case 31: //Desinformação
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[8] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos ataque a distância";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[8] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[8] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com menos ataque a distância";
                    }
                }
                break;
            case 32: //Estagnado
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[9] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos ataque físico";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[9] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[9] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com menos ataque físico";
                    }
                }
                break;
            case 33: //Tenderizar
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[10] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos defesa a distância";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[10] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[10] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com menos defesa a distância";
                    }
                }
                break;
            case 34: //Derreter
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[11] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos defesa física";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[11] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[11] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com menos defesa física";
                    }
                }
                break;
            case 35: //Desperdício
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[12] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos conhecimento";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[12] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[12] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com menos conhecimento";
                    }
                }
                break;
            case 36: //Arremesso de garrafa
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[16] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com cacos";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[16] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[16] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com cacos";
                    }
                }
                break;
            case 37: //Martelo de brinquedo
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[7] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou exposto";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[7] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[7] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou exposto";
                    }
                }
                break;
            case 38: //Tiro de canudo
                if (quando == 5)
                {
                    if (quem == true)
                    {
                        if (enemy.efeitosAtivos[1] > 0)
                        {
                            enemy.efeitosAtivos[1] -= 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque removeu mais escudos bloqueios";
                        }

                        if (player.rAgora == true)
                        {
                            if (enemy.efeitosAtivos[1] > 0)
                            {
                                enemy.efeitosAtivos[1] -= 1;
                            }
                        }
                    }
                    else
                    {
                        if (player.efeitosAtivos[1] > 0)
                        {
                            player.efeitosAtivos[1] -= 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque removeu 2 bloqueios";
                        }
                    }
                }
                break;
            case 39: //Aprendendo
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[7] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou exposto";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[7] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[7] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou exposto";
                    }
                }
                break;
            case 41: //Barreira perfeita
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 4;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ganhou escudo";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[1] += 2;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[1] += 4;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ganhou escudo";
                    }
                }
                break;
            case 42: //Troca de postura
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        if (player.materialPlayer == 1)
                        {
                            control.escreverEfeito = true;
                            control.efeitoAtq = player.nickName + " trocou de material para Metal";
                        }
                        else if (player.materialPlayer == 4)
                        {
                            control.escreverEfeito = true;
                            control.efeitoAtq = player.nickName + " trocou de material para Papel";
                        }
                    }
                    else
                    {
                        if (enemy.materialInimigo == 1)
                        {
                            control.escreverEfeito = true;
                            control.efeitoAtq = enemy.nomeinimigo + " trocou de material para Metal";
                        }
                        else if (player.materialPlayer == 4)
                        {
                            control.escreverEfeito = true;
                            control.efeitoAtq = enemy.nomeinimigo + " trocou de material para Papel";
                        }
                    }
                }

                if (quando == 6)
                {
                    if (quem == true)
                    {
                        if (player.materialPlayer == 1)
                        {
                            player.materialPlayer = 4;
                            player.efeitosAtivos[5] += 3;
                            player.CorDetalhes();

                        }
                        else if (player.materialPlayer == 4)
                        {
                            player.materialPlayer = 1;
                            player.efeitosAtivos[2] += 3;
                            player.CorDetalhes();
                        }

                        for (int i = 0; i < 6; i++)
                        {
                            control.butao[i].MudarCor(control.player.material[i]);

                        }
                    }
                    else
                    {
                        if (enemy.materialInimigo == 1)
                        {
                            enemy.materialInimigo = 4;
                            enemy.efeitosAtivos[5] += 3;
                            enemy.CorDetalhes();
                        }
                        else if (player.materialPlayer == 4)
                        {
                            enemy.materialInimigo = 1;
                            enemy.efeitosAtivos[2] += 3;
                            enemy.CorDetalhes();
                        }
                    }
                }
                break;
            case 43: //Katana de alma
                if (quando == 4)
                {
                    if (quem == true)
                    {
                        player.modPhiDamage += (enemy.phiDefense + enemy.modPhiDefense);
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " ignorou a defesa de " + enemy.nomeinimigo;
                    }
                    else
                    {
                        enemy.modPhiDamage += (enemy.phiDefense + enemy.modPhiDefense);
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " ignorou a defesa de " + player.nickName;
                    }
                }
                break;
            case 46: //Roubar nutriente
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[18] += 2;
                        enemy.efeitosAtivos[16] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " recebeu Nutrindo e " + enemy.nomeinimigo + " recebeu Cacos";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[18] += 1;
                            enemy.efeitosAtivos[16] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[18] += 2;
                        player.efeitosAtivos[16] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " recebeu Nutrindo e " + player.nickName + " recebeu Cacos";
                    }
                }
                break;
            case 47: //Atacar ponto fraco
                if (quando == 4)
                {
                    if (quem == true)
                    {
                        if (enemy.efeitosAtivos[7] > 0)
                        {
                            player.modPhiDamage += 2;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque causou mais dano por estar exposto";
                        }
                    }
                    else
                    {
                        if (player.efeitosAtivos[7] > 0)
                        {
                            enemy.modPhiDamage += 2;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque causou mais dano por estar exposto";
                        }
                    }
                }
                break;
            case 48: //Armadura de Espinhos
                if (quando == 11)
                {
                    if (quem == true)
                    {
                        if (enemy.danoPublic == 0 && enemy.dano[enemy.idAtaqueUsado] > 0 && enemy.alvo[enemy.idAtaqueUsado] == true)
                        {
                            enemy.CausarDano(Mathf.Round(enemy.maxHealth / 10));
                            if (player.efeitosAtivos[1] >= 1)
                            {
                                player.efeitosAtivos[1] -= 1;
                            }

                            StartCoroutine(AparecerPassiva(0, "Armadura de espinhos", "Inimigo tomou dano dos espinhos"));
                        }
                    }
                    else
                    {
                        if (player.danoPublic == 0 && player.dano[player.idAtaqueUsado] > 0 && player.alvo[player.idAtaqueUsado] == true)
                        {
                            player.CausarDano(Mathf.Round(player.maxHealth / 10));
                            if (enemy.efeitosAtivos[1] >= 1)
                            {
                                enemy.efeitosAtivos[1] -= 1;
                            }

                            StartCoroutine(AparecerPassiva(1, "Armadura de espinhos", "Você tomou dano dos espinhos"));
                        }
                    }
                }
                break;
            case 50: //Batida energizada
                if (quando == 4)
                {
                    if (quem == true)
                    {
                        if (enemy.materialInimigo == 4)
                        {
                            player.modPhiDamage += 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                    }
                    else
                    {
                        if (player.materialPlayer == 4)
                        {
                            enemy.modPhiDamage += 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                    }
                }
                break;
            case 53: //Passar óleo
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[5] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = "Dano físico aumentado";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[5] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[5] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = "Dano físico aumentado";
                    }
                }
                break;
            case 54: //Campo magnético
                if (quando == 1)
                {
                    if (quem == true)
                    {
                        if (enemy.materialInimigo == 4)
                        {
                            player.efeitosAtivos[2] += 1;
                            player.efeitosAtivos[3] += 1;
                            StartCoroutine(AparecerPassiva(0, "Campo magnético", "O inimigo de metal aumentou suas defesas"));
                        }
                    }
                    else
                    {
                        if (player.materialPlayer == 4)
                        {
                            enemy.efeitosAtivos[2] += 1;
                            enemy.efeitosAtivos[3] += 1;
                            StartCoroutine(AparecerPassiva(1, "Campo magnético", "Você ser de metal aumentou as defesas do inimigo"));
                        }
                    }
                }
                break;
            case 55: //Entortar
                if (quando == 5)
                {
                    if (quem == true)
                    {
                        if (player.phispe[player.idAtaqueUsado] == true && player.dano[player.idAtaqueUsado] > 0 && enemy.materialInimigo == 4)
                        {
                            enemy.efeitosAtivos[11] += 2;
                            StartCoroutine(AparecerPassiva(0, "Entortar", "Seu ataque diminuiu a defesa do inimigo de metal"));
                        }
                    }
                    else
                    {
                        if (enemy.phispe[enemy.idAtaqueUsado] == true && enemy.dano[enemy.idAtaqueUsado] > 0 && player.materialPlayer == 4)
                        {
                            player.efeitosAtivos[11] += 2;
                            StartCoroutine(AparecerPassiva(1, "Entortar", "O ataque diminuiu sua defesa por você ser de metal"));
                        }
                    }
                }
                break;
            case 57: //Criar fungos
                if (quando == 4)
                {
                    if (quem == true)
                    {
                        if (enemy.materialInimigo == 5)
                        {
                            player.modSpeDamage += 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                    }
                    else
                    {
                        if (player.materialPlayer == 5)
                        {
                            enemy.modSpeDamage += 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                    }
                }
                break;
            case 58: //Ataque de chorume
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[7] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " ficou com exposto";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[7] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[7] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + "Alvo ficou com exposto";
                    }
                }
                break;
            case 59: //Solo ruim
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        if (enemy.efeitosAtivos[18] > 0)
                        {
                            enemy.efeitosAtivos[18] = 0;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Nutrindo de " + enemy.nomeinimigo + " anulado";
                        }
                    }
                    else
                    {
                        if (player.efeitosAtivos[18] > 0)
                        {
                            player.efeitosAtivos[18] = 0;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Nutrindo do " + player.nickName + " anulado";
                        }
                    }
                }
                break;
            case 60: //Enxame de pragas
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[16] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " ficou com cacos";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[16] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[16] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " ficou com cacos";
                    }
                }
                break;
            case 61: //Limpar terreno
                if (quando == 3)
                {
                    for (int i = 0; i < 19; i++)
                    {
                        player.efeitosAtivos[i] = 0;
                        enemy.efeitosAtivos[i] = 0;
                        control.escreverEfeito = true;
                        control.efeitoAtq = "Terreno foi resetado dos dois lados";
                    }
                }
                break;
            case 62: //Corpo quente
                if (quando == 11)
                {
                    if (quem == true)
                    {
                        if (enemy.phispe[enemy.idAtaqueUsado] == true && enemy.dano[enemy.idAtaqueUsado] > 0)
                        {
                            int rand = UnityEngine.Random.Range(1, 21);

                            if (rand >= 15)
                            {
                                enemy.efeitosAtivos[10] += 2;
                                enemy.efeitosAtivos[11] += 2;
                                StartCoroutine(AparecerPassiva(0, "Corpo Quente", "Defesas do inimigo diminuiram após fazer contato com você"));
                            }
                        }
                    }
                    else
                    {
                        if (player.phispe[player.idAtaqueUsado] == true && player.dano[player.idAtaqueUsado] > 0)
                        {
                            int rand = UnityEngine.Random.Range(1, 21);

                            if (rand >= 15)
                            {
                                player.efeitosAtivos[10] += 2;
                                player.efeitosAtivos[11] += 2;
                                StartCoroutine(AparecerPassiva(1, "Corpo Quente", "Suas defesas diminuiram após fazer contato com o inimigo"));
                            }
                        }
                    }
                }
                break;
            case 63: //Estômago forte
                if (quando == 5)
                {
                    if (quem == true)
                    {
                        if (player.dano[player.idAtaqueUsado] > 0 && player.phispe[player.idAtaqueUsado] == true && enemy.materialInimigo == 5)
                        {
                            float dano = Mathf.Floor(player.dano[player.idAtaqueUsado] / 4 * -1);

                            if (dano >= 0)
                                dano = -1;

                            Debug.Log("Dano que seria curado: " + dano);
                            player.CausarDano(dano);
                            StartCoroutine(AparecerPassiva(0, "Estômago forte", "Consumiu parte do inimigo curando uma parcela de vida"));
                        }
                    }
                    else
                    {
                        if (enemy.dano[enemy.idAtaqueUsado] > 0 && enemy.phispe[enemy.idAtaqueUsado] == true && player.materialPlayer == 5)
                        {
                            float dano = Mathf.Floor(enemy.dano[enemy.idAtaqueUsado] / 4 * -1);

                            if (dano >= 0)
                                dano = -1;

                            Debug.Log("Dano que seria curado: " + dano);
                            enemy.CausarDano(dano);
                            StartCoroutine(AparecerPassiva(1, "Estômago forte", "Consumiu parte do jogador curando uma parcela de vida"));
                        }
                    }
                }
                break;
            case 64: //Guia
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        if (player.dano[player.idAtaqueUsado] > 0 && player.alvo[player.idAtaqueUsado] == true)
                        {
                            StartCoroutine(AparecerPassiva(0, "Guia", "Ajudantes de " + player.nickName + " atacaram o inimigo"));
                        }
                    }
                    else
                    {
                        if (enemy.dano[enemy.idAtaqueUsado] > 0 && enemy.alvo[enemy.idAtaqueUsado] == true)
                        {
                            StartCoroutine(AparecerPassiva(1, "Guia", "Ajudantes de " + enemy.nomeinimigo + " atacaram o jogador"));
                        }
                    }
                }
                if (quando == 5)
                {
                    if (quem == true)
                    {
                        if (player.dano[player.idAtaqueUsado] > 0 && player.alvo[player.idAtaqueUsado] == true)
                        {
                            float dano = Mathf.Ceil(((player.speDamage / 2 * player.dano[player.idAtaqueUsado]) + player.modSpeDamage) / 2);
                            if (dano <= 0)
                                dano = 1;

                            enemy.CausarDano(dano);
                            StartCoroutine(enemy.CorDano(player.idAtaqueUsado, dano));
                        }
                    }
                    else
                    {

                        if (enemy.dano[enemy.idAtaqueUsado] > 0 && enemy.alvo[enemy.idAtaqueUsado] == true)
                        {
                            float dano = Mathf.Ceil(((enemy.speDamage / 2 * enemy.dano[enemy.idAtaqueUsado]) + enemy.modSpeDamage) / 2);
                            if (dano <= 0)
                                dano = 1;

                            player.CausarDano(dano);
                            StartCoroutine(player.CorDano(enemy.idAtaqueUsado, dano));
                        }
                    }
                }
                break;
            case 66: //Superfície com tensão
                if (quando == 4)
                {
                    if (quem == true)
                    {
                        if (enemy.materialInimigo == 3)
                        {
                            player.modSpeDamage += 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                    }
                    else
                    {
                        if (player.materialPlayer == 3)
                        {
                            enemy.modSpeDamage += 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                    }
                }
                break;
            case 67: //Tiro fragmentado
                if (quando == 4)
                {
                    if (quem == true)
                    {
                        int rand = UnityEngine.Random.Range(0, 5);
                        control.escreverEfeito = true;
                        control.efeitoAtq = "Dano escolhido para o ataque foi: " + (rand + 1);
                        player.modSpeDamage += rand;
                    }
                    else
                    {
                        int rand = UnityEngine.Random.Range(0, 5);
                        control.escreverEfeito = true;
                        control.efeitoAtq = "Dano escolhido para o ataque foi: " + (rand + 1);
                        enemy.modSpeDamage += rand;
                    }
                }
                break;
            case 68: //molotov
                if (quando == 2)
                {
                    if (quem == true)
                    {
                        control.escreverEfeito = true;
                        control.efeitoAtq = "Fogo será espalhado no final do turno do inimigo";
                    }
                    else
                    {
                        control.escreverEfeito = true;
                        control.efeitoAtq = "Fogo será espalhado no final do turno do seu turno";
                    }
                }
                if (quando == 12)
                {
                    if (quem == true)
                    {
                        float dano;

                        dano = Mathf.Round((2 + player.speDamage + player.modSpeDamage) * UnityEngine.Random.Range(0.8f, 1.2f) - (enemy.speDefense + enemy.modSpeDefense));
                        if (dano <= 0)
                            dano = 1;
                        enemy.CausarDano(dano);
                        StartCoroutine(enemy.CorDano(player.idAtaqueUsado, dano));
                    }
                    else
                    {
                        float dano;

                        dano = Mathf.Round((2 + enemy.speDamage + enemy.modSpeDamage) * UnityEngine.Random.Range(0.8f, 1.2f) - (player.speDefense + player.modSpeDefense));
                        if (dano <= 0)
                            dano = 1;
                        player.CausarDano(dano);
                        StartCoroutine(player.CorDano(enemy.idAtaqueUsado, dano));
                    }
                }
                break;
            case 69: //Refletir
                if (quando == 4)
                {
                    if (quem == true)
                    {
                        if (enemy.dano[enemy.idAtaqueUsado] > 0 && enemy.pulouTurno == false)
                        {
                            player.modSpeDamage += enemy.dano[enemy.idAtaqueUsado] - 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Dano do ataque passou para: " + enemy.dano[enemy.idAtaqueUsado];
                        }
                        else
                        {
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque falhou, dano do ataque alterado para 1";
                        }
                    }
                    else
                    {
                        if (player.dano[player.idAtaqueUsado] > 0 && player.pulouTurno == false)
                        {
                            enemy.modSpeDamage += player.dano[player.idAtaqueUsado] - 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Dano do ataque passou para: " + player.dano[player.idAtaqueUsado];
                        }
                        else
                        {
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque falhou, dano do ataque alterado para 1";
                        }
                    }
                }
                break;
            case 70: //Ataques frágeis
                if (quando == 4)
                {
                    if (quem == true)
                    {
                        if (player.dano[player.idAtaqueUsado] > 1 && player.phispe[player.idAtaqueUsado] == false)
                        {
                            player.modSpeDamage -= 1;
                        }
                    }
                    else
                    {
                        if (enemy.dano[enemy.idAtaqueUsado] > 1 && enemy.phispe[enemy.idAtaqueUsado] == false)
                        {
                            enemy.modSpeDamage -= 1;
                        }
                    }
                }
                if (quando == 3)
                {
                    if (quem == true && player.dano[player.idAtaqueUsado] > 1 && player.phispe[player.idAtaqueUsado] == false)
                    {
                        int rand = UnityEngine.Random.Range(1, 21);
                        Debug.Log("Numero que caiu: " + rand);

                        if (rand > 15)
                        {
                            enemy.efeitosAtivos[16] += 1;
                            StartCoroutine(AparecerPassiva(0, "Ataques frágeis", player.nickName + " Causou cacos no inimigo"));
                        }
                    }
                    else if (quem == false && enemy.dano[enemy.idAtaqueUsado] > 1 && enemy.phispe[enemy.idAtaqueUsado] == false)
                    {
                        int rand = UnityEngine.Random.Range(1, 21);
                        Debug.Log("Numero que caiu: " + rand);

                        if (rand > 15)
                        {
                            player.efeitosAtivos[16] += 1;
                            StartCoroutine(AparecerPassiva(1, "Ataques frágeis", enemy.nomeinimigo + " Causou cacos no personagem"));
                        }
                    }
                }
                break;
            case 71: //Espeto perfurante
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[7] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = "Inimigo ficou exposto";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[7] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[7] += 2;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " ficou exposto";
                    }
                }
                break;
            case 72: //Ponta infectada
                if (quando == 5)
                {
                    if (quem == true)
                    {
                        if (player.phispe[player.idAtaqueUsado] == true && player.dano[player.idAtaqueUsado] > 0)
                        {
                            int rand = UnityEngine.Random.Range(0, 21);
                            int rand2;

                            if (rand > 16)
                            {
                                rand2 = UnityEngine.Random.Range(8, 13);

                                switch (rand2)
                                {
                                    case 8:
                                        enemy.efeitosAtivos[8] += 2;
                                        StartCoroutine(AparecerPassiva(0, "Ponta infectada", enemy.nomeinimigo + " Teve o ataque a distância diminuído."));
                                        break;
                                    case 9:
                                        enemy.efeitosAtivos[9] += 2;
                                        StartCoroutine(AparecerPassiva(0, "Ponta infectada", enemy.nomeinimigo + " Teve o ataque corpo a corpo diminuído."));
                                        break;
                                    case 10:
                                        enemy.efeitosAtivos[10] += 2;
                                        StartCoroutine(AparecerPassiva(0, "Ponta infectada", enemy.nomeinimigo + " Teve a defesa a distância diminuída."));
                                        break;
                                    case 11:
                                        enemy.efeitosAtivos[11] += 2;
                                        StartCoroutine(AparecerPassiva(0, "Ponta infectada", enemy.nomeinimigo + " Teve a defesa corpo a corpo diminuída."));
                                        break;
                                    case 12:
                                        enemy.efeitosAtivos[12] += 2;
                                        StartCoroutine(AparecerPassiva(0, "Ponta infectada", enemy.nomeinimigo + " Teve o ganho de conhecimento diminuído."));
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (enemy.phispe[enemy.idAtaqueUsado] == true && enemy.dano[enemy.idAtaqueUsado] > 0)
                        {
                            int rand = UnityEngine.Random.Range(0, 21);
                            int rand2;

                            if (rand > 16)
                            {
                                rand2 = UnityEngine.Random.Range(8, 13);

                                switch (rand2)
                                {
                                    case 8:
                                        player.efeitosAtivos[8] += 2;
                                        StartCoroutine(AparecerPassiva(1, "Ponta infectada", player.nickName + " Teve o ataque a distância diminuído."));
                                        break;
                                    case 9:
                                        player.efeitosAtivos[9] += 2;
                                        StartCoroutine(AparecerPassiva(1, "Ponta infectada", player.nickName + " Teve o ataque corpo a corpo diminuído."));
                                        break;
                                    case 10:
                                        player.efeitosAtivos[10] += 2;
                                        StartCoroutine(AparecerPassiva(1, "Ponta infectada", player.nickName + " Teve a defesa a distância diminuída."));
                                        break;
                                    case 11:
                                        player.efeitosAtivos[11] += 2;
                                        StartCoroutine(AparecerPassiva(1, "Ponta infectada", player.nickName + " Teve a defesa corpo a corpo diminuída."));
                                        break;
                                    case 12:
                                        player.efeitosAtivos[12] += 2;
                                        StartCoroutine(AparecerPassiva(1, "Ponta infectada", player.nickName + " Teve o ganho de conhecimento diminuído."));
                                        break;
                                }
                            }
                        }
                    }
                }
                break;
            case 74: //Mistura de materiais
                if (quando == 4)
                {
                    if (quem == true)
                    {
                        if (enemy.materialInimigo == 2)
                        {
                            player.modPhiDamage += 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                    }
                    else
                    {
                        if (player.materialPlayer == 2)
                        {
                            enemy.modPhiDamage += 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                    }
                }
                break;
            case 75: //Apagar conteúdo
                if (quando == 4)
                {
                    if (quem == true)
                    {
                        if (enemy.materialInimigo == 1)
                        {
                            player.modSpeDamage += 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                    }
                    else
                    {
                        if (player.materialPlayer == 1)
                        {
                            enemy.modSpeDamage += 1;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                    }
                }
                break;
            case 76: //Gole de conhecimento
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.currentCharge = 0;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Teve o conhecimento absorvido";
                    }
                    else
                    {
                        player.currentCharge = 0;
                        player.controlConheci.SpawnConhecimento(player.maxCharge + player.ModCharge, player.currentCharge);
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Teve o conhecimento absorvido";
                    }
                }
                break;
            case 77: //Avião de papel
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        if (enemy.efeitosAtivos[1] > 0)
                        {
                            control.escreverEfeito = true;
                            control.efeitoAtq = player.nickName + " Ignorou o escudo do alvo";

                            for(int i = 0; i < 6; i++)
                            {
                                if(enemy.attackID[i] == 89)
                                {
                                    enemy.efeitosAtivos[1] -= 1;
                                    StartCoroutine(AparecerPassiva(1, "Torre de Papel", "Avião de papel removeu um escudo"));
                                }
                            }
                        }
                    }
                    else
                    {
                        if (player.efeitosAtivos[1] > 0)
                        {
                            control.escreverEfeito = true;
                            control.efeitoAtq = enemy.nomeinimigo + " Ignorou o seu escudo";

                            for(int i = 0; i < 6; i++)
                            {
                                if(player.attackID[i] == 89)
                                {
                                    player.efeitosAtivos[1] -= 1;
                                    StartCoroutine(AparecerPassiva(0, "Torre de Papel", "Avião de papel removeu um escudo"));
                                }
                            }
                        }
                    }
                }
                break;
            case 78: //Remendar
                if(quando == 3)
                {
                    if(quem == true)
                    {
                        player.efeitosAtivos[2] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Aumentou sua defesa física";
                        if(player.rAgora) player.efeitosAtivos[2] += 1;
                    }
                    else
                    {
                        enemy.efeitosAtivos[2] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Aumentou sua defesa física";
                    }
                }
            break;
            case 79: //Saco Plástico
                if(quando == 3)
                {
                    if(quem == true)
                    {
                        enemy.errouAtq = true;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " perderá o próximo ataque";
                    }
                    else
                    {
                        player.errouAtq = true;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " perderá o próximo ataque";
                    }
                }
                break;
            case 80: //Infectar material
                if(quando == 3)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[9] += 4;
                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com o ataque físico diminuido";

                        if(player.rAgora) enemy.efeitosAtivos[9] += 2;
                    }
                    else
                    {
                        player.efeitosAtivos[9] += 4;
                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Ficou com o ataque físico diminuido";
                    }
                }
                break;
            case 81: //Reutilizar escudo
                if(quando == 3)
                {
                    if(quem == true)
                    {
                        if(enemy.efeitosAtivos[1] > 0)
                        {
                            int tempEscudo;

                            tempEscudo = enemy.efeitosAtivos[1];
                            player.efeitosAtivos[1] += tempEscudo;
                            enemy.efeitosAtivos[1] = 0;

                            control.escreverEfeito = true;
                            control.efeitoAtq = player.nickName + " pegou o escudo de " + enemy.nomeinimigo;
                        }
                        else
                        {
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Não tinha escudo para ser roubado";
                        }
                    }
                    else
                    {
                        if(player.efeitosAtivos[1] > 0)
                        {
                            int tempEscudo;

                            tempEscudo = player.efeitosAtivos[1];
                            enemy.efeitosAtivos[1] += tempEscudo;
                            player.efeitosAtivos[1] = 0;

                            control.escreverEfeito = true;
                            control.efeitoAtq = enemy.nomeinimigo + " pegou o escudo de " + player.nickName;
                        }
                        else
                        {
                            control.escreverEfeito = true;
                            control.efeitoAtq = "Não tinha escudo para ser roubado";
                        }
                    }
                }
                break;
            case 82: //Fusão pet
                if(quando == 3)
                {
                    if(quem == true)
                    {
                        player.efeitosAtivos[3] += 3;
                        player.efeitosAtivos[5] += 3;

                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " Aumentou sua defesa e ataque físico";

                        if(player.rAgora)
                        {
                            player.efeitosAtivos[3] += 1;
                            player.efeitosAtivos[5] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[3] += 3;
                        enemy.efeitosAtivos[5] += 3;

                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " Aumentou sua defesa e ataque físico";
                    }
                }
                break;
            case 84: //Bastão de filme
                if(quando == 3)
                {
                    if(quem == true)
                    {
                        int rand = UnityEngine.Random.Range(1, 21);
                        if(rand > 17)
                        {
                            enemy.errouAtq = true;
                            control.escreverEfeito = true;
                            control.efeitoAtq = "O inimigo perderá o próximo turno";
                        }
                    }
                    else
                    {
                        int rand = UnityEngine.Random.Range(1, 21);
                        if(rand > 17)
                        {
                            player.errouAtq = true;
                        }
                    }
                }
                break;
            case 85: //Projétil de tampa
                if(quando == 3)
                {
                    if(quem == true)
                    {
                        enemy.efeitosAtivos[7] += 2;
                        enemy.efeitosAtivos[10] += 3;

                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " ficou exposto e com menos defesa a distância";

                        if(player.rAgora)
                        {
                            enemy.efeitosAtivos[7] += 1;
                            enemy.efeitosAtivos[10] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[7] += 2;
                        player.efeitosAtivos[10] += 3;

                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " ficou exposto e com menos defesa a distância";
                    }
                }
                break;
            case 86: //Explosão de pressão
                if(quando == 2)
                {
                    if(quem == true)
                    {
                        float dano;

                        dano = Mathf.Round(player.maxHealth / 5);

                        player.CausarDano(dano);
                        StartCoroutine(player.CorDano(player.idAtaqueUsado, dano));
                    }
                    else
                    {
                        float dano;

                        dano = Mathf.Round(enemy.maxHealth / 6);

                        enemy.CausarDano(dano);
                        StartCoroutine(enemy.CorDano(enemy.idAtaqueUsado, dano));
                    }
                }
                break;
            case 87: //Material Reforçado
                if(quando == 1)
                {
                    if(quem)
                    {
                        int rand = UnityEngine.Random.Range(1, 21);
                        
                        player.efeitosAtivos[4] += 1;
                        player.efeitosAtivos[5] += 1;
                        if(rand >= 18) player.errouAtq = true;

                        if(control.turno == 0)
                        {
                            StartCoroutine(AparecerPassiva(0, "Material Reforçado", "Dano físico e a distância aumentado a preço de poder errar"));
                        }
                    }
                    else
                    {
                        int rand = UnityEngine.Random.Range(1, 21);
                        
                        enemy.efeitosAtivos[4] += 1;
                        enemy.efeitosAtivos[5] += 1;
                        if(rand >= 18) enemy.errouAtq = true;
                        
                        if(control.turno == 0)
                        {
                            StartCoroutine(AparecerPassiva(1, "Material Reforçado", "Dano físico e a distância aumentado a preço de poder errar"));
                        }
                    }
                }
                break;
            case 88: //Amassar
                if(quando == 3)
                {
                    if(quem)
                    {
                        if(enemy.efeitosAtivos[1] > 0 && player.dano[player.idAtaqueUsado] > 0 && (enemy.materialInimigo == 1 || enemy.materialInimigo == 4))
                        {
                            enemy.efeitosAtivos[1] -= 1;
                            StartCoroutine(AparecerPassiva(0, "Amassar", "Ataque removeu um escudo a mais que o normal"));
                        }
                    }
                    else
                    {
                        if(player.efeitosAtivos[1] > 0 && enemy.dano[enemy.idAtaqueUsado] > 0 && (player.materialPlayer == 1 || player.materialPlayer == 4))
                        {
                            player.efeitosAtivos[1] -= 1;
                            StartCoroutine(AparecerPassiva(1, "Amassar", "Ataque removeu um escudo a mais que o normal"));
                        }
                    }
                }
                break;
            case 89: //Torre de papel
                if(quando == 3)
                {
                    if(quem)
                    {
                        if(player.tipo1[player.idAtaqueUsado] == Attacks.Tipo.bloqueio || player.tipo2[player.idAtaqueUsado] == Attacks.Tipo.bloqueio)
                        {
                            player.efeitosAtivos[1] += 1;
                            StartCoroutine(AparecerPassiva(0, "Torre de Papel", "Ganhou mais um escudo com esse bloqueio"));
                        }
                    }
                    else
                    {
                        if(enemy.tipo1[enemy.idAtaqueUsado] == Attacks.Tipo.bloqueio || enemy.tipo2[enemy.idAtaqueUsado] == Attacks.Tipo.bloqueio)
                        {
                            enemy.efeitosAtivos[1] += 1;
                            StartCoroutine(AparecerPassiva(1, "Torre de Papel", "Ganhou mais um escudo com esse bloqueio"));
                        }
                    }
                }
                break;
            case 90: //Recolar
                if(quando == 3)
                {
                    if(quem)
                    {
                        float cura = 0;
                        int quantPapel = 0;
                        int quantQuasePapel = 0;

                        for(int i = 0; i < 6; i++)
                        {
                            if(player.material[i] == 1)
                            {
                                cura += Mathf.Round(player.maxHealth / 8);
                                quantPapel++;
                            }else if(player.attackID[i] != 0 && player.material[i] == 0 && player.materialPlayer == 1)
                            {
                                cura += Mathf.Round(player.maxHealth / 10);
                                quantQuasePapel++;
                            }
                        }
                        cura *= -1;

                        player.CausarDano(cura);
                        StartCoroutine(player.CorDano(player.idAtaqueUsado, cura));
                        control.escreverEfeito = true;
                        control.efeitoAtq = "Ataques de papel: " + quantPapel + " .\nAtaques sem material que se tornaram papel: " + quantQuasePapel;
                    }
                    else
                    {
                        float cura = 0;
                        int quantPapel = 0;
                        int quantQuasePapel = 0;

                        for(int i = 0; i < 6; i++)
                        {
                            if(enemy.material[i] == 1)
                            {
                                cura += Mathf.Round(enemy.maxHealth / 8);
                                quantPapel++;
                            }else if(enemy.attackID[i] != 0 && enemy.material[i] == 0 && enemy.materialInimigo == 1)
                            {
                                cura += Mathf.Round(enemy.maxHealth / 10);
                                quantQuasePapel++;
                            }
                        }
                        cura *= -1;

                        enemy.CausarDano(cura);
                        StartCoroutine(enemy.CorDano(enemy.idAtaqueUsado, cura));
                        control.escreverEfeito = true;
                        control.efeitoAtq = "Ataques de papel: " + quantPapel + " .\nAtaques sem material que se tornaram papel: " + quantQuasePapel;
                    }
                }
                break;
            case 91: //Virar a página
                if(quando == 7)
                {
                    if(quem)
                    {
                        for(int i = 8; i < 13; i++)
                        {
                            if(player.efeitosAtivos[i] > 0)
                            {
                                player.efeitosAtivos[i] -= 1;
                            }
                        }

                        player.efeitosAtivos[10] += 1;
                        player.efeitosAtivos[11] += 1;

                        StartCoroutine(AparecerPassiva(0, "Virar a página", "Defesas diminuidas e efeitos extras removidos"));
                    }
                    else
                    {
                        for(int i = 8; i < 13; i++)
                        {
                            if(enemy.efeitosAtivos[i] > 0)
                            {
                                enemy.efeitosAtivos[i] -= 1;
                            }
                        }

                        enemy.efeitosAtivos[10] += 1;
                        enemy.efeitosAtivos[11] += 1;

                        StartCoroutine(AparecerPassiva(1, "Virar a página", "Defesas diminuidas e efeitos extras removidos"));
                    }
                }
                break;
            case 92: //Pintura nova
                if(quando == 3)
                {
                    if(quem)
                    {
                        player.efeitosAtivos[2] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = "Defesa a distância de " + player.nickName + " Aumentada";

                        if(player.rAgora) player.efeitosAtivos[2] += 1;
                    }
                    else
                    {
                        enemy.efeitosAtivos[2] += 3;
                        control.escreverEfeito = true;
                        control.efeitoAtq = "Defesa a distância de " + enemy.nomeinimigo + " Aumentada";
                    }
                }
                break;
            case 93: //Planilha aberta
                if(quando == 3)
                {
                    if(quem)
                    {
                        int rand = UnityEngine.Random.Range(8, 13);
                        string efeito = "nenhum";

                        if(rand == 8) efeito="Ataque a distância";
                        if(rand == 9) efeito="Ataque físico";
                        if(rand == 10) efeito="Defesa a distância";
                        if(rand == 11) efeito="Defesa física";
                        if(rand == 12) efeito="Conhecimento";

                        enemy.efeitosAtivos[rand] += 3;

                        if(player.rAgora) enemy.efeitosAtivos[rand] += 1;

                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " ficou com menos " + efeito + ".";
                    }
                    else
                    {
                        int rand = UnityEngine.Random.Range(8, 13);
                        string efeito = "nenhum";

                        if(rand == 8) efeito="Ataque a distância";
                        if(rand == 9) efeito="Ataque físico";
                        if(rand == 10) efeito="Defesa a distância";
                        if(rand == 11) efeito="Defesa física";
                        if(rand == 12) efeito="Conhecimento";

                        player.efeitosAtivos[rand] += 3;

                        control.escreverEfeito = true;
                        control.efeitoAtq = player.nickName + " ficou com menos " + efeito + ".";
                    }
                }
                break;
            case 94: //Casca com farpas
                if(quando == 3)
                {
                    if(quem)
                    {
                        player.efeitosAtivos[1] += 2;
                        enemy.efeitosAtivos[16] += 2;

                        if(player.rAgora)
                        {
                            player.efeitosAtivos[1] += 1;
                            enemy.efeitosAtivos[16] += 1;
                        }

                        control.escreverEfeito = true;
                        control.efeitoAtq = "Você recebeu escudo e o inimigo recebeu cacos";
                    }
                    else
                    {
                        enemy.efeitosAtivos[1] += 2;
                        player.efeitosAtivos[16] += 2;

                        control.escreverEfeito = true;
                        control.efeitoAtq = enemy.nomeinimigo + " recebeu escudo e você recebeu cacos";
                    }
                }
                break;
        }
    }
}
