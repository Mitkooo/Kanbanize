using System;
using Kanbanize.DTOs.User;

namespace Kanbanize.Builders.UserBuilder
{
    public class UserBuilder
    {
        private User _user;

        public UserBuilder()
        {
            _user = new User();
        }

        public UserBuilder DefaultUser()
        {
            _user = new User();
            _user.Email = "dimitardinkov09@gmail.com";
            _user.Pass = "mitipiti12";

            return this;
        }

        public User Build()
        {
            return _user;
        }
    }
}
