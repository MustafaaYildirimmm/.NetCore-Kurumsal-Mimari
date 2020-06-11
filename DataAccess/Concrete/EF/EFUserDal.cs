using Core.DataAccess.EF;
using DataAccess.Abstract;
using DataAccess.Concrete.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entities;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EF
{
    public class EFUserDal : EFRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }
        }

        public List<OperationClaim> GetClaimsWithLinq(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = context.UserOperationClaims.Join(
                    context.OperationClaims,
                    userOpClaim => userOpClaim.OperationClaimId,
                    entry => entry.Id,
                    (userOpClaim, entry) => new { UserOperationClaim = userOpClaim, OperationClaim = entry }
                    ).Select(x => x.OperationClaim);

                return result.ToList();
            }
        }
    }
}
