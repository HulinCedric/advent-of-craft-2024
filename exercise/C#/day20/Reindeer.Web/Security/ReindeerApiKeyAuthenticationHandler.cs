using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Reindeer.Web.Security;

public class ReindeerApiKeyAuthenticationHandler : AuthenticationHandler<ReindeerApiKeyAuthenticationOptions>
{
    public ReindeerApiKeyAuthenticationHandler(
        IOptionsMonitor<ReindeerApiKeyAuthenticationOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue("API_KEY", out var apiKeyValue) || string.IsNullOrEmpty(apiKeyValue))
            return Task.FromResult(AuthenticateResult.Fail("API_KEY header missing or empty."));

        // Create a ClaimsPrincipal if needed. Here we just create an empty principal.
        var claims = new[] { new Claim(ClaimTypes.Name, "APIUser") };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        // If you don't want to verify the value, just success if it's present.
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}