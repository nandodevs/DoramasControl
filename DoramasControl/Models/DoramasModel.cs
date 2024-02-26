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
        public required string Nacionalidade { get; set; }
        public required string Nome { get; set; }
        public StatusDorama Status { get; set; }
        public int? QtdEpisodios { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}