using System;
using System.Collections.Generic;
using System.Text;

namespace Byte_Bank
{
    public class ListaDeContaCorrente
    {
        private ContaCorrente[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }
        public ListaDeContaCorrente(int capacidadeInicial = 5)
        {
            _itens = new ContaCorrente[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(ContaCorrente item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

            _itens[_proximaPosicao] = item;
            _proximaPosicao++; 
        }

        public void AdicionarVarios(params ContaCorrente[] itens)
        {
            foreach (ContaCorrente conta in itens)
            {
                Adicionar(conta);
            }
        }

        public void Remover(ContaCorrente item)
        {
            int indexItem = -1;

            for(int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente itemAtual = _itens[i];

                if(itemAtual.Equals(item))
                {
                    indexItem = i;
                    break;
                }
            }

            for(int i = indexItem; i < _proximaPosicao; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if(_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;

            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            ContaCorrente[] novoArray = new ContaCorrente[novoTamanho];

            for (int index = 0; index < _itens.Length; index++)
            {
                novoArray[index] = _itens[index];
            }

            _itens = novoArray;
        }

        public ContaCorrente GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public ContaCorrente this[int indice] => GetItemNoIndice(indice);
    }
}
