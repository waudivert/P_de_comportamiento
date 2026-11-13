using System.Collections.Generic;

namespace Patrones_Comportamiento.TemplateMethod.AbstractClass
{
    // Clase Abstracta (Plantilla): Define el esqueleto del algoritmo de preparación
    public abstract class PreparadorBebida
    {
        public string NombreBebida { get; }

        protected PreparadorBebida(string nombreBebida)
        {
            NombreBebida = nombreBebida;
        }

        // TEMPLATE METHOD: Define la secuencia exacta e inalterable de pasos
        public List<PasoReceta> PrepararReceta(bool conEndulzante)
        {
            var pasos = new List<PasoReceta>();

            // Paso 1 (Común): Calentar el agua
            pasos.Add(new PasoReceta("Paso 1: Calentar agua", HervirAgua(), true));

            // Paso 2 (Específico): Elaborar o infusionar el ingrediente clave
            pasos.Add(new PasoReceta("Paso 2: Elaborar bebida", ElaborarIngrediente(), false));

            // Paso 3 (Común): Servir en la taza o vaso
            pasos.Add(new PasoReceta("Paso 3: Servir en recipiente", ServirEnTaza(), true));

            // Paso 4 (Específico): Agregar condimento / acompañamiento
            pasos.Add(new PasoReceta("Paso 4: Añadir toque característico", AgregarAcompanamiento(), false));

            // Paso 5 con Hook / Gancho opcional
            if (conEndulzante)
            {
                pasos.Add(new PasoReceta("Paso 5: Endulzar (Opcional)", "Se añade azúcar morena orgánica.", true));
            }
            else
            {
                pasos.Add(new PasoReceta("Paso 5: Sin endulzante", "Se sirve al natural sin azúcar.", true));
            }

            return pasos;
        }

        // Métodos comunes implementados en la clase base
        protected virtual string HervirAgua()
        {
            return "Hirviendo agua pura a 90°C...";
        }

        protected virtual string ServirEnTaza()
        {
            return "Vertiendo la infusión en una taza de cerámica precalentada...";
        }

        // Métodos abstractos que cada bebida DEBE personalizar
        protected abstract string ElaborarIngrediente();
        protected abstract string AgregarAcompanamiento();
    }

    public class PasoReceta
    {
        public string Titulo { get; }
        public string Descripcion { get; }
        public bool EsPasoComun { get; }

        public string TipoPasoTexto => EsPasoComun ? "Paso común de la plantilla" : "Paso personalizado por la bebida";
        public string ColorTipo => EsPasoComun ? "#267453" : "#B45309";

        public PasoReceta(string titulo, string descripcion, bool esPasoComun)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            EsPasoComun = esPasoComun;
        }
    }
}

