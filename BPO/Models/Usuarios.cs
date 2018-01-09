using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPO.Models
{
    public class Usuarios
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Senha")]
        public string password { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Login")]
        public string username { get; set; }

        [Display(Name = "Tipo Usuário")]
        public string descricao { get; set; }

        public bool acesso { get; set; }

        
    }
}