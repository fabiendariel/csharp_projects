using System;

namespace ProjetCalculatrice.Operations
{
    public interface IOperation
    {
        void Executer();

        int Resultat { get; }
    }
}
