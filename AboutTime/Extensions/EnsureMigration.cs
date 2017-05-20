using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace AboutTime.Extensions
{
    /// <summary>
    /// Contains extension methods for running migrations against a DbContext
    /// </summary>
    public static class EnsureMigration
    {
        /// <summary>
        /// Use this extension method to ensure that your context has run migrations.
        /// </summary>
        /// <typeparam name="T">The type of the Context to run migrations for</typeparam>
        /// <param name="app">The applicationbuilder instance.</param>
        public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T : DbContext
        {
            var context = app.ApplicationServices.GetService(typeof(T)) as T;
            context.Database.Migrate();
        }
    }
}
