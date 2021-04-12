using Gifter.Models;
using Gifter.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace Gifter.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration) { }


        public List<UserProfile> GetAllUsers()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Name, Email, ImageUrl, Bio, DateCreated
                        FROM UserProfile";

                    var reader = cmd.ExecuteReader();

                    var users = new List<UserProfile>();
                    while (reader.Read())
                    {
                        users.Add(new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            DateCreated = DbUtils.GetDateTime(reader, "DateCreated"),
                            ImageUrl = DbUtils.GetString(reader, "ImageUrl"),
                        });

                       
                    }

                    reader.Close();

                    return users;
                }
            }
        }


        public void Add(UserProfile user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO UserProfile (Name, Email, ImageUrl, Bio, DateCreated)
                        OUTPUT INSERTED.ID
                        VALUES (@Name, @Email, @ImageUrl, @Bio, @DateCreated)";

                    DbUtils.AddParameter(cmd, "@Name", user.Name);
                    DbUtils.AddParameter(cmd, "@Email", user.Email);
                    DbUtils.AddParameter(cmd, "@ImageUrl", user.ImageUrl);
                    DbUtils.AddParameter(cmd, "@Bio", user.Bio);
                    DbUtils.AddParameter(cmd, "@DateCreated", user.DateCreated);
                    

                    user.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(UserProfile user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE UserProfile
                           SET Name = @Name,
                               Email = @Email,
                               ImageUrl = @ImageUrl,
                               Bio = @Bio,
                               DateCreated = @DateCreated
                                WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@Name", user.Name);
                    DbUtils.AddParameter(cmd, "@Email", user.Email);
                    DbUtils.AddParameter(cmd, "@ImageUrl", user.ImageUrl);
                    DbUtils.AddParameter(cmd, "@Bio", user.Bio);
                    DbUtils.AddParameter(cmd, "@DateCreated", user.DateCreated);
                    DbUtils.AddParameter(cmd, "@Id", user.Id);


                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM UserProfile WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
