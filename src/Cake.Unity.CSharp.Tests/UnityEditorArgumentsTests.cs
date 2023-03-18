using Cake.Core.IO;
using Cake.Unity.Arguments;

namespace Cake.Unity.CSharp.Tests;

public class UnityEditorArgumentsTests
{
    private string CommandLineArguments(UnityEditorArguments arguments)
    {
        ProcessArgumentBuilder builder = new();
        ProcessArgumentBuilder argumentBuilder = arguments.CustomizeCommandLineArguments(builder, null);
        return argumentBuilder.Render();
    }

    [Test]
    public void CLI_arguments_with_enabled_batch_mod_should_contain_batch_mode()
    {
        var arguments = new UnityEditorArguments
        {
            BatchMode = true
        };
        Assert.That(CommandLineArguments(arguments), Does.Contain("-batchmode"));
    }

    [Test]
    public void CLI_arguments_with_custom_argument_age_of_value_18_should_contain_age_18()
    {
        var arguments = new UnityEditorArguments
        {
            SetCustomArguments = args => args.age = 18
        };
        Assert.That(CommandLineArguments(arguments), Does.Contain("--age=18"));
    }

    [Test]
    public void CLI_arguments_with_custom_argument_login_of_value_admin_should_contain()
    {
        var arguments = new UnityEditorArguments
        {
            SetCustomArguments = args => args.login = "admin"
        };
        Assert.That(CommandLineArguments(arguments), Does.Contain("--login=admin"));
    }

    [Test]
    public void CLI_arguments_with_ExecuteMethod_GameBuildRun_should_contain_executeMethod_GameBuildRun()
    {
        var arguments = new UnityEditorArguments
        {
            ExecuteMethod = "Game.Build.Run"
        };
        Assert.That(CommandLineArguments(arguments), Does.Contain("-executeMethod Game.Build.Run"));
    }

    [Test]
    public void Default_BatchMode_value_should_be_true()
    {
        var arguments = new UnityEditorArguments();
        Assert.That(arguments.BatchMode, Is.True);
    }

    [Test]
    public void Default_Quit_value_should_be_true()
    {
        var arguments = new UnityEditorArguments();
        Assert.That(arguments.Quit, Is.True);
    }

    [Test]
    public void CLI_arguments_with_Custom_argument_CustomBuildTarget_of_value_PS5_should_contain_buildTarget_PS5()
    {
        var arguments = new UnityEditorArguments
        {
            CustomBuildTarget = "PS5"
        };
        Assert.That(CommandLineArguments(arguments), Does.Contain("-buildTarget PS5"));
    }

    [Test]
    public void Setting_CustomBuildTarget_and_BuildTarget_should_throw_ArgumentException()
    {
        var arguments = new UnityEditorArguments
        {
            CustomBuildTarget = "PS5",
            BuildTarget = BuildTarget.Android
        };
        Assert.Throws<ArgumentException>(() => CommandLineArguments(arguments));
    }
}
