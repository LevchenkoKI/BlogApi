using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace CoolBlogCore
{
    public class EntryRepository<T> : IRepository<T> where T : BasicEntry
    {
        
       

        private List<T> entries;
    
        string pathRepository = @Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +
                                "/Repository of " + typeof (T) + ".txt";


        private static EntryRepository<T> instance;

        private EntryRepository()
        {
           
            
            InitList();


        }
        
        private void InitList()
        {

            try
            {
                using (StreamReader sr = new StreamReader(pathRepository, System.Text.Encoding.Default))
                {
                    string str = sr.ReadToEnd();

                    entries = JsonConvert.DeserializeObject<List<T>>(str);

                }
            }
            catch (Exception)
            {

                
                  FileStream fs = File.Create(pathRepository);
                  fs.Close();
               

            }
            finally
            {
                if (entries==null)
                {
                    entries = new List<T>();
                }
                else if(entries.Max(entry => entry.EntryID)>IDentifier.currentID)
                {
                    IDentifier.currentID = entries.Max(entry => entry.EntryID);
                }
               

            }

        }
        public static EntryRepository<T> GetInstance()
        {
            if (instance == null)
            {
                instance = new EntryRepository<T>();
            }
            return instance;
        }
       

        public void SaveInstance(T instance)
        {
           
                if (instance!= null)
                {
                    entries.Add(instance);
                    UpdateFile();
                 
            }
        }

        public void UpdateFile()
        {
             using (
                StreamWriter sw = new StreamWriter(pathRepository, false, System.Text.Encoding.Default))
            {
                sw.Write(JsonConvert.SerializeObject(entries));

            }
        }



        public T GetEntry(int entryId)
        {

            foreach (var entry in entries)
            {
                if (entry.EntryID == entryId)
                {
                    return entry;
                }
            }
            return null;

        }
        public async Task<List<T>> GetFullRepository()
        {
            return await Task.FromResult(entries);

        }

        
    }
}