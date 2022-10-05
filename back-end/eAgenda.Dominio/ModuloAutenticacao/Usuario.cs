using Microsoft.AspNetCore.Identity;
using System;

namespace eAgenda.Dominio.ModuloAutenticacao
{
    public class Usuario : IdentityUser<Guid>
    {
        //informações customizadas
        public string Nome { get; set; }

    }
}
