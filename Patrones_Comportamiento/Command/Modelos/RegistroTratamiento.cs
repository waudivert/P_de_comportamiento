
using System;

namespace Patrones_Comportamiento.Command.Modelos
{
    public class RegistroTratamiento
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Arete { get; set; } = "";

        public string Tratamiento { get; set; } = "";

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
