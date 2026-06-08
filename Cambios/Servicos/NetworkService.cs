namespace Cambios.Servicos
{
    using Modelos;
    using System.Net;

    public class NetworkService
    {
        //public Response checkConnecion()
        //{
        //    var client = new WebClient();
        //    try
        //    {
        //        using (client.OpenRead("http://clients3.google.com/generate_204"))
        //        {
        //            return new Response
        //            {
        //                IsSuccess = true,
        //            };
        //        }
        //    }
        //    catch
        //    {
        //        return new Response
        //        {
        //            IsSuccess = false,
        //            Message = "Configure a sua ligação á Internet",
        //        };
        //    }
        //}


        private static readonly HttpClient client = new HttpClient();

        public async Task<Response> CheckConnection()
        {
            try
            {
                var response = await client.GetAsync("http://clients3.google.com/generate_204");

                return new Response
                {
                    IsSuccess = response.IsSuccessStatusCode
                };
            }
            catch
            {
                return new Response
                {
                   IsSuccess = false,
                    Message = "Configure a sua ligação á Internet"
                };
            }
        }

    }
}
