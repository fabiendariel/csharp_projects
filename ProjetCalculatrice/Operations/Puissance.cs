using System;

namespace ProjetCalculatrice.Operations
{
    public class Puissance : Operation
    {
        public Puissance(int operandeGauche, int operandeDroite) : base(operandeGauche, operandeDroite)
        {
        }

        public override void Executer()
        {
            Resultat = (int) Math.Pow(OperandeGauche, OperandeDroite);
        }

        public override string ToString()
        {
            return $"{OperandeGauche} ^ {OperandeDroite} = {Resultat}";
        }
    }
}
