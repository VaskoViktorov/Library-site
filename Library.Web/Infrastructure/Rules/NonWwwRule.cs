namespace Library.Web.Infrastructure.Rules
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Rewrite;
    using System.Text;

    public class NonWwwRule : IRule
    {
        private const string Www = "www.";

        public void ApplyRule(RewriteContext context)
        {
            var req = context.HttpContext.Request;
            var currentHost = req.Host;
            if (currentHost.Host.StartsWith(Www))
            {
                var newHost = new HostString(currentHost.Host.Substring(4), currentHost.Port ?? 443);
                var newUrl = new StringBuilder().Append(newHost).Append(req.PathBase).Append(req.Path).Append(req.QueryString);
                context.HttpContext.Response.Redirect(newUrl.ToString(), true);
                context.Result = RuleResult.EndResponse;
            }
        }
    }

}
