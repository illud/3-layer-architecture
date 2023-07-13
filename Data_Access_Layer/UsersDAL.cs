using Data_Access_Layer.Repository;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class UsersDAL
    {
        /*private readonly DbCtx _db;

        public UsersDAL(DbCtx contextDb)
        {
            _db = contextDb;
        }*/

        public async Task<string> Create(User user)
        {
            var _db = new DbCtx();
            _db.Add(user);
            await _db.SaveChangesAsync();

            return "Created";
        }

        public async Task<User> GetOneUser(string userName)
        {
            var _db = new DbCtx();
            List<User> userList = await _db.Users.Where(u => u.UserName == userName).ToListAsync();
            return userList[0];
        }

        public async Task<List<User>> GetAllAsers()
        {
            var _db = new DbCtx();
            return await _db.Users.ToListAsync();
        }
    }
}