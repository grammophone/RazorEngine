using System;
using RazorEngine;
using RazorEngine.Templating;

namespace RazorEngine.NetCore.ConsoleTest
{
    public class UserQueryCondition
    {
        public string UserName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Author: Zuliang Liu(China)
            // https://github.com/liuzuliang/RazorEngine
            // Fork From https://github.com/fouadmess/RazorEngine, 
            // But Fixed Bug that Razor string does not support @using and @inherits, etc.

            //@inherits RazorEngine.Templating.TemplateBase<UserQueryCondition>
            string template = @"
        @using RazorEngine.NetCore.ConsoleTest
        @inherits RazorEngine.Templating.TemplateBase<dynamic>
        @{
            const string name = ""Admin"";
        }
        @functions
        {
            private int Age = 18;

            public string GetUserName(string name)
            {
                return ""Greate "" + name + "" "" + Age;
            }
            public string GetCurrentTime()
            {
                return DateTime.Now.ToString(""yyyy-MM-dd HH:mm:ss"");
            }
        }
        Hello @Model.UserName, welcome to RazorEngine! @GetUserName(name) , Current Time: @GetCurrentTime()
    ";
var result = Engine.Razor.RunCompile(template, "templateKey", null, new UserQueryCondition
{
    UserName = "World, perfect !"
});
Console.WriteLine("Template: {0}{0}\t{1}{0}{0}", Environment.NewLine, template);
Console.WriteLine("Result: {0}{0}\t{1}", Environment.NewLine, result);
        }
    }
}
