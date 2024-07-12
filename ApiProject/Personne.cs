using System;

namespace ApiProject
{
    public class Personne
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }

        // public static bool TryParse(string value, out Personne? person)
        // {
        //     try
        //     {
        //         var data = value.Split(' ');
        //         person = new Personne
        //         {
        //             Nom = data[0],
        //             Prenom = data[1]
        //         }
        //         return true;
        //     }
        //     catch (Exception)
        //     {
        //         person = null;
        //         return false;
        //     }
        // }

        public static async ValueTask<Personne> BindAsync(
            HttpContext context, System.Reflection.ParameterInfo parameterInfo)
        {
            try
            {
                using var streamReader = new StreamReader(context.Request.Body);
                var body = await streamReader.ReadToEndAsync();
                var data = body.Split(' ');
                var person = new Personne
                {
                    Nom = data[0],
                    Prenom = data[1]
                };
                return person;
            }
            catch (Exception)
            {
                return null;
            }
        
        }
    }
}
