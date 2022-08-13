using System.Security.Principal;

namespace WebMvc.Services
{
    public interface IIdentityService<T>
    {
        T Get(IPrincipal principal);
    }
}
