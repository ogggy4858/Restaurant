using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ViewModels;
using X.PagedList;

namespace Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly RestaurantDbContext _context;

        public UserRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public IPagedList<UserVM> GetList(int page = 1, int pageSize = 10)
        {
            return _context.Users
                .OrderBy(x => x.Id)
                .Select(x => new UserVM()
                {
                    Id = x.Id,
                    AccessFailedCount = x.AccessFailedCount,
                    Email = x.Email,
                    EmailConfirmed = x.EmailConfirmed,
                    LockoutEnabled = x.LockoutEnabled,
                    LockoutEndDateUtc = x.LockoutEndDateUtc,
                    PasswordHash = x.PasswordHash,
                    PhoneNumber = x.PhoneNumber,
                    PhoneNumberConfirmed = x.PhoneNumberConfirmed,
                    SecurityStamp = x.SecurityStamp,
                    TwoFactorEnabled = x.TwoFactorEnabled,
                    UserName = x.UserName,
                    Roles = x.Roles.Select(a => new RoleVM()
                    {
                        Discriminator = a.Discriminator,
                        Id = a.Id,
                        Name = a.Name
                    }).ToList()
                })
                .OrderBy(x => x.UserName)
                .ToPagedList(page, pageSize);
        }

        public void RemoveRole(string userId)
        {
            var user = Detail(userId);
            var adminRoleID = GetRoleId(Common.CommonStatus.AdminRole);

            string queryString = "delete UserRoles where UserId = @userID and RoleId = @roleId";
            var param = new SqlParameter[]
            {
                    new SqlParameter("@userID", user.Id),
                    new SqlParameter("@roleId", adminRoleID)
            };
            _context.Database.ExecuteSqlCommand(queryString, param);

        }

        public void SetRole(string userId, string roleName)
        {
            string queryString = "insert into UserRoles(UserId, RoleId) values (@userId, @roleId)";
            var idRole = GetRoleId(roleName);
            var user = Detail(userId);

            var param = new SqlParameter[]
            {
                    new SqlParameter("@userId", user.Id),
                    new SqlParameter("@roleId", idRole)
            };

            _context.Database.ExecuteSqlCommand(queryString, param);
        }

        private User Detail(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException();
            }
            var detail = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (detail == null)
            {
                throw new NullReferenceException();
            }
            return detail;
        }

        private string GetRoleId(string roleName)
        {
            var role = _context.Roles.Where(x => x.Name == roleName).FirstOrDefault();
            if (role == null)
            {
                return null;
            }
            return role.Id;
        }

        public bool IsAdmin(string email)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@email", email)
            };

            var check = _context.Database.SqlQuery<bool>("GetRoleByEmail @email", param).FirstOrDefault();
            return check;
        }
    }
}
