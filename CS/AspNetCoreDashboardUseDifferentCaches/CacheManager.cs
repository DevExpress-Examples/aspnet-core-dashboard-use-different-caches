using Microsoft.AspNetCore.Http;
using System;

namespace AspNetCoreDashboardUseDifferentCaches
{
    public class CacheManager {
        const string SessionKey = "UniqueCacheParam";
        protected IHttpContextAccessor HttpContextAccessor { get; }

        public CacheManager(IHttpContextAccessor httpContextAccessor) {
            this.HttpContextAccessor = httpContextAccessor;
        }

        public void ResetCache() {
            HttpContextAccessor?.HttpContext?.Session?.SetString(SessionKey,Guid.NewGuid().ToString());
        }
        public Guid UniqueCacheParam {
            get {
                ISession session = HttpContextAccessor?.HttpContext?.Session;
                if(session == null) {
                    return Guid.Empty;
                } else {
                    if(string.IsNullOrEmpty(session.GetString(SessionKey)))
                        ResetCache();
                    return Guid.Parse(session.GetString(SessionKey));
                }
            }
        }
    }
}
