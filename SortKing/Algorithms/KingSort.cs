using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortKing.Algorithms
{
    public static class KingSort
    {
        public static string[] getSortedList(string[] kings)
        {
            return kings.OrderBy(x => x.Split(" ")[0]).ThenBy(x => ConvertRomanToNumeric(x.Split(" ")[1])).ToArray();
        }

        public static int ConvertRomanToNumeric(string romanNumber)
        {
            int number = 0; //Soma dos valores até o momento.
            int contador = 0; //Utilizado para controlar a posição da string do número romano (parâmetro).
            romanNumber = romanNumber?.ToUpper();
            int numberLength = romanNumber.Length; //Número de caracteres do número romano (parâmetro).

            //Criando lista com todos os algarismos romanos por ordem decrescente de tamanho para facilitar a comparação e conversão para numérico.
            List<AlgarismoRomano> algarismos = new List<AlgarismoRomano>();
            algarismos.Add(new AlgarismoRomano { algarismo = "M", numero = 1000 });
            algarismos.Add(new AlgarismoRomano { algarismo = "CM", numero = 900 });
            algarismos.Add(new AlgarismoRomano { algarismo = "D", numero = 500 });
            algarismos.Add(new AlgarismoRomano { algarismo = "CD", numero = 400 });
            algarismos.Add(new AlgarismoRomano { algarismo = "C", numero = 100 });
            algarismos.Add(new AlgarismoRomano { algarismo = "XC", numero = 90 });
            algarismos.Add(new AlgarismoRomano { algarismo = "L", numero = 50 });
            algarismos.Add(new AlgarismoRomano { algarismo = "XL", numero = 40 });
            algarismos.Add(new AlgarismoRomano { algarismo = "X", numero = 10 });
            algarismos.Add(new AlgarismoRomano { algarismo = "IX", numero = 9 });
            algarismos.Add(new AlgarismoRomano { algarismo = "V", numero = 5 });
            algarismos.Add(new AlgarismoRomano { algarismo = "IV", numero = 4 });
            algarismos.Add(new AlgarismoRomano { algarismo = "I", numero = 1 });

            //Percorre lista de algarismos romanos
            for (int i = 0; i < algarismos.Count; i++)
            {
                var algarismo = algarismos[i].algarismo; //Recupera algarismo da lista para comparar com caracteres do parâmetro.

                //Verifica se o tamanho do algarismo da lista somado à posição do parâmetro não extrapola o número de caracteres do parâmetro 
                //(para não dar erro no Substring no caso da comparação de um algarismo de 2 caracteres com 1 de 1 caracter).
                if (algarismo.Length + contador <= numberLength)
                {
                    //Verifica se há repetição de um mesmo caracter romano. Enquanto houver repetição, ocorre soma.
                    //Verifica se o texto da posição atual do número romano até a posição atual mais o tamanho do algarismo que estou comparando é igual ao algarismo que estou comparando.
                    /* Ex: 
                     * Comparando algarismo X. Parâmetro XV. Contador 0.
                     * XV.Substring(0, 1) -> X
                     * X == X ? true
                     * 
                     * Prox. iteração:
                     * Comparando algarismo X. Parâmetro XV. Contador 1.
                     * XV.Substring(1, 2) -> V
                     * X == V ? false
                     */
                    while (romanNumber.Substring(contador, algarismo.Length) == algarismo)
                    {
                        number += algarismos[i].numero; //Verifica o número correspondente ao algarismo romano.
                        contador += algarismo.Length;   //Atualiza a posição do parâmetro que será comparada na próxima iteração, somando o nº de caracteres do algarismo que acabou de ser comparado.
                        if (contador + algarismo.Length > numberLength) break; //Verifica se o tamanho do algarismo da lista somado à posição do parâmetro não extrapola o número de caracteres do parâmetro. 
                    }
                }                               
            }
            return number;
        }
    }

    internal class AlgarismoRomano
    {
        public string algarismo { get; set; }

        public int numero { get; set; }
    }
        
}
