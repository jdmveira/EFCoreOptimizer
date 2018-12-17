﻿using System.Linq;

namespace EFCoreOptimizer.Commands
{
    public class QueryToTuneCommand : DbCommand
    {
        protected override void RunAction()
        {
            var products = dataContext.Products
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Description,
                    x.Price,
                    Voter = string.Join(',', x.Reviews.Select(y=>y.VoterName))
                })
                .ToList();
        }
    }
}