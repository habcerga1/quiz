using System.Text;
using Domain.Dto;
using Domain.Token;
using Newtonsoft.Json;

namespace ControllerTest.Services;

public class ContentService
{
    public static StringContent CreateStringContent(LoginDto item, string type = "application/json")
    {
        var json = JsonConvert.SerializeObject(item);
        return new StringContent(json, UnicodeEncoding.UTF8, type);
    }
    
    public static StringContent CreateStringContent(RegistrationDto item, string type = "application/json")
    {
        var json = JsonConvert.SerializeObject(item);
        return new StringContent(json, UnicodeEncoding.UTF8, type);
    }
    
    public static StringContent CreateStringContent(QuizDto item, string type = "application/json")
    {
        var json = JsonConvert.SerializeObject(item);
        return new StringContent(json, UnicodeEncoding.UTF8, type);
    }
    
    public static StringContent CreateStringContent(Token item, string type = "application/json")
    {
        var json = JsonConvert.SerializeObject(item);
        return new StringContent(json, UnicodeEncoding.UTF8, type);
    }
    
    public static StringContent CreateStringContent(string item, string type = "application/json")
    {
        var json = JsonConvert.SerializeObject(item);
        return new StringContent(json, UnicodeEncoding.UTF8, type);
    }
    
    
}