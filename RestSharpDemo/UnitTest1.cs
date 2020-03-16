using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using RestSharp.Deserializers;
using RestSharp.Serialization.Json;
using Google.Protobuf.Collections;
using RestSharpDemo.Model;

namespace RestSharpDemo
{
    [TestFixture]
    public class UnitTest1
    {
 
        [Test]
        public void GetOperation()
        {
            // var Client = new RestClient("https://reqres.in/api/");
            // var request = new RestRequest("users/{userid}", Method.GET);


            // request.AddUrlSegment("userid", 2);


             var Client = new RestClient("http://dummy.restapiexample.com/api/v1/");
             var request = new RestRequest("employees", Method.GET);


            var response = Client.Execute(request);
            

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize < Dictionary < string, string>> (response);
            var results = output["status"];
            Assert.That(results, Is.EqualTo("success"), "name is not correct");
            

        }
        [Test]
        public void PostWithAnonymouseBody()
        {
             var Client = new RestClient("https://reqres.in/api/");
            var request = new RestRequest("users", Method.POST);


            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { name = "k" });

            var response = Client.Execute(request);


            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var results = output["name"];
            Assert.That(results, Is.EqualTo("k"), "name is not correct");



        }

        [Test]
        public void PostWithTypedBody()
        {
            var Client = new RestClient("https://reqres.in/api/");
            var request = new RestRequest("users", Method.POST);


            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new Posts(){ name = "umer", job = "IT" });

            var response = Client.Execute(request);


            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            var results = output["name"];
            Assert.That(results, Is.EqualTo("umer"), "name is not correct");



        }
    }
}