using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NSE.WebAPI.Core.Identidade
{
	public class ClaimsAuthorizeAttribute : TypeFilterAttribute
	{
		public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFiilter))
		{
			Arguments = new object[] { new Claim(claimName, claimValue) };
		}
	}
}
