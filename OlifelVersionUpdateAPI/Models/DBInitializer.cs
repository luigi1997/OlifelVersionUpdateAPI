using System;
using System.Linq;

namespace OlifelVersionUpdateAPI.Models
{
    public class DBInitializer
    {
        public static void Initialize(ProjectContext context)
        {
            context.Database.EnsureCreated();

            if (context.Utilizadores.Any())
            {
                return; // DB has been seeded
            }

            //preenche a base de dados
            Utilizador utilizador = new Utilizador { Nome = "Admin", Email = "olifel2020@hotmail.com", Password = "12345678", Admin = true, Data_criacao = DateTime.Now, Data_ultima_alteracao = DateTime.Now };
            context.Utilizadores.Add(utilizador);
            context.SaveChanges();
        }
    }
}
