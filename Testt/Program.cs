using DataAccess.Concrete.EF;
using DataAccess.Concrete.EF.Contexts;
using Core.Entities.Concrete;
using System;
using System.Linq;

namespace Testt
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NorthwindContext())
            {
                var user = context.Users.FirstOrDefault();
                var userClaims = new EFUserDal().GetClaims(user);
                var userClaimsWithLinq = new EFUserDal().GetClaimsWithLinq(user);

            }

            Console.WriteLine("Hello World!");
        }
    }
}
