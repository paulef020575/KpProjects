using KpProjects.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KpProjects.Connector
{
    public interface IDataClient
    {
        Task<IEnumerable<TDataClass>> LoadList<TDataClass>() where TDataClass : DataClass;

        Task<TDataClass> Load<TDataClass>(Guid guid) where TDataClass : DataClass;
    }
}
