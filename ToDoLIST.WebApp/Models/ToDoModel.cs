namespace ToDoLIST.WebApp.Models
{
    public class ToDoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UserId { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool FoiFinalizado { get; set; }
    }
}
