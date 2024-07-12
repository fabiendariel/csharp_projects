using System;

namespace ProjetCalculatrice.Operations
{
    public class Division : Operation
    {
        public Division(int operandeGauche, int operandeDroite) : base(operandeGauche, operandeDroite)
        {
        }

        public override void Executer()
        {
            if (OperandeDroite != 0)
            {
                Resultat = OperandeGauche / OperandeDroite;
            }
        }

        public override string ToString()
        {
            return $"{OperandeGauche} / {OperandeDroite} = {Resultat}";
        }
    }
}
