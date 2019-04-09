using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronEspecification
{
    public class PremiumSpecification<T> : CompositeSpecification<T>
    {
        private int cost;
        public PremiumSpecification(int cost)
        {
            this.cost = cost;
        }

        public override bool IsSatisfiedBy(T o)
        { 
      
            return (o as Mobile).Value >= this.cost;
        }
    }
    
}
