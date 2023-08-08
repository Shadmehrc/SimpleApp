using Domain.Entities;

namespace Application.Interfaces;

public interface IUsersDataAccess
{
    public Task<User> GetUser(string userId);
    public Task<bool> AddUser(User user);
    public Task<List<User>> ValidateUser(string userName, string password);
}