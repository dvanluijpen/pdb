using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PeelseDartBond.Utilities;

namespace PeelseDartBond.Services
{
    public abstract class RestService
    {
        const string LogCategory = "HTTP";

        protected async Task<T> PerformAndDeserializeRequestAsync<T>(string url, HttpMethod httpMethod = null, HttpContent httpContent = null)
        {
            T serializedResult = default(T);
            HttpResponseMessage httpResponse;

            try
            {
                httpResponse = await PerformRequestAsync(url, httpMethod, httpContent);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var res = await httpResponse.Content.ReadAsStringAsync();
                    Logger.Error(res);
                    throw new Exception($"Response error (statuscode {httpResponse.StatusCode})");
                }

                var content = await httpResponse.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(content))
                {
                    Logger.WriteLine(System.Diagnostics.TraceLevel.Verbose, $"{(int)httpResponse.StatusCode} {httpResponse.ReasonPhrase} response from {url}", "(no content)", LogCategory);
                }
                else
                {
                    var details = content.Length >= 256 ? content.Substring(0, 256) : content;
                    Logger.WriteLine(System.Diagnostics.TraceLevel.Verbose, $"{(int)httpResponse.StatusCode} {httpResponse.ReasonPhrase} response from {url}", details, LogCategory);
                    Logger.Verbose($"Serializing content to: {typeof(T)}", LogCategory);

                    serializedResult = JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (JsonException ex)
            {
                Logger.Error("Serialization error: Error while serializing the JSON result.", ex);
                throw new Exception("Serialization error", ex);
            }
            catch (Exception ex)
            {
                Logger.Error("Other error", ex);
                throw new Exception("Other error", ex);
            }

            return serializedResult;
        }

        protected static HttpContent CreateJsonContent(object obj)
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Logger.WriteLine(System.Diagnostics.TraceLevel.Verbose, $"Creating request content", json, LogCategory);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        static async Task<HttpResponseMessage> PerformRequestAsync(string url, HttpMethod httpMethod = null, HttpContent httpContent = null)
        {
            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("ZUMO-API-VERSION", "2.0.0");
                    client.Timeout = new TimeSpan(0, 0, 30);

                    if (httpMethod == HttpMethod.Put)
                    {
                        Logger.Info($"PUT {url}", LogCategory);
                        response = await client.PutAsync(url, httpContent);
                    }
                    else if (httpMethod == HttpMethod.Post)
                    {
                        Logger.Info($"POST {url}", LogCategory);
                        response = await client.PostAsync(url, httpContent);
                    }
                    else if (httpMethod == HttpMethod.Delete)
                    {
                        Logger.Info($"DELETE {url}", LogCategory);
                        response = await client.DeleteAsync(url);
                    }
                    else
                    {
                        Logger.Info($"GET {url}", LogCategory);
                        response = await client.GetAsync(url);
                    }

                    return response;
                }
                catch (Exception ex)
                {
                    Logger.Error("Network error: Error while performing the REST request.", ex);
                    throw new Exception("Network error", ex);
                }
            }
        }
    }
}
