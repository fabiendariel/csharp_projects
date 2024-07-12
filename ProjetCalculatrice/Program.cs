using ProjetCalculatrice;
using ProjetCalculatrice.Operations;

while (true)
{
  Console.WriteLine("Saisissez l'opérateur ou taper 'q' pour quitter");
  var operateur = Console.ReadLine();

  if (operateur == "q")
  {
    break;
  }

  Console.WriteLine("Saisissez le premier nombre");
  var o1 = int.Parse(Console.ReadLine());

  Console.WriteLine("Saisissez le second nombre");
  var o2 = int.Parse(Console.ReadLine());  

  IOperation operation;

  if (operateur == "+")
  {
    operation = new Addition(o1, o2);
  }
  else if (operateur == "-")
  {
    operation = new Soustraction(o1, o2);
  }
  else if (operateur == "*")
  {
    operation = new Multiplication(o1, o2);
  }
  else if (operateur == "/")
  {
    operation = new Division(o1, o2);
  }
  else if (operateur == "%")
  {
    operation = new Modulo(o1, o2);
  }
  else if (operateur == "^")
  {
    operation = new Puissance(o1, o2);
  }
  else
  {
    Console.WriteLine("Operateur non reconnue");
    return;
  }
  Calculatrice calc = new(operation);
  calc.Executer();

  Console.WriteLine("La résultat de votre opération est " + calc.Resultat);
}

Console.WriteLine("-----------------");
Console.WriteLine("Historique :");
foreach (var ope in Historique.Operations)
{
  Console.WriteLine(ope.ToString());
}
