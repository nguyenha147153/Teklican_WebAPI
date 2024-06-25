using Mapster;
using Teklican.Application.Authentication.Common;
using Teklican.Contracts.Authentication;

namespace Teklican.API.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, scr => scr.User);
        }
    }
}
