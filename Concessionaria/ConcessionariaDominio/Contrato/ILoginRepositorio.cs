namespace Concessionaria.Dominio.Contrato
{
    public interface ILoginRepositorio : IRepositorio<Login>
    {
        bool AutenticarUsuario(Login login);
    }
}
