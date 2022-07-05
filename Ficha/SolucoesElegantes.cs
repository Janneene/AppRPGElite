using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolucoesElegantes : MonoBehaviour
{
    public static int switchElegante(string nome)
    {
        int auxValue = 0;
        switch (nome)
        {
            case "Anzy":
                auxValue = 0;
                break;
            case "Cerumano":
                auxValue = 1;
                break;
            case "Cyborgue":
                auxValue = 2;
                break;
            case "Hayken":
                auxValue = 3;
                break;
            case "Leopy":
                auxValue = 4;
                break;
            case "Mayen":
                auxValue = 5;
                break;
            case "Metamorfe":
                auxValue = 6;
                break;
            case "Ravenney":
                auxValue = 7;
                break;
            case "Sereia Espacial":
                auxValue = 8;
                break;
            case "Targen":
                auxValue = 9;
                break;
            case "Yahiel":
                auxValue = 10;
                break;

            case "Masculino":
                auxValue = 0;
                break;
            case "Feminino":
                auxValue = 1;
                break;
            case "Não informado":
                auxValue = 2;
                break;

            case "Arqueologista":
                auxValue = 0;
                break;
            case "Bombardeador":
                auxValue = 1;
                break;
            case "Cientista":
                auxValue = 2;
                break;
            case "Controladores":
                auxValue = 3;
                break;
            case "Cômico":
                auxValue = 4;
                break;
            case "Guerreiro":
                auxValue = 5;
                break;
            case "Lutador":
                auxValue = 6;
                break;
            case "Mágico":
                auxValue = 7;
                break;
            case "Marauder":
                auxValue = 8;
                break;
            case "Médico":
                auxValue = 9;
                break;
            case "Pistoleiro":
                auxValue = 10;
                break;

            default:
                auxValue = 0;
                break;
        }
        return auxValue;
    }
}
