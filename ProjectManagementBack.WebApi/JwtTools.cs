using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
using ProjectManagementBack.WebApi.Models;

namespace ProjectManagementBack.WebApi
{
    public static class ControllerExtention
    {
        public static OkNegotiatedContentResult<ResponseData> ErrorData(this ApiController controller, string error, int code = 500)
        {
            return new OkNegotiatedContentResult<ResponseData>(new ResponseData()
            {
                Code = code,
                ErrorMessage = error,

            }, controller);
        }

        public static OkNegotiatedContentResult<ResponseData> SendData(this ApiController controller, object data)
        {
            return new OkNegotiatedContentResult<ResponseData>(new ResponseData()
            {
                Data = data
            }, controller);
        }
    }

    public class JwtTools
    {
        private static string Key { get; } = "hello world";

        public static string Encoder(Dictionary<string, object> payload, string key = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                key = Key;
            }

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();

            IJsonSerializer serializer = new JsonNetSerializer();

            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();

            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            payload.Add("timeout", DateTime.Now.AddDays(1));

            return encoder.Encode(payload, key);
        }

        public static Dictionary<string, object> Decode(string jwtString, string key = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                key = Key;
            }
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var json = decoder.Decode(jwtString, key, true);

                var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

                if ((DateTime)result["timeout"] < DateTime.Now)
                    throw new Exception("jwt已经过期， 请重新登录");
                result.Remove("timeout");
                return result;
            }
            catch (TokenExpiredException)
            {
                throw;
            }
            catch (SignatureVerificationException)
            {
                throw;
            }

        }
    }
}