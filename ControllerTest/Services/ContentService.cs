using System.Text;
using Domain.Dto;
using Newtonsoft.Json;

namespace ControllerTest.Services;

public class ContentService
{
    public static StringContent CreateStringContent(LoginDto item, string type = "application/json")
    {
        var json = JsonConvert.SerializeObject(item);
        return new StringContent(json, UnicodeEncoding.UTF8, type);
    }
}