using System;
using System.Collections.Generic;
using cadastro_de_series.Interface;

namespace cadastro_de_series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            listaSeries[id] = objeto;
        }

        public void Exclui(int id)
        {
            // Somente marca o registro como excluído. 
            listaSeries[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSeries.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSeries;
        }

        public List<Serie> lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Serie retornaPorId(int id)
        {
            return listaSeries[id];
        }

        Serie IRepositorio<Serie>.retornaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}