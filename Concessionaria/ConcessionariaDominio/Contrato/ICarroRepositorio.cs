using System.Collections.Generic;

namespace Concessionaria.Dominio.Contrato
{
    public interface ICarroRepositorio<Carro> 
    {
        void Salvar(Carro entidade);
        void Excluir(Carro entidade);
        IEnumerable<Carro> ListarTodos();
        IEnumerable<Opcional> ListarOpcionaldoCarro(string id);
        Carro ListarPorId(string id);
        IEnumerable<Carro> ListarVendidos();
        Venda ListarDetalhesVendidos(string placa);
    }
}
