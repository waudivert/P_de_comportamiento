using Patrones_Comportamiento.TemplateMethod.AbstractClass;

namespace Patrones_Comportamiento.TemplateMethod.ConcreteClasses
{
    // Subclase concreta: Té Verde
    public class TeteraVerde : PreparadorBebida
    {
        public TeteraVerde() : base("Té Verde Japonés")
        {
        }

        protected override string ElaborarIngrediente()
        {
            return "Sumergiendo hojas seleccionadas de té verde en infusión lenta durante 3 minutos.";
        }

        protected override string AgregarAcompanamiento()
        {
            return "Agregando rodajas de limón fresco y unas hojas de menta.";
        }
    }
}

