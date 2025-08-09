using UnityEngine;

public class AttacksEfeitos : MonoBehaviour
{
    //Chamado de outro objeto
    public Controle control;
    
    //Especiais:               //Papel:                     //Plastico:                 //Vidro:                        //Metal:                    //Organico
    //1.Bloquear(Added)        //2.Informado(+defDis)       //3.Duradouro(+defFis)      //4.perfurante(+AtqDis)         //5.Afiado(+atqFis)         //6.Adubando(+Conhec)
    //7.Exposto                //8.Desisformado(-AtqDis)    //9.Estagnado(-atqFis)      //10.tenderizado(-defDis)       //11.Derretido(-defFis)     //12.Desperdiçando(-Conhec)
    //13.                      //14.                        //15.                       //16.Cacos(-Vida)               //17.                       //18.nutrindo(+Vida)

    //Função que usa efeitos caso o ataque tenha
    public void AtaquesComEfeitos(bool quem, int o, int quando, Player player, Enemy enemy)
    {
        //'quem' true == player, false == enemy.
        //'o' Numero do ataque na função de cima.
        //'quando' 0==Antes do ataque, 1==Antes do ataque inimigo, 2==Após calcular o dano, 3==Após calcular o dano inimigo, 4==final do turno, 5==final do turno inimigo, 6==Ao iniciar Qualquer um dos dois.
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
                if (quando == 4)
                {
                    Debug.Log("Jayden Passiva Ativada");
                }
                break;
            //Renan (Metal) //Sobreaquecer
            case -13:
                if (quando == 0)
                {
                    if ((player.using3R == true || player.segundo3R == true) && player.phispe[player.idAtaqueUsado] == true && player.dano[player.idAtaqueUsado] > 0)
                    {
                        player.modPhiDamage += 1;
                        Debug.Log("Sobreaquecer Ativado");
                    }
                }
                break;
            //Kai (Vidro)
            case -12:
                if (quando == 2)
                {
                    Debug.Log("Kai Passiva Ativada");
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
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        Debug.Log("Floresta composta player");
                    }
                    else
                    {
                        Debug.Log("Floresta composta Inimigo");
                    }
                }
                break;
            //Os Arquivos
            case -4:
                if (quando == 2)
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
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        if (player.materialPlayer != 4)
                        {
                            player.efeitosAtivos[11] += 1;
                            Debug.Log("Calor de derreter Ativado");
                        }
                    }
                    else
                    {
                        if (enemy.materialInimigo != 4)
                        {
                            enemy.efeitosAtivos[11] += 1;
                            Debug.Log("Calor de derreter Ativado");
                        }
                    }
                }
                break;
            //Costa de vidro
            case -1:
                if (quando == 6)
                {
                    if (quem == true)
                    {
                        Debug.Log("Costa de Vidro player");
                    }
                    else
                    {
                        Debug.Log("Costa de Vidro Inimigo");
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
                            rand = UnityEngine.Random.Range(1, 20);
                            if (rand > 15)
                            {
                                player.efeitosAtivos[2] += 2;
                            }
                        }
                    }
                    else
                    {
                        if (player.dano[player.idAtaqueUsado] > 0)
                        {
                            rand = UnityEngine.Random.Range(1, 20);
                            if (rand > 15)
                            {
                                enemy.efeitosAtivos[2] += 2;
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
                            rand = UnityEngine.Random.Range(1, 20);
                            if (rand > 15)
                            {
                                player.efeitosAtivos[3] += 2;
                            }
                        }
                    }
                    else
                    {
                        if (player.dano[player.idAtaqueUsado] > 0)
                        {
                            rand = UnityEngine.Random.Range(1, 20);
                            if (rand > 15)
                            {
                                enemy.efeitosAtivos[3] += 2;
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
                            rand = UnityEngine.Random.Range(1, 20);

                            if (rand > 15)
                            {
                                player.efeitosAtivos[4] += 3;
                            }
                        }
                    }
                    else
                    {
                        if (enemy.material[enemy.idAtaqueUsado] == 3 || (enemy.material[enemy.idAtaqueUsado] == 0 && enemy.materialInimigo == 3))
                        {
                            rand = UnityEngine.Random.Range(1, 20);

                            if (rand > 15)
                            {
                                enemy.efeitosAtivos[4] += 3;
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
                            rand = UnityEngine.Random.Range(1, 20);

                            if (rand > 15)
                            {
                                player.efeitosAtivos[5] += 3;
                            }
                        }
                    }
                    else
                    {
                        if (enemy.material[enemy.idAtaqueUsado] == 4 || (enemy.material[enemy.idAtaqueUsado] == 0 && enemy.materialInimigo == 4))
                        {
                            rand = UnityEngine.Random.Range(1, 20);

                            if (rand > 15)
                            {
                                enemy.efeitosAtivos[5] += 3;
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
                            rand = UnityEngine.Random.Range(1, 20);

                            if (rand > 15)
                            {
                                player.efeitosAtivos[6] += 2;
                            }
                        }
                    }
                    else
                    {
                        if (enemy.material[enemy.idAtaqueUsado] == 5 || (enemy.material[enemy.idAtaqueUsado] == 0 && enemy.materialInimigo == 5))
                        {
                            rand = UnityEngine.Random.Range(1, 20);

                            if (rand > 15)
                            {
                                enemy.efeitosAtivos[6] += 2;
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
                        player.efeitosAtivos[18] += 1;
                        control.efeitoAtq = player.nickName + " Ganhou escudo e mais conhecimento";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[1] += 1;
                            player.efeitosAtivos[18] += 1;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[1] += 2;
                        enemy.efeitosAtivos[18] += 1;
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
                if (quando == 2)
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
                        player.efeitosAtivos[1] += 5;
                        control.efeitoAtq = player.nickName + " Ganhou escudo";

                        if (player.rAgora == true)
                        {
                            player.efeitosAtivos[1] += 2;
                        }
                    }
                    else
                    {
                        enemy.efeitosAtivos[1] += 5;
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
                if (quando == 0)
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
                        player.efeitosAtivos[18] += 3;
                        enemy.efeitosAtivos[16] += 3;
                        control.efeitoAtq = player.nickName + " recebeu Nutrindo e " + enemy.nomeinimigo + " recebeu Cacos";
                    }
                    else
                    {
                        enemy.efeitosAtivos[18] += 3;
                        player.efeitosAtivos[16] += 3;
                        control.efeitoAtq = enemy.nomeinimigo + " recebeu Nutrindo e " + player.nickName + " recebeu Cacos";
                    }
                }
                break;
            case 47: //Atacar ponto fraco
                if (quando == 0)
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
                        if (enemy.danoPublic == 0 && enemy.dano[enemy.idAtaqueUsado] > 0 && enemy.phispe[enemy.idAtaqueUsado] == true && enemy.alvo[enemy.idAtaqueUsado] == true)
                        {
                            enemy.CausarDano(enemy.maxHealth / 10);
                            enemy.efeitosAtivos[1] -= 1;
                        }
                    }
                    else
                    {
                        if (player.danoPublic == 0 && player.dano[player.idAtaqueUsado] > 0 && player.phispe[player.idAtaqueUsado] == true && player.alvo[player.idAtaqueUsado] == true)
                        {
                            player.CausarDano(player.maxHealth / 10);
                            player.efeitosAtivos[1] -= 1;
                        }
                    }
                }
                break;
            case 50: //Batida energizada
                if (quando == 0)
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
                if (quando == 2)
                {
                    if (quem == true)
                    {
                        player.efeitosAtivos[5] += 3;
                        control.efeitoAtq = "Dano físico aumentado";
                    }
                    else
                    {
                        enemy.efeitosAtivos[5] += 3;
                        control.efeitoAtq = "Dano físico aumentado";
                    }
                }
                break;
            case 54: //Campo magnético
                if (quando == 0)
                {
                    if (quem == true)
                    {
                        if (enemy.materialInimigo == 4)
                        {
                            player.efeitosAtivos[2] += 1;
                            player.efeitosAtivos[3] += 1;
                        }
                    }
                    else
                    {
                        if (player.materialPlayer == 4)
                        {
                            enemy.efeitosAtivos[2] += 1;
                            enemy.efeitosAtivos[3] += 1;
                        }
                    }
                }
                break;
            case 55: //Entortar
                if (quando == 4)
                {
                    if (quem == true)
                    {
                        if (player.phispe[player.idAtaqueUsado] == true && player.dano[player.idAtaqueUsado] > 0 && enemy.materialInimigo == 4)
                        {
                            enemy.efeitosAtivos[11] += 2;
                        }
                    }
                    else
                    {
                        if (enemy.phispe[enemy.idAtaqueUsado] == true && enemy.dano[enemy.idAtaqueUsado] > 0 && player.materialPlayer == 4)
                        {
                            player.efeitosAtivos[11] += 2;
                        }
                    }
                }
                break;
        }
    }
}
