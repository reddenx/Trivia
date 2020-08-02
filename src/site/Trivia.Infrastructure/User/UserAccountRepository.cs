using System;
using System.Collections.Generic;
using System.Text;
using Trivia.Core.User;
using Trivia.Core.User.Infrastructure;

namespace Trivia.Infrastructure.User
{
    public class UserAccountRepository : IUserAccountRepository
    {
        public UserAccount Get(string id)
        {

            //var factory = new UserAccountFactory();
            //var sql = @"";
            //using (var conn = new MySqlConnection(connectionString))
            //{
            //    var data = sql.Execute<DataBinding>();
            //    var obj = factory.Hydrate(data.id, data.username);
            //}



                throw new NotImplementedException();
        }

        public UserAccount GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public UserAccount Save()
        {
            throw new NotImplementedException();
        }
    }
}
