using Microsoft.AspNetCore.Http;
using System.Linq;

namespace NSE.WebAPI.Core.Identidade
{
	public class CustomAuthorization
	{
		public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
		{
			return context.User.Identity.IsAuthenticated &&
				context.User.Claims.Any(c => c.Type == claimName && claimValue.Contains(c.Value )) ;
		}
	}
}
