using Patrones_Comportamiento.TemplateMethod.AbstractClass;

namespace Patrones_Comportamiento.TemplateMethod.ConcreteClasses
{
    // Subclase concreta: Café Expreso
    public class CafeteraExpreso : PreparadorBebida
    {
        public CafeteraExpreso() : base("Café Americano")
        {
        }

        protected override string ElaborarIngrediente()
        {
            return "Pasando el vapor y agua a presión por los granos de café tostado fino.";
        }

        protected override string AgregarAcompanamiento()
        {
            return "Agregando un toque de crema de leche espumada y canela en polvo.";
        }
    }
}

