using System.Collections.Generic;
using Gifter.Models;

namespace Gifter.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Delete(int id);
        List<Post> GetAll();
        List<Post> GetAllWithComments();
        List<Post> Search(string criterion, bool sortDescending);
        Post GetById(int id);
        Post GetPostByIdWithComments(int id);
        void Update(Post post);
    }
}