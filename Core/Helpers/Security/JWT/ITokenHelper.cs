using Core.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateAccessToken(User user, List<OperationClaim> operationClaims);
    }
}
