using System.Runtime.InteropServices;
using Cake.Core;
using Cake.Core.IO;
using Cake.Testing;
using Cake.Unity.SeekersOfEditors;

namespace Cake.Unity.CSharp.Tests;

public class OSXSeekerOfEditorsTests
{
    [Test]
    public void Seek_should_not_fail_on_real_file_system()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Assert.Inconclusive();
        }

        ICakeEnvironment environment = new FakeEnvironment(PlatformFamily.OSX);
        var fileSystem = new FileSystem();
        var globber = new Globber(fileSystem, environment);
        var log = new FakeLog();

        new OSXSeekerOfEditors(environment, globber, log, fileSystem).Seek();
        Assert.Ignore();
    }
}
