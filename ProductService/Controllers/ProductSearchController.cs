using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Couchbase.Configuration.Server.Providers;
using Couchbase.Management;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Contracts;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSearchController : ControllerBase
    {
        Cluster cluster;
        public ProductSearchController()
        {
            cluster = new Cluster(new ClientConfiguration
            {
                Servers = new List<Uri> { new Uri("http://localhost:8091/pools") },
                ConfigurationProviders = ServerConfigurationProviders.HttpStreaming
            });

            var authenticator = new PasswordAuthenticator("admin", "123456");
            cluster.Authenticate(authenticator);
        }
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        public void Post([FromBody] SearchQuery searchQuery)
        {
        }

        [HttpPut]
        public void Put([FromBody] Product product)
        {
            //cluster.CreateManager().CreateBucket(new BucketSettings() { Name = "Products" });
            var bucket = cluster.OpenBucket("Products");
            var document = new Document<Product>();
            document.Content = product;
            bucket.Upsert(document);
        }
    }
}
