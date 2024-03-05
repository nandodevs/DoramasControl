using System;
using System.ComponentModel.DataAnnotations;

namespace DoramasControl.Models
{
    public enum StatusDorama
    {
        Iniciado,
        NaoIniciado,
        Concluido,
        Proximo
    }


    public class DoramasModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite a nacionalidade do Dorama!")]
        public string Nacionalidade { get; set; }

        [Required(ErrorMessage = "Digite o nome do Dorama!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o status do Dorama!")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Digite quantos episódios tem o Dorama!")]
        public int QtdEpisodios { get; set; }

        [Required(ErrorMessage = "Digite a data que você está iniciando o Dorama!")]
        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }
    }
}
