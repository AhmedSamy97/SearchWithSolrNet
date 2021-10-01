using Microsoft.Practices.ServiceLocation;
using SearchLibrary.Models;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLibrary.Implementation
{
    internal class Connection
    {
        //Initialize the connection and provide it to the search library        
        internal Connection(string coreUrl)
        {
            InitializeConnection(coreUrl);
        }
        private void InitializeConnection(string coreUrl)
        {
            Startup.Init<Course>(coreUrl);
        }

       internal ISolrOperations<Course> GetSolrInstance()
        {
            return ServiceLocator.Current.GetInstance<ISolrOperations<Course>>();
        }
    }
}
