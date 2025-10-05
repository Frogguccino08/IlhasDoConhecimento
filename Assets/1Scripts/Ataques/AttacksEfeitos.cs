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
                    break;
                case 7:
                    break;
            }

            obj.GetComponent<Passiva>().nomeChar.text = weak;
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
        //'o' Numero do ataque na função de cima.
        //'quando' 0==Antes do ataque, 1==Antes do ataque inimigo, 2==Após calcular o dano, 3==Após calcular o dano inimigo, 4==final do turno, 5==final do turno inimigo,
        // 6==Ao inicializar qualquer um dos dois.
        //'quando' 7==Antes de cada golpe do ataque, 8==Antes de cada golpe do ataque inimigo, 9==Assim que inicia o turno, 10==Assim que inicia o turno inimigo
        // Se temEfeito == true Colocar o que acontece quando usar uma carga de R (if(usingR == true)) aqui no quem == true, e também terminar com o codigo abaixo:
        /*
                    player.currentR -= 1;
                    player.controlConheci.SpawnRs();
                    player.usingR = false;
        */
        switch (o)
        {
            //Yoko (Metal/Papel)
            case -15:
                if (quando == 6)
                {
                    Debug.Log("Yoko Passiva Ativada");
                }
                break;
            //Jayden (Orgânico)
            case -14:
                if (quando == 0)
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
                if (quando == 7)
                {
                    if ((player.using3R == true || player.segundo3R == true) && player.phispe[player.idAtaqueUsado] == true && player.dano[player.idAtaqueUsado] > 0)
                    {
                        player.modPhiDamage += 1;
                        Debug.Log("Sobreaquecer Ativado");
                    }
                }
                if (quando == 0)
                {
                    if (player.using3R == true && player.phispe[player.idAtaqueUsado] == true && player.dano[player.idAtaqueUsado] > 0)
                    {
                        StartCoroutine(AparecerPassiva(0, "Sobreaquecer", "O ataques ficaram ficou mais forte"));
                    }
                }
                break;
            //Kai (Vidro)
            case -12:
                if (quando == 0)
                {
                    if (player.using3R == true && player.phispe[player.idAtaqueUsado] == false && player.dano[player.idAtaqueUsado] > 0)
                    {
                        enemy.efeitosAtivos[16] += 1;
                        StartCoroutine(AparecerPassiva(0, "Vidro de Cal-Soda", "Ataque causou uma carga da cacos no inimigo"));
                    }
                }
                break;
            //Vlad (Plástico)
            case -11:
                if (quando == 1)
                {
                    Debug.Log("Vlad Passiva Ativada");
                }
                break;
            //Amélia (Papel)
            case -10:
                if (quando == 0)
                {
                    Debug.Log("Amélia Passiva Ativada");
                }
                break;


            //Floresta Orgânica
            case -5:
                if (quando == 9)
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
            //Os Arquivos
            case -4:
                if (quando == 7)
                {
                    if (quem == true)
                    {
                        Debug.Log("Os arquivos player");
                    }
                    else
                    {
                        Debug.Log("Os arquivos Inimigo");
                    }
                }
                break;
            //Comunidade Abandonada
            case -3:
                if (quando == 4)
                {
                    if (quem == true)
                    {
                        Debug.Log("Comunidade Abandonada player");
                    }
                    else
                    {
                        Debug.Log("Comunidade Abandonada Inimigo");
                    }
                }
                break;
            //Coração da Ilha
            case -2:
                if (quando == 9)
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
            //Costa de cacos
            case -1:
                if (quando == 9)
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
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 2;
                        control.efeitoAtq = player.nickName + " Ganhou Escudo";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[1] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[1] += 2;
                        control.efeitoAtq = enemy.nomeinimigo + " Ganhou Escudo";
                    }
                }
                break;
            case 4: //Expor inimigo
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[7] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou exposto";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[7] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[7] += 3;
                        control.efeitoAtq = player.nickName + " Ficou exposto";
                    }
                }
                break;
            case 5: //Leitura
                if (quando == 3)
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
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[8] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos ataque a distância";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[8] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[8] += 3;
                        control.efeitoAtq = player.nickName + " Ficou com menos ataque a distância";
                    }
                }
                break;
            case 8: //Capa grossa
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 2;
                        player.efeitosAtivos[2] += 3;
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
                        control.efeitoAtq = enemy.nomeinimigo + " Ganhou escudo e defesa a distância";
                    }
                }
                break;
            case 9: //Material resistênte
                if (quando == 3)
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
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[9] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos ataque físico";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[9] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[9] += 3;
                        control.efeitoAtq = player.nickName + " Ficou com menos ataque físico";
                    }
                }
                break;
            case 12: //Barreira de montar
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 2;
                        player.efeitosAtivos[3] += 3;
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
                        control.efeitoAtq = enemy.nomeinimigo + " Ganhou escudo e defesa física";
                    }
                }
                break;
            case 13: //Quebrar espelho
                if (quando == 2)
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
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[10] += 3;
                        control.efeitoAtq = player.nickName + " Ficou com menos defesa a distância";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[10] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[10] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos defesa a distância";
                    }
                }
                break;
            case 16: //Barreira refletora
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 2;
                        player.efeitosAtivos[4] += 3;
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
                        control.efeitoAtq = enemy.nomeinimigo + " Ganhou escudo e defesa física";
                    }
                }
                break;
            case 17: //Pontas afiadas
                if (quando == 2)
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
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[11] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos defesa física";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[11] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[11] += 3;
                        control.efeitoAtq = player.nickName + " Ficou com menos defesa física";
                    }
                }
                break;
            case 20: //Casca de metal
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 2;
                        player.efeitosAtivos[5] += 3;
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
                        control.efeitoAtq = player.nickName + " Ganhou escudo e ataque físico";
                    }
                }
                break;
            case 21: //Absorção
                if (quando == 2)
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
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[12] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos conhecimento";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[12] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[12] += 3;
                        control.efeitoAtq = player.nickName + " Ficou com menos conhecimento";
                    }
                }
                break;
            case 24: //Bloqueio vivo
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 2;
                        player.efeitosAtivos[6] += 2;
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
                        control.efeitoAtq = enemy.nomeinimigo + " Ganhou escudo e mais conhecimento";
                    }
                }
                break;
            case 25: //Aumentar Marcha
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[5] += 3;
                        player.efeitosAtivos[11] += 3;
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
                        control.efeitoAtq = enemy.nomeinimigo + " Aumentou o dano físico porém diminuiu defesa física";
                    }
                }
                break;
            case 26: //Espalhar cacos
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[16] += 2;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com cacos";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[16] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[16] += 2;
                        control.efeitoAtq = player.nickName + " Ficou com cacos";
                    }
                }
                break;
            case 27: //Reciclar vida
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[18] += 2;
                        control.efeitoAtq = player.nickName + " Esta se nutrindo";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[18] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[18] += 2;
                        control.efeitoAtq = enemy.nomeinimigo + " Esta se nutrindo";
                    }
                }
                break;
            case 28: //Estilhaços
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[16] += 2;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com cacos";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[16] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[16] += 2;
                        control.efeitoAtq = player.nickName + " Ficou com cacos";
                    }
                }
                break;
            case 29: //Suco ácido
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[10] += 3;
                        enemy.efeitosAtivos[11] += 3;
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
                        control.efeitoAtq = player.nickName + " Ficou com menos defesa física e a distância";
                    }
                }
                break;
            case 31: //Desinformação
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[8] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos ataque a distância";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[8] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[8] += 3;
                        control.efeitoAtq = player.nickName + " Ficou com menos ataque a distância";
                    }
                }
                break;
            case 32: //Estagnado
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[9] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos ataque físico";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[9] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[9] += 3;
                        control.efeitoAtq = player.nickName + " Ficou com menos ataque físico";
                    }
                }
                break;
            case 33: //Tenderizar
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[10] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos defesa a distância";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[10] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[10] += 3;
                        control.efeitoAtq = player.nickName + " Ficou com menos defesa a distância";
                    }
                }
                break;
            case 34: //Derreter
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[11] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos defesa física";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[11] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[11] += 3;
                        control.efeitoAtq = player.nickName + " Ficou com menos defesa física";
                    }
                }
                break;
            case 35: //Desperdício
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[12] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com menos conhecimento";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[12] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[12] += 3;
                        control.efeitoAtq = player.nickName + " Ficou com menos conhecimento";
                    }
                }
                break;
            case 36: //Arremesso de garrafa
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[16] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou com cacos";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[16] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[16] += 3;
                        control.efeitoAtq = player.nickName + " Ficou com cacos";
                    }
                }
                break;
            case 37: //Martelo de brinquedo
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[7] += 2;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou exposto";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[7] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[7] += 2;
                        control.efeitoAtq = player.nickName + " Ficou exposto";
                    }
                }
                break;
            case 38: //Tiro de canudo
                if (quando == 3)
                {
                    if (quem == true)
                    {
                        if (enemy.efeitosAtivos[1] > 0)
                        {
                            enemy.efeitosAtivos[1] -= 1;
                            control.efeitoAtq = "Ataque removeu 2 bloqueios";
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
                            control.efeitoAtq = "Ataque removeu 2 bloqueios";
                        }
                    }
                }
                break;
            case 39: //Aprendendo
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[7] += 2;
                        control.efeitoAtq = enemy.nomeinimigo + " Ficou exposto";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[7] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[7] += 2;
                        control.efeitoAtq = player.nickName + " Ficou exposto";
                    }
                }
                break;
            case 41: //Barreira perfeita
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[1] += 4;
                        control.efeitoAtq = player.nickName + " Ganhou escudo";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[1] += 2;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[1] += 4;
                        control.efeitoAtq = enemy.nomeinimigo + " Ganhou escudo";
                    }
                }
                break;
            case 42: //Troca de postura
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        if (player.materialPlayer == 1)
                        {
                            control.efeitoAtq = player.nickName + " trocou de material para Metal";
                        }
                        else if (player.materialPlayer == 4)
                        {
                            control.efeitoAtq = player.nickName + " trocou de material para Papel";
                        }
                    }
                    else
                    {
                        if (enemy.materialInimigo == 1)
                        {
                            control.efeitoAtq = enemy.nomeinimigo + " trocou de material para Metal";
                        }
                        else if (player.materialPlayer == 4)
                        {
                            control.efeitoAtq = enemy.nomeinimigo + " trocou de material para Papel";
                        }
                    }
                }

                if (quando == 4)
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
                if (quando == 7)
                {
                    if (quem == true)
                    {
                        player.modPhiDamage += (enemy.phiDefense + enemy.modPhiDefense);
                        control.efeitoAtq = player.nickName + " ignorou a defesa de " + enemy.nomeinimigo;
                    }
                    else
                    {
                        enemy.modPhiDamage += (enemy.phiDefense + enemy.modPhiDefense);
                        control.efeitoAtq = enemy.nomeinimigo + " ignorou a defesa de " + player.nickName;
                    }
                }
                break;
            case 46: //Roubar nutriente
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[18] += 2;
                        enemy.efeitosAtivos[16] += 2;
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
                        control.efeitoAtq = enemy.nomeinimigo + " recebeu Nutrindo e " + player.nickName + " recebeu Cacos";
                    }
                }
                break;
            case 47: //Atacar ponto fraco
                if (quando == 7)
                {
                    if (quem == true)
                    {
                        if (enemy.efeitosAtivos[7] > 0)
                        {
                            player.modPhiDamage += 2;
                            control.efeitoAtq = "Ataque causou mais dano por estar exposto";
                        }
                        else
                        {
                            control.efeitoAtq = "Ataque deu dano normal";
                        }
                    }
                    else
                    {
                        if (player.efeitosAtivos[7] > 0)
                        {
                            enemy.modPhiDamage += 2;
                            control.efeitoAtq = "Ataque causou mais dano por estar exposto";
                        }
                        else
                        {
                            control.efeitoAtq = "Ataque deu dano normal";
                        }
                    }
                }
                break;
            case 48: //Armadura de Espinhos
                if (quando == 3)
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
                if (quando == 7)
                {
                    if (quem == true)
                    {
                        if (enemy.materialInimigo == 4)
                        {
                            player.modPhiDamage += 1;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                        else
                        {
                            control.efeitoAtq = "Ataque teve o dano normal";
                        }
                    }
                    else
                    {
                        if (player.materialPlayer == 4)
                        {
                            enemy.modPhiDamage += 1;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                        else
                        {
                            control.efeitoAtq = "Ataque teve o dano normal";
                        }
                    }
                }
                break;
            case 53: //Passar óleo
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[5] += 3;
                        control.efeitoAtq = "Dano físico aumentado";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[5] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[5] += 3;
                        control.efeitoAtq = "Dano físico aumentado";
                    }
                }
                break;
            case 54: //Campo magnético
                if (quando == 9)
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
                if (quando == 2)
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
                if (quando == 7)
                {
                    if (quem == true)
                    {
                        if (enemy.materialInimigo == 5)
                        {
                            player.modSpeDamage += 1;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                        else
                        {
                            control.efeitoAtq = "Ataque teve o dano normal";
                        }
                    }
                    else
                    {
                        if (player.materialPlayer == 5)
                        {
                            enemy.modSpeDamage += 1;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                        else
                        {
                            control.efeitoAtq = "Ataque teve o dano normal";
                        }
                    }
                }
                break;
            case 58: //Ataque de chorume
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[7] += 2;
                        control.efeitoAtq = enemy.nomeinimigo + " ficou com exposto";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[7] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[7] += 2;
                        control.efeitoAtq = player.nickName + "Alvo ficou com exposto";
                    }
                }
                break;
            case 59: //Solo ruim
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[18] = 0;
                        control.efeitoAtq = "Nutrindo de " + enemy.nomeinimigo + " anulado";
                    }
                    else
                    {
                        player.efeitosAtivos[18] = 0;
                        control.efeitoAtq = "Nutrindo do " + player.nickName + " anulado";
                    }
                }
                break;
            case 60: //Enxame de pragas
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[16] += 2;
                        control.efeitoAtq = enemy.nomeinimigo + " ficou com cacos";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[16] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[16] += 2;
                        control.efeitoAtq = player.nickName + " ficou com cacos";
                    }
                }
                break;
            case 61: //Limpar terreno
                if (quando == 0)
                {
                    for (int i = 0; i < 19; i++)
                    {
                        player.efeitosAtivos[i] = 0;
                        enemy.efeitosAtivos[i] = 0;
                        control.efeitoAtq = "Terreno foi resetado";
                    }
                }
                break;
            case 62: //Corpo quente
                if (quando == 3)
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
                if (quando == 2)
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
                if (quando == 0)
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
                if (quando == 2)
                {
                    if (quem == true)
                    {
                        if (player.dano[player.idAtaqueUsado] > 0 && player.alvo[player.idAtaqueUsado] == true)
                        {
                            float phispe;

                            if (player.phispe[player.idAtaqueUsado] == true)
                            {
                                phispe = player.modPhiDamage;
                            }
                            else
                            {
                                phispe = player.modSpeDamage;
                            }

                            float dano = Mathf.Ceil((player.dano[player.idAtaqueUsado] + phispe) / 4);
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
                            float phispe;

                            if (enemy.phispe[enemy.idAtaqueUsado] == true)
                            {
                                phispe = enemy.modPhiDamage;
                            }
                            else
                            {
                                phispe = enemy.modSpeDamage;
                            }

                            float dano = Mathf.Ceil((enemy.dano[enemy.idAtaqueUsado] + phispe) / 4);
                            if (dano <= 0)
                                dano = 1;

                            player.CausarDano(dano);
                            StartCoroutine(player.CorDano(enemy.idAtaqueUsado, dano));
                        }
                    }
                }
                break;
            case 66: //Superfície com tensão
                if (quando == 7)
                {
                    if (quem == true)
                    {
                        if (enemy.materialInimigo == 3)
                        {
                            player.modSpeDamage += 1;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                        else
                        {
                            control.efeitoAtq = "Ataque teve o dano normal";
                        }
                    }
                    else
                    {
                        if (player.materialPlayer == 3)
                        {
                            enemy.modSpeDamage += 1;
                            control.efeitoAtq = "Ataque teve o dano aumentado";
                        }
                        else
                        {
                            control.efeitoAtq = "Ataque teve o dano normal";
                        }
                    }
                }
                break;
            case 67: //Tiro fragmentado
                if (quando == 7)
                {
                    if (quem == true)
                    {
                        int rand = UnityEngine.Random.Range(0, 5);
                        control.efeitoAtq = "Dano escolhido para o ataque foi: " + (rand + 1);
                        player.modSpeDamage += rand;
                    }
                    else
                    {
                        int rand = UnityEngine.Random.Range(0, 5);
                        control.efeitoAtq = "Dano escolhido para o ataque foi: " + (rand + 1);
                        enemy.modSpeDamage += rand;
                    }
                }
                break;
            case 68: //molotov
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        control.efeitoAtq = "Fogo será espalhado no final do turno do inimigo";
                    }
                    else
                    {
                        control.efeitoAtq = "Fogo será espalhado no final do turno do seu turno";
                    }
                }
                if (quando == 5)
                {
                    if (quem == true)
                    {
                        Debug.Log("Chegou aqui");
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
                if (quando == 7)
                {
                    if (quem == true)
                    {
                        if (enemy.dano[enemy.idAtaqueUsado] > 0 && enemy.pulouTurno == false)
                        {
                            player.modSpeDamage += enemy.dano[enemy.idAtaqueUsado] - 1;
                            control.efeitoAtq = "Dano do ataque passou para: " + enemy.dano[enemy.idAtaqueUsado];
                        }
                        else
                        {
                            control.efeitoAtq = "Ataque falhou, dano do ataque alterado para 1";
                        }
                    }
                    else
                    {
                        if (player.dano[player.idAtaqueUsado] > 0 && player.pulouTurno == false)
                        {
                            enemy.modSpeDamage += player.dano[player.idAtaqueUsado] - 1;
                            control.efeitoAtq = "Dano do ataque passou para: " + player.dano[player.idAtaqueUsado];
                        }
                        else
                        {
                            control.efeitoAtq = "Ataque falhou, dano do ataque alterado para 1";
                        }
                    }
                }
                break;
            case 70: //Ataques frágeis
                if (quando == 7)
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
                if (quando == 0)
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
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        enemy.efeitosAtivos[7] += 2;
                        control.efeitoAtq = "Inimigo ficou exposto";

                        if (player.rAgora == true)
                        {
                            enemy.efeitosAtivos[7] += 1;
                        }
                    }
                    else
                    {
                        player.efeitosAtivos[7] += 2;
                        control.efeitoAtq = player.nickName + " ficou exposto";
                    }
                }
                break;
            case 72: //Ponta infectada
                if (quando == 2)
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
        }
    }
}
