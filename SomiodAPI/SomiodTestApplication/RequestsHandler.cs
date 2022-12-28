﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace SomiodTestApplication
{
    internal class RequestsHandler
    {
        static public void createApplication(string requestURI, RestClient client, string applicationName)
        {
            try
            {
                // Creates the Object Application
                SomiodWebApplication.Models.Application application = new SomiodWebApplication.Models.Application
                {
                    Name = applicationName,
                    Res_type = "application"
                };


                var request = new RestRequest("/api/somiod", Method.Post);
                
                // Adds the message body to the response
                request.AddObject(application);

                RestResponse response = client.Execute(request);
                MessageBox.Show(response.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        static public XmlDocument getResponseAsXMLDocument(string requestURI, RestClient client, string res_type)
        {
            try
            {
                // Creates and Executes a GET request
                RestRequest request = new RestRequest(requestURI, Method.Get);
                RestResponse response = client.Execute(request);

                // Creates the XML document
                var doc = new XmlDocument();

                // Loads the Response XML Content to the XML document
                doc.LoadXml(response.Content);

                // Shows Status Code
                MessageBox.Show(response.StatusCode.ToString());

                return doc;
            }
            catch (Exception)
            {
                throw new Exception("Could not get "+res_type);
            }
        }

        static public void updateApplicationName(string requestURI, RestClient client, string newApplicationName)
        {
            try
            {
                // Creates and Executes a PUT request
                RestRequest request = new RestRequest(requestURI, Method.Put);

                // Creates Application Object
                SomiodWebApplication.Models.Application application = new SomiodWebApplication.Models.Application
                {
                    Name = newApplicationName,
                    Res_type = "application"
                };

                // Adds the message body to the response
                request.AddJsonBody(application);

                RestResponse response = client.Execute(request);
                // Shows Status Code
                MessageBox.Show(response.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        static public void deleteApplication(string requestURI, RestClient client)
        {
            try
            {
                // Creates and Executes a Delete request
                RestRequest request = new RestRequest(requestURI, Method.Delete);
                RestResponse response = client.Execute(request);
                // Shows Status Code
                MessageBox.Show(response.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        static public void createModule(string requestURI, RestClient client, string applicationName, string moduleName)
        {
            try
            {
                // Creates the Object Application
                SomiodWebApplication.Models.Module module = new SomiodWebApplication.Models.Module
                {
                    Name = moduleName,
                    Res_type = "module"
                };


                var request = new RestRequest("/api/somiod/"+applicationName, Method.Post);

                // Adds the message body to the response
                request.AddObject(module);

                RestResponse response = client.Execute(request);
                MessageBox.Show(response.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        static public void updateModule(string requestURI, RestClient client, string newModuleName)
        {
            try
            {
                // Creates and Executes a PUT request
                RestRequest request = new RestRequest(requestURI, Method.Put);

                SomiodWebApplication.Models.Module module = new SomiodWebApplication.Models.Module
                {
                    Name = newModuleName,
                    Res_type = "module"
                };

                // Adds the message body to the response
                request.AddJsonBody(module);

                RestResponse response = client.Execute(request);
                // Shows Status Code
                MessageBox.Show(response.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        static public void deleteModule(string requestURI, RestClient client)
        {
            try
            {
                RestRequest request = new RestRequest(requestURI, Method.Delete);

                RestResponse response = client.Execute(request);
                // Shows Status Code
                MessageBox.Show(response.StatusCode.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}