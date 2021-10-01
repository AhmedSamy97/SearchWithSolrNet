using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchLibrary.Models;
using SearchLibrary.Implementation;
using SolrNet.Commands.Parameters;
using SolrNet;

namespace SearchLibrary
{
    public class CourseSearch
    {
        private Connection connection;

        public CourseSearch()
        {
            //Initialize connection
            //Connection can be initialized once and then retrieved via ServiceLocator.GetInstance
            //But we are creating it for every search library instantiation for demo purposes
            connection = new Connection("http://localhost:8983/solr/courses");
        }

        public QueryResponse DoSearch(CourseQuery query)
        {
            //Create an object to hold results
            SolrQueryResults<Course> solrResults;
            QueryResponse queryResponse = new QueryResponse();

            //Echo back the original query                       
            queryResponse.OriginalQuery = query;

            //Get a connection
            ISolrOperations<Course> solr = connection.GetSolrInstance();
            QueryOptions queryOptions = new QueryOptions
            {
                Rows = query.Rows,
                StartOrCursor = new StartOrCursor.Start(query.Start),
                ExtraParams = new KeyValuePair<string, string>[]
                {
                    new KeyValuePair<string, string>("wt","xml")
                }
                

            };
            //Execute the query
            SolrQuery solrqQuery = new SolrQuery(query.Query);
            solrResults = solr.Query(solrqQuery, queryOptions);

            //Set response
            ResponseExtraction extactResponse = new ResponseExtraction();               
            extactResponse.SetHeader(queryResponse, solrResults);
            extactResponse.SetBody(queryResponse, solrResults);
            extactResponse.SetSpellCheck(queryResponse, solrResults);
            return queryResponse;

            //Return response;
        }
    }
}