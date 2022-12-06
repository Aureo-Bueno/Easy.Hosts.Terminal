using EasyHosts.Terminal.Models;
using EasyHosts.Terminal.Models.Enums;
using System;
using System.Data.Entity.Migrations;

namespace EasyHosts.Terminal.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EasyHosts.Terminal.Models.Context";
        }

        protected override void Seed(Context context)
        {
            context.Perfil.AddOrUpdate(
                   p => p.Description,
                   new Models.Perfil
                   {
                       Id = 1,
                       Description = "Admin"
                   },
                   new Models.Perfil
                   {
                       Id = 2,
                       Description = "Funcionario"
                   },
                   new Models.Perfil
                   {
                       Id = 3,
                       Description = "Hospede"
                   });


            context.User.AddOrUpdate(
                    p => p.Email,
                    new Models.User
                    {
                        Id = 1,
                        Name = "Aureo Alexandre Bueno Azevedo Filho",
                        Email = "aureo.bueno@easy.com.br",
                        Password = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        ConfirmPassword = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        Status = 1,
                        Cpf = "568.974.261/46",
                        Hash = "",
                        PerfilId = 1
                    },
                    new Models.User
                    {
                        Id = 2,
                        Name = "Luiz Guilherme Ribeiro",
                        Email = "luiz.gui@easy.com.br",
                        Password = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        ConfirmPassword = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        Status = 1,
                        Cpf = "568.974.261/46",
                        Hash = "",
                        PerfilId = 2
                    },
                    new Models.User
                    {
                        Id = 3,
                        Name = "Luiz Romao de Carvalho",
                        Email = "luiz.roman@easy.com.br",
                        Password = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        ConfirmPassword = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        Status = 0,
                        Cpf = "568.974.261/46",
                        Hash = "",
                        PerfilId = 1
                    },
                    new Models.User
                    {
                        Id = 4,
                        Name = "Joao Pedro",
                        Email = "joao.pedro@easy.com.br",
                        Password = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        ConfirmPassword = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        Status = 1,
                        Cpf = "568.974.261/46",
                        Hash = "",
                        PerfilId = 1
                    },
                    new Models.User
                    {
                        Id = 5,
                        Name = "Alex",
                        Email = "alex@easy.com.br",
                        Password = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        ConfirmPassword = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        Status = 1,
                        Cpf = "568.974.261/46",
                        Hash = "",
                        PerfilId = 3
                    });

        }
    }
}
