using System;
using System.Collections.Generic;
using System.Text;

namespace Byte_Bank.Sistemas
{
    public class ListaDeObject
    {
        private object[] _itens;
        private int _proximaPosicao;

        public int Tamanho
        {
            get
            {
                return _proximaPosicao;
            }
        }
        public ListaDeObject(int capacidadeInicial = 5)
        {
            _itens = new object[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(object item)
        {
            VerificarCapacidade(_proximaPosicao + 1);

            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        public void AdicionarVarios(params object[] itens)
        {
            foreach (object item in itens)
            {
                Adicionar(item);
            }
        }

        public void Remover(object item)
        {
            int indexItem = -1;

            for (int i = 0; i < _proximaPosicao; i++)
            {
                object itemAtual = _itens[i];

                if (itemAtual.Equals(item))
                {
                    indexItem = i;
                    break;
                }
            }

            for (int i = indexItem; i < _proximaPosicao; i++)
            {
                _itens[i] = _itens[i + 1];
            }

            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            int novoTamanho = _itens.Length * 2;

            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            object[] novoArray = new object[novoTamanho];

            for (int index = 0; index < _itens.Length; index++)
            {
                novoArray[index] = _itens[index];
            }

            _itens = novoArray;
        }

        public object GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public object this[int indice] => GetItemNoIndice(indice);
    }
}
