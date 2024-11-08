using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtletaApi.Models;

namespace AtletaApi.Dtos
{
    public class AtletaDTO
    {
        public AtletaDTO() { }
        public AtletaDTO(Atleta obj)
        {
            this.Id = obj.Id.ToString();
            this.Nome = obj.Nome;
            this.Altura = obj.Altura;
            this.Peso = obj.Peso;
        }

        public string Id { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public Double Altura { get; set; }
        public Double Peso { get; set; }

        public Atleta GetModel()
        {
            var model = new Atleta();
            preencherModel(model);
            return model;
            /*             return new Atleta
                        {
                            Id = Convert.ToInt64(this.Id),
                            Nome = this.Nome,
                            Altura = this.Altura,
                            Peso = this.Peso
                        }; */
        }

        public void preencherModel(Atleta obj)
        {
            long.TryParse(this.Id, out long id);
            obj.Id = id;
            obj.Nome = this.Nome;
            obj.Altura = this.Altura;
            obj.Peso = this.Peso;
        }
    }
}