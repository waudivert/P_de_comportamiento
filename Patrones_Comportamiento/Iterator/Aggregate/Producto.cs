namespace Patrones_Comportamiento.Iterator.Aggregate
{
    public class Producto
    {
        public string Codigo { get; }
        public string Nombre { get; }
        public string Categoria { get; }

        public Producto(string codigo, string nombre, string categoria)
        {
            Codigo = codigo;
            Nombre = nombre;
            Categoria = categoria;
        }
        public override string ToString() => $"{Codigo}  |  {Nombre}  |  {Categoria}";
    }
}
