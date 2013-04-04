using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Version = Lucene.Net.Util.Version;
using DataAccess;
using System.IO;

namespace General
{
    public class Lucene_gl
    {
        public void addLucene(Data data)
        {
            Search_gl search = new Search_gl();
            Data searchForIndex = search.getSearchForIndex(data);
            Lucene.Net.Store.Directory directory = FSDirectory.Open(new DirectoryInfo(Environment.CurrentDirectory + "\\LuceneIndex"));
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED);

            for (int i = 0; i < searchForIndex.Count; i++)
            {
                Document document = new Document();
                document.Add(new Field("id", searchForIndex.getValue(i, "id").ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                document.Add(new Field("name", searchForIndex.getValue(i, "name").ToString(), Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS));
                document.Add(new Field("summary", searchForIndex.getValue(i, "summary").ToString(), Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS));
                writer.AddDocument(document);
                writer.Optimize();
                writer.Commit();


            }
            writer.Close();
        }

        public Data searchLucene(Data data)
        {
            Search_gl search = new Search_gl();
            List<string> item = new List<string>();
            Lucene.Net.Store.Directory directory = FSDirectory.Open(new DirectoryInfo(Environment.CurrentDirectory + "\\LuceneIndex"));
            var analyzer = new StandardAnalyzer(Version.LUCENE_29);
            

            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);
            
            //QueryParser queryParser = new QueryParser(Version.LUCENE_29, "summary", analyzer);  //search for single field
            MultiFieldQueryParser parser = new MultiFieldQueryParser(new string[] {"name", "summary"}, analyzer);  //search for multifield
            Query query = parser.Parse((data.getString("search")) + "*"); //cant search blank text with wildcard as first character
            
            TopScoreDocCollector collector = TopScoreDocCollector.create(1000, true);
            searcher.Search(query, collector);
            ScoreDoc[] hits = collector.TopDocs().ScoreDocs;
            int count = hits.Length;


            for (int i = 0; i < count; i++)
            {
                int docId = hits[i].doc;
                float score = hits[i].score;

                Document doc = searcher.Doc(docId);

                string id = doc.Get("id");
                item.Add(id);
            }
            Data list = search.search(data, item.ToArray());
            reader.Close();
            searcher.Close();

            return list;
        }

    }
}
