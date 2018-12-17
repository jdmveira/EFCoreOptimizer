using EFCoreOptimizer.Logger;
using EFCoreOptimizer.Persistence.Context;
using EFCoreOptimizer.Persistence.EFCHelpers;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EFCoreOptimizer.Commands
{
    public abstract class DbCommand
    {
        protected DataContext dataContext;

        public void Run()
        {
            Execute(RunAction);
        }

        protected virtual void Execute(Action action)
        {
            using (dataContext = new DataContext(SqliteInMemory.CreateOptions<DataContext>()))
            {
                dataContext.Database.EnsureCreated();
                dataContext.SeedDatabaseProducts();

                var logs = InitializeLogger();
                action();
                logs.ForEach(Console.WriteLine);
            }
        }

        protected abstract void RunAction();

        private List<string> InitializeLogger()
        {
            var logs = new List<string>();
            var serviceProvider = dataContext.GetInfrastructure();
            var loggerFactory = (ILoggerFactory)serviceProvider.GetService(typeof(ILoggerFactory));
            loggerFactory.AddProvider(new CustomLoggerProvider(logs));
            return logs;
        }
    }
}
