
namespace Patrones_Comportamiento.Command.CommandInterface
{
    public interface IComando
    {
        string Descripcion { get; }

        void Ejecutar();
    }
}
