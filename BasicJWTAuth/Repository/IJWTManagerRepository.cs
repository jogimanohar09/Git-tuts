using BasicJWTAuth.Model;
namespace BasicJWTAuth.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users user);
    }
}
