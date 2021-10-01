using SearchLibrary.Models;
using SolrNet;
using SolrNet.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLibrary.Implementation
{
    internal class ResponseExtraction
    {
        //Extract parts of the SolrNet response and set them in QueryResponse class
        public void SetHeader(QueryResponse queryResponse, SolrQueryResults<Course> solrResults)
        {
            queryResponse.QueryTime = solrResults.Header.QTime;
            queryResponse.Status = solrResults.Header.Status;
            queryResponse.TotalHits = solrResults.NumFound;
        }

        public void SetBody(QueryResponse queryResponse, SolrQueryResults<Course> solrResults)
        {
            queryResponse.Results = (List<Course>) solrResults;
        }

        public void SetSpellCheck(QueryResponse queryResponse, SolrQueryResults<Course> solrResults)
        {
            var spellchecking = new List<string>();
            foreach (var spellresult in solrResults.SpellChecking)
            {
                foreach (var suggestion in spellresult.Suggestions)
                {
                    spellchecking.Add(suggestion);
                }
            }

            queryResponse.DidYouMean = spellchecking;
        }
    }
}
