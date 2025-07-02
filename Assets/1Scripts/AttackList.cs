using UnityEngine;

public class AttackList : MonoBehaviour
{
    //Chamado de outro objeto
    public Controle control;

    //Variaveis que um ataque precisa:
    public string nome;
    public string desc;
    public int material; //0 - material do personagem, 1==Papel, 2==Plastico, 3==Vidro, 4==Metal, 5==Organico
    public int dano;
    public bool phispe; // True==fisico, False==especial
    public bool alvo; //True==inimigo, False==O proprio
    public int quantidade;
    public int carga;
    public bool temEfeito;
    public bool isPassiva = false;


    //Função que cria o ataque dentro do inimigo ou aliado
    public void CriarAtaque(int i)
    {
        switch (i)
        {
            default:
                nome = "- -";
                desc = "Esse ataque não existe";
                material = 0;
                dano = 0;
                phispe = true;
                alvo = true;
                quantidade = 1;
                carga = 0;
                temEfeito = false;
                isPassiva = false;
                break;
            case 1:
                nome = "Ataque purificador";
                desc = "Ataque físico comum com o mesmo material de quem o utiliza";
                material = 0;
                dano = 2;
                phispe = true;
                alvo = true;
                quantidade = 1;
                carga = 1;
                temEfeito = false;
                isPassiva = false;
                break;
            case 2:
                nome = "Disparo purificador";
                desc = "Ataque a distância comum com o mesmo material de quem o utiliza";
                material = 0;
                dano = 2;
                phispe = false;
                alvo = true;
                quantidade = 1;
                carga = 1;
                temEfeito = false;
                isPassiva = false;
                break;
            case 3:
                nome = "Bloquear";
                desc = "Recebe 2 bloqueio o ataque é do material de quem utiliza";
                material = 0;
                dano = 0;
                phispe = false;
                alvo = false;
                quantidade = 1;
                carga = 2;
                temEfeito = true;
                isPassiva = false;
                break;
            case 4:
                nome = "Expor inimigo";
                desc = "Faz o inimigo não poder aumentar seu bloqueio por 2 turnos";
                material = 0;
                dano = 0;
                phispe = true;
                alvo = true;
                quantidade = 1;
                carga = 2;
                temEfeito = true;
                isPassiva = false;
                break;
            case 5:
                nome = "Leitura";
                desc = "após ser atacado tem chance de aumentar sua defesa a distância";
                material = 1;
                dano = 0;
                phispe = true;
                alvo = false;
                quantidade = 1;
                carga = 0;
                temEfeito = true;
                isPassiva = true;
                break;
            case 6:
                nome = "Corte de papel";
                desc = "Ataque mais forte de papel que diminue o dano a distancia do inimigo";
                material = 1;
                dano = 2;
                phispe = false;
                alvo = true;
                quantidade = 3;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 7:
                nome = "Tornado de origami";
                desc = "Um ataque poderoso de papel sem efeitos extra";
                material = 1;
                dano = 4;
                phispe = false;
                alvo = true;
                quantidade = 3;
                carga = 4;
                temEfeito = false;
                isPassiva = false;
                break;
            case 8:
                nome = "Capa grossa";
                desc = "Recebe 2 cargas de bloqueio e aumenta sua defesa a distância";
                material = 1;
                dano = 0;
                phispe = false;
                alvo = false;
                quantidade = 0;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 9:
                nome = "Material resistênte";
                desc = "após ser atacado tem chance de aumentar defesa física";
                material = 2;
                dano = 0;
                phispe = false;
                alvo = false;
                quantidade = 0;
                carga = 0;
                temEfeito = true;
                isPassiva = true;
                break;
            case 10:
                nome = "Arremesso de material";
                desc = "Ataque mais forte de plástico que diminue dano físico do alvo";
                material = 2;
                dano = 2;
                phispe = true;
                alvo = true;
                quantidade = 3;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 11:
                nome = "Lançamento de brinquedos";
                desc = "Ataque poderoso de plástico sem efeito extra";
                material = 2;
                dano = 4;
                phispe = true;
                alvo = true;
                quantidade = 3;
                carga = 4;
                temEfeito = false;
                isPassiva = false;
                break;
            case 12:
                nome = "Barreira de montar";
                desc = "Recebe duas cargas de bloqueio e aumenta sua defesa física";
                material = 2;
                dano = 0;
                phispe = true;
                alvo = false;
                quantidade = 0;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 13:
                nome = "Quebrar espelho";
                desc = "Ao fazer um ataque de vidro tem chance de aumentar seu dano a distância";
                material = 3;
                dano = 0;
                phispe = false;
                alvo = false;
                quantidade = 0;
                carga = 0;
                temEfeito = true;
                isPassiva = true;
                break;
            case 14:
                nome = "Atirar agulhas";
                desc = "Ataque mais forte de vidro que diminue a defesa a distância do alvo";
                material = 3;
                dano = 2;
                phispe = false;
                alvo = true;
                quantidade = 3;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 15:
                nome = "Raio refletido";
                desc = "Ataque poderoso de vidro sem efeito extra";
                material = 3;
                dano = 4;
                phispe = false;
                alvo = true;
                quantidade = 3;
                carga = 4;
                temEfeito = false;
                isPassiva = false;
                break;
            case 16:
                nome = "Barreira refletora";
                desc = "Recebe duas cargas de bloqueio e aumenta seu ataque a distância";
                material = 3;
                dano = 0;
                phispe = false;
                alvo = false;
                quantidade = 0;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 17:
                nome = "Pontas afiadas";
                desc = "Ao fazer um ataque de metal tem chance de aumentar seu dano físico";
                material = 4;
                dano = 0;
                phispe = true;
                alvo = false;
                quantidade = 0;
                carga = 0;
                temEfeito = true;
                isPassiva = true;
                break;
            case 18:
                nome = "Lâmina afiada";
                desc = "Ataque mais forte de metal que diminue a defesa física do alvo";
                material = 4;
                dano = 2;
                phispe = true;
                alvo = true;
                quantidade = 3;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 19:
                nome = "batida pesada";
                desc = "Ataque poderoso de metal sem efeito extra";
                material = 4;
                dano = 4;
                phispe = true;
                alvo = true;
                quantidade = 3;
                carga = 4;
                temEfeito = false;
                isPassiva = false;
                break;
            case 20:
                nome = "Casca de metal";
                desc = "Recebe duas cargas de bloqueio e aumenta seu ataque físico";
                material = 4;
                dano = 0;
                phispe = false;
                alvo = false;
                quantidade = 0;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 21:
                nome = "Absorção";
                desc = "Após usar um ataque no inimigo tem uma chance de aumentar seu ganho de conhecimento";
                material = 5;
                dano = 0;
                phispe = false;
                alvo = false;
                quantidade = 0;
                carga = 0;
                temEfeito = true;
                isPassiva = true;
                break;
            case 22:
                nome = "Golpe de restos";
                desc = "Ataque mais forte Orgânico que diminue o ganho de conhecimento do inimigo";
                material = 5;
                dano = 2;
                phispe = true;
                alvo = true;
                quantidade = 3;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 23:
                nome = "Batida de sujeira";
                desc = "Um ataque poderoso Orgânico sem efeito extra";
                material = 5;
                dano = 4;
                phispe = true;
                alvo = true;
                quantidade = 3;
                carga = 4;
                temEfeito = false;
                isPassiva = false;
                break;
            case 24:
                nome = "Bloqueio vivo";
                desc = "Recebe duas cargas de bloqueio e por 2 turnos recupera parte da vida";
                material = 5;
                dano = 0;
                phispe = false;
                alvo = false;
                quantidade = 0;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 25:
                nome = "Aumentar Marcha";
                desc = "Aumenta seu dano físico por 2 turnos mas diminue a defesa física pelo mesmo tempo";
                material = 4;
                dano = 0;
                phispe = false;
                alvo = false;
                quantidade = 0;
                carga = 2;
                temEfeito = true;
                isPassiva = false;
                break;
            case 26:
                nome = "Espalhar cacos";
                desc = "Ataque extremamente fraco de vidro que coloca cacos no inimigo (causa dano no final do turno)";
                material = 3;
                dano = 1;
                phispe = false;
                alvo = true;
                quantidade = 1;
                carga = 2;
                temEfeito = true;
                isPassiva = false;
                break;
            case 27:
                nome = "Reciclar vida";
                desc = "Cura parte da própria vida e continua curando por mais 2 turnos";
                material = 5;
                dano = -3;
                phispe = false;
                alvo = false;
                quantidade = 1;
                carga = 4;
                temEfeito = true;
                isPassiva = false;
                break;
            case 28:
                nome = "Estilhaços";
                desc = "Ataque fraco de metal que causa cacos no inimigo";
                material = 4;
                dano = 1;
                phispe = false;
                alvo = true;
                quantidade = 1;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 29:
                nome = "Suco ácido";
                desc = "diminue a defesa física e a distância do alvo por 3 turnos";
                material = 5;
                dano = 0;
                phispe = false;
                alvo = true;
                quantidade = 1;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 30:
                nome = "Folhas soltas";
                desc = "Ataque extremamente fraco de papel porém que ataca várias vezes";
                material = 1;
                dano = 1;
                phispe = false;
                alvo = true;
                quantidade = 5;
                carga = 3;
                temEfeito = false;
                isPassiva = false;
                break;
            case 31:
                nome = "Desisformação";
                desc = "Diminue o dano a distância do inimigo por 3 turnos";
                material = 1;
                dano = 0;
                phispe = false;
                alvo = true;
                quantidade = 1;
                carga = 2;
                temEfeito = true;
                isPassiva = false;
                break;
            case 32:
                nome = "Estagnado";
                desc = "Diminue o dano físico do inimigo por 3 turnos";
                material = 2;
                dano = 0;
                phispe = false;
                alvo = true;
                quantidade = 1;
                carga = 2;
                temEfeito = true;
                isPassiva = false;
                break;
            case 33:
                nome = "Tenderizar";
                desc = "Diminue a defesa a distância do inimigo por 3 turnos";
                material = 3;
                dano = 0;
                phispe = false;
                alvo = true;
                quantidade = 1;
                carga = 2;
                temEfeito = true;
                isPassiva = false;
                break;
            case 34:
                nome = "Derreter";
                desc = "Diminue a defesa física do inimigo por 3 turnos";
                material = 4;
                dano = 0;
                phispe = false;
                alvo = true;
                quantidade = 1;
                carga = 2;
                temEfeito = true;
                isPassiva = false;
                break;
            case 35:
                nome = "Desperdício";
                desc = "Diminue o ganho de conhecimento do inimigo por 3 turnos";
                material = 5;
                dano = 0;
                phispe = false;
                alvo = true;
                quantidade = 1;
                carga = 2;
                temEfeito = true;
                isPassiva = false;
                break;
            case 36:
                nome = "Arremesso de garrafa";
                desc = "Ataque mediano de Vidro que causa cacos";
                material = 3;
                dano = 3;
                phispe = false;
                alvo = true;
                quantidade = 3;
                carga = 5;
                temEfeito = true;
                isPassiva = false;
                break;
            case 37:
                nome = "Martelo de brinquedo";
                desc = "Ataque com bastante dano que deixa o inimigo com 2 exposto";
                material = 2;
                dano = 5;
                phispe = true;
                alvo = true;
                quantidade = 1;
                carga = 4;
                temEfeito = true;
                isPassiva = false;
                break;
            case 38:
                nome = "Tiro de canudo";
                desc = "Ataque com dano razoável porém que remove 2 bloqueio ao invés de 1 (3 com carga R)";
                material = 2;
                dano = 3;
                phispe = false;
                alvo = true;
                quantidade = 1;
                carga = 4;
                temEfeito = true;
                isPassiva = false;
                break;
            case 39:
                nome = "Aprendendo";
                desc = "Ataque fraco de papel que deixa o inimigo com 2 exposto";
                material = 1;
                dano = 3;
                phispe = false;
                alvo = true;
                quantidade = 1;
                carga = 3;
                temEfeito = true;
                isPassiva = false;
                break;
            case 40:
                nome = "Tapa leve";
                desc = "Ataque muito fraco sem elemento sem custo e sem efeito";
                material = 0;
                dano = 1;
                phispe = true;
                alvo = true;
                quantidade = 1;
                carga = 0;
                temEfeito = false;
                isPassiva = false;
                break;
            case 41:
                nome = "Barreira Perfeita";
                desc = "Uma barreira poderosa, coloca 5 bloqueio em si mesmo";
                material = 0;
                dano = 0;
                phispe = false;
                alvo = false;
                quantidade = 1;
                carga = 5;
                temEfeito = true;
                isPassiva = false;
                break;
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
        //'quando' 0==Antes do ataque, 1==Antes do ataque inimigo, 2==Após calcular o dano, 3==Após calcular o dano inimigo, 4==final do turno, 5==final do turno inimigo, 6==Ao iniciar Qualquer um dos dois.
        // Se temEfeito == true Colocar o que acontece quando usar uma carga de R (if(usingR == true)) aqui no quem == true, e também terminar com o codigo abaixo:
        /*
                    player.currentR -= 1;
                    player.controlConheci.SpawnRs();
                    player.usingR = false;
        */
        switch (o)
        {
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
                        if (player.material[player.idAtaqueUsado] == 3)
                        {
                            rand = UnityEngine.Random.Range(1, 20);

                            if (rand > 15)
                            {
                                player.efeitosAtivos[4] += 2;
                            }
                        }
                    }
                    else
                    {
                        if (enemy.material[enemy.idAtaqueUsado] == 3)
                        {
                            rand = UnityEngine.Random.Range(1, 20);

                            if (rand > 15)
                            {
                                enemy.efeitosAtivos[4] += 2;
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
                        if (player.material[player.idAtaqueUsado] == 4)
                        {
                            rand = UnityEngine.Random.Range(1, 20);

                            if (rand > 15)
                            {
                                player.efeitosAtivos[5] += 2;
                            }
                        }
                    }
                    else
                    {
                        if (enemy.material[enemy.idAtaqueUsado] == 4)
                        {
                            rand = UnityEngine.Random.Range(1, 20);

                            if (rand > 15)
                            {
                                enemy.efeitosAtivos[5] += 2;
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
                        rand = UnityEngine.Random.Range(1, 20);

                        if (rand > 15)
                        {
                            player.efeitosAtivos[6] += 2;

                            if (player.rAgora == true)
                            {
                                player.efeitosAtivos[6] += 1;
                            }
                        }
                    }
                    else
                    {
                        rand = UnityEngine.Random.Range(1, 20);

                        if (rand > 15)
                        {
                            enemy.efeitosAtivos[6] += 2;
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
                        player.efeitosAtivos[18] += 3;
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
                        enemy.efeitosAtivos[18] += 3;
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
        }
    }
}
