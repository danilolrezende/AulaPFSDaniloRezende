using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtletaApi.Models;

namespace AtletaApi.Dtos
{
    public class UsuarioDTO
    {
        
        public UsuarioDTO() { }
        public UsuarioDTO(Usuario obj)
        {
            this.Id = obj.Id.ToString();
            this.Nome = obj.Nome;
            this.Email = obj.Email;
        }

        public string Id { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Usuario GetModel()
        {
            var model = new Usuario();
            preencherModel(model);
            return model;
        }

        public void preencherModel(Usuario obj)
        {
            long.TryParse(this.Id, out long id);
            obj.Id = id;
            obj.Nome = this.Nome;
            obj.Email = this.Email;
        }
        
    }
}
