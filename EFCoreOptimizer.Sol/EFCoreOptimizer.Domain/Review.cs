using System;

namespace EFCoreOptimizer.Domain
{
    public class Review
    {
        public Guid Id { get; set; }
        public string VoterName { get; set; }
        public int Stars { get; set; }
        public Product Product { get; set; }
    }
}
