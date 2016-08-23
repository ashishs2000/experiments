using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Algorithms
{
    public interface IImport
    {
        
    }
    public class DepartmentImport : IImport
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class Department
    {
        
    }

    public class FileEntityMapper<T> where T : IImport
    {
        public List<string> GetFields()
        {
            var properties = typeof(T).GetProperties();
            return properties.Select(p => p.Name).ToList();
        }

        public Dictionary<int, Action<T, string>> GetFieldMapping(Dictionary<int, string> entityToFileMaps)
        {
            var mapper = new Dictionary<int, Action<T, string>>();
            foreach (var entityToFileMap in entityToFileMaps)
            {
                var property = typeof(T).GetProperty(entityToFileMap.Value);
                mapper.Add(entityToFileMap.Key, (target, val) => property.SetValue(target, val, null));
            }
            return mapper;
        }

        public T GetEntity(Dictionary<int, Action<T, string>> mapper, string[] rowItems)
        {
            var instance = (T) Activator.CreateInstance(typeof (T));
            for (var i = 0; i < rowItems.Count(); i++)
                mapper[i](instance, rowItems[i]);

            return instance;
        }
    }

    public class DepartmentImportHandler
    {
        
    }


    public class FileMapperTest
    {
        public static void Map()
        {
            var mapper = new FileEntityMapper<DepartmentImport>();

            //STEP 1 - Get Fields for an Entity
            var fields = mapper.GetFields();

            //STEP 2 - Get Mapper
            var maps = mapper.GetFieldMapping(new Dictionary<int, string>
            {
                {0, "ID"},
                {1, "Name"},
                {2, "Code"}
            });

            //STEP 2 - Create Entity
            var dep = mapper.GetEntity(maps, new[] {"1", "Department1", "Department Code 1"});
            var dep2 = mapper.GetEntity(maps, new[] { "2", "Department2", "Department Code 2" });
        }
    }
}