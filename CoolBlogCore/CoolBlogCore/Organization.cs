using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoolBlogCore
{
    public class Organization
    {
        private List<User> _userList;
        string pathRepository = @Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +
                               "/Repository of Users.txt";
    
        public void AddUserToOrganization(User user)
        {
            _userList.Add(user);
        }

        public User FindUserByID(int ID)
        {

            foreach (var user in _userList)
            {
                if (user.UserId==ID)
                {
                    return user;
                }
            }
            return null;
        }
        private static Organization instance;
        public static Organization GetInstance()
        {
            if (instance == null)
            {
                instance = new Organization();
            }
            return instance;
        }
        private Organization() { InitUsers();}

        private void InitUsers()
        {

            try
            {
                using (StreamReader sr = new StreamReader(pathRepository, System.Text.Encoding.Default))
                {
                    string str = sr.ReadToEnd();

                    _userList = JsonConvert.DeserializeObject<List<User>>(str);

                }
            }
            catch (Exception)
            {


                FileStream fs = File.Create(pathRepository);
                fs.Close();


            }
            finally
            {
                if (_userList == null)
                {
                    _userList = new List<User>();
                }

            }
        }
    }
}
