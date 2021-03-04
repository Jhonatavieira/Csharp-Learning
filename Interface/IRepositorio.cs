
using System.Collections.Generic;

namespace cadastro_de_series.Interface
{
    public interface IRepositorio<T>
    {
        List<T> lista();
        T retornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();

    }
}