namespace Services
{
    public interface ICurrentUser
    {
        int UsuarioId { get; }
        bool EsAdmin { get; }
    }
}
