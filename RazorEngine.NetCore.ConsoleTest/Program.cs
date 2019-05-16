using System;
using RazorEngine;
using RazorEngine.Templating;

namespace RazorEngine.NetCore.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string template = "Hello @Model.Name, welcome to RazorEngine!";
            //string template = "@inherits RazorEngine.Templating.TemplateBase<Dynamic>\r\n Hello @Model.Name, welcome to RazorEngine! ";

            var result =
                Engine.Razor.RunCompile(template, "templateKey", null, new { Name = "World" });

            Console.WriteLine("Template: {0}", template);
            Console.WriteLine("Result: {0}", result);
        }
    }
}
