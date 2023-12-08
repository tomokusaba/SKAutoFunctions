using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace ConsoleApp17;

public class Plugin
{
    private readonly HttpClient _client = new();

    [KernelFunction, Description("今日の日付を返す")]
    public static string Today()
    {
        return DateTime.Now.ToString("yyyy/MM/dd");
    }

    [KernelFunction, Description("今日の曜日を返す")]
    public static string DayOfWeek()
    {
        return DateTime.Now.ToString("dddd");
    }

    [KernelFunction, Description("今の時間を返す")]
    public static string Now()
    {
        return DateTime.Now.ToString("HH:mm:ss");
    }

    [KernelFunction, Description("東京の天気を返す")]
    public async Task<string> Weather()
    {
        return (await _client.GetAsync("https://www.jma.go.jp/bosai/forecast/data/forecast/130000.json")).Content.ReadAsStringAsync().Result;
    }
}
