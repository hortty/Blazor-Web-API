namespace BlazorWebApp.DTOs
{
    public class ResultDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object ResultObj { get; set; }

        public ResultDTO()
        {

        }

        public ResultDTO(bool sucesso, string mensagem)
        {
            Success = sucesso;
            Message = mensagem;
        }

        public ResultDTO(bool sucesso, string mensagem, object obj)
        {
            Success = sucesso;
            Message = mensagem;
            ResultObj = obj;
        }

    }

    public class ResultDTO<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T ResultObj { get; set; }

        public ResultDTO(bool sucesso, string mensagem, T retorno)
        {
            Success = sucesso;
            Message = mensagem;
            ResultObj = retorno;
        }

    }
}
