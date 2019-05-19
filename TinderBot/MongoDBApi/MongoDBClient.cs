using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceDetectionApi;
using System.Collections;
using Models;

namespace MongoDBApi
{
    public class MongoDBClient
    {
        public static MongoDBClient _current = null;
        public static MongoDBClient Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new MongoDBClient();
                }
                return _current;
            }
            set
            {
                Current = value;
            }
        }

        private MongoClient db { get; set; }
        private IMongoDatabase mongoDatabase {get;set;}

        public MongoDBClient()
        {
            string connectionString = ConfigurationManager.AppSettings["MongoDBConnection"];
            string databaseName = ConfigurationManager.AppSettings["MongoDBDatabaseName"];
            this.db = new MongoClient(new MongoUrl(connectionString));
            mongoDatabase = db.GetDatabase(databaseName);
        }

        public void CreateTable(string tableName)
        {
            this.mongoDatabase.CreateCollection(tableName);
        }

        public void CreateTableIfNotExists(string tableName)
        {
            var collection = this.mongoDatabase.GetCollection<Face>(tableName);
            if(collection==null)
            {
                this.mongoDatabase.CreateCollection(tableName);
            }
        }

        public void InsertTrainData(Face faceData, string tableName)
        {
            var collection = this.mongoDatabase.GetCollection<Face>(tableName);
            collection.InsertOne(faceData);
        }

        public void InsertTrainData(List<Face> faceData, string tableName)
        {
            var collection = this.mongoDatabase.GetCollection<Face>(tableName);
            collection.InsertMany(faceData);
        }



        public List<Face> GetAllDataFromTable(string tableName)
        {
            return this.mongoDatabase.GetCollection<Face>(tableName).Find(_ => true).ToList<Face>();
        }
    }
}
