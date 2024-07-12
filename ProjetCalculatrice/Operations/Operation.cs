using System;

namespace ProjetCalculatrice.Operations
{
    public abstract class Operation : IOperation
    {
        protected int OperandeGauche { get;}
        protected int OperandeDroite { get; }
        public int Resultat { get; protected set; }

        protected Operation(int operandeGauche, int operandeDroite)
        {
            OperandeGauche = operandeGauche;
            OperandeDroite = operandeDroite;
        }

        public abstract void Executer();
    }
}
