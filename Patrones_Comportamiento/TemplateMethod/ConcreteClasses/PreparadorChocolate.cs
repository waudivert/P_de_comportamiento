using Patrones_Comportamiento.TemplateMethod.AbstractClass;

namespace Patrones_Comportamiento.TemplateMethod.ConcreteClasses
{
    // Subclase concreta: Chocolate Caliente
    public class PreparadorChocolate : PreparadorBebida
    {
        public PreparadorChocolate() : base("Chocolate Suizo Caliente")
        {
        }

        protected override string ElaborarIngrediente()
        {
            return "Disolviendo cacao amargo puro en leche caliente hasta obtener textura cremosa.";
        }

        protected override string AgregarAcompanamiento()
        {
            return "Añadiendo malvaviscos (marshmallows) y virutas de chocolate amargo.";
        }
    }
}

