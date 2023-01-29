namespace API_LojaVirtual.ViewModels
{
    public class ResultadoViewModel<T>
    {
        public ResultadoViewModel(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ResultadoViewModel(T data)
        {
            Data = data;
        }

        public ResultadoViewModel(List<string> errors)
        {
            Errors = errors;
        }

        public ResultadoViewModel(string error)
        {
            Errors.Add(error);
        }

        public T Data { get; private set; }
        public List<string> Errors { get; private set; } = new();
    }
}
