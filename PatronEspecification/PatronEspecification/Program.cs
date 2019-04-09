using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronEspecification
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Mobile> mobiles = new List<Mobile> {
            new Mobile(BrandName.Samsung, Type.Smart, 700),
            new Mobile(BrandName.Apple, Type.Smart, 700),
            new Mobile(BrandName.Htc, Type.Basic),
            new Mobile(BrandName.Samsung, Type.Basic) };

            ISpecification<Mobile> samsungExpSpec =
               new ExpressionSpecification<Mobile>(o => o.BrandName == BrandName.Samsung);
            ISpecification<Mobile> htcExpSpec =
               new ExpressionSpecification<Mobile>(o => o.BrandName == BrandName.Htc);
            ISpecification<Mobile> SamsungHtcExpSpec = samsungExpSpec.Or(htcExpSpec);
            ISpecification<Mobile> NoSamsungExpSpec =
              new ExpressionSpecification<Mobile>(o => o.BrandName != BrandName.Samsung);

            var samsungMobiles = mobiles.FindAll(o => samsungExpSpec.IsSatisfiedBy(o));
            var htcMobiles = mobiles.FindAll(o => htcExpSpec.IsSatisfiedBy(o));
            var samsungHtcMobiles = mobiles.FindAll(o => SamsungHtcExpSpec.IsSatisfiedBy(o));
            var noSamsungMobiles = mobiles.FindAll(o => NoSamsungExpSpec.IsSatisfiedBy(o));

            ISpecification<Mobile> premiumSpecification = new PremiumSpecification<Mobile>(600);
            ISpecification<Mobile> LinqNonLinqExpSpec = NoSamsungExpSpec.And(premiumSpecification);

            var linqNonLinqExpSpec = mobiles.FindAll(o => LinqNonLinqExpSpec.IsSatisfiedBy(o));

        }
    }
}
