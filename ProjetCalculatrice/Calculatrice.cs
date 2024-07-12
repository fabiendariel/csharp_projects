using System;
using ProjetCalculatrice.Operations;

namespace ProjetCalculatrice
{
    public class Calculatrice
    {
        public IOperation Operation { get; }

        public int Resultat => Operation.Resultat;

        public Calculatrice(IOperation operation)
        {
            Historique.Operations.Add(operation);
            Operation = operation;
        }

        public void Executer()
        {
            Operation.Executer();
        }
    }
}
