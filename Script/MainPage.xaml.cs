using CSScriptLib;
namespace Script;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        try
        {
            dynamic calc = CSScript.Evaluator.LoadCode(
                """
                using System;
                public class Script
                {
                    public int Sum(int a, int b)
                    {
                        return a+b;
                    }
                }
                """);

            CounterBtn.Text = $"sum = {calc.Sum(1, 2)}";
        }
        catch(Exception x)
        {
            Shell.Current.DisplayAlert(x.Message, x.StackTrace, "OK");
        }
    }

    public interface ICalc
    {
        int Sum(int a, int b);
    }
}
