//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }

            double totalCost = GetProductionCost();
            Console.WriteLine($"Costo de producción: {totalCost}");
        }

    public double GetProductionCost()
        {
            double costInsumos = 0;
            double costEquipos = 0;
            foreach (Step step in this.steps)
            {
                costInsumos = step.Quantity * step.Input.UnitCost;
           
            }
            foreach (Step step in this.steps)
            {
                costEquipos += (step.Time / 60.0) * step.Equipment.HourlyCost;
            }

            double totalCost = costInsumos + costEquipos;
            return totalCost;
        }
    }
}
//La modificación sigue el principio de Responsabilidad Única (SRP), ahora la clase Recipe tiene la unica responsabilidad de gestionar la receta y calcular su costo total de producción.