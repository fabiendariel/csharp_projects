const int BorneMin = 1;
const int BorneMax = 100;

Random rand = new();
int nbMystere = rand.Next(BorneMax + 1);

bool gagne = false;

List<int> nombresJoues = [];
string indication = "";
while (!gagne)
{

  Console.Clear();

  if (nombresJoues is not [])
  {
    Console.Write("Nombres joués :");
    foreach (int nb in nombresJoues)
    {
      Console.Write($" {nb}, ");
    }
    Console.WriteLine();
  }
  if (!string.IsNullOrEmpty(indication))
  {
    Console.WriteLine(indication);
  }

  Console.WriteLine($"Saisir un nombre entre {BorneMin} et {BorneMax}");

  int nombre = 0;
  while (nombre < BorneMin || nombre > BorneMax)
  {    
    try
    {
      nombre = int.Parse(Console.ReadLine());
    }
    catch
    {
      nombre = 0;
    }
  }  
  nombresJoues.Add(nombre);

  if (nombre == nbMystere)
  {
    Console.WriteLine("Félicitations! Vous avez trouvé le nombre mystère.");
    gagne = true;
  }
  else
  {
    if (nombre < nbMystere)
    {
      indication = "Le nombre mystère est plus grand";
    }
    else
    {
      indication = "Le nombre mystère est plus petit";
    }
  }
}