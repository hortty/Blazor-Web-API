namespace BlazorWebApp.DTOs
{
    public abstract class BaseDTO
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Ativo { get; set; }
    }

}
