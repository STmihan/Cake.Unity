using Cake.Unity.Version;

namespace Cake.Unity.CSharp.Tests;

public class UnityVersionTests
{
    [Test]
    public void Unity_version_with_suffix_a_should_have_stage_alpha()
    {
        var version = new UnityVersion(2019, 1, 0, 'a', 9);
        Assert.That(version.Stage, Is.EqualTo(UnityReleaseStage.Alpha));
    }

    [Test]
    public void Unity_version_with_suffix_b_should_have_stage_beta()
    {
        var version = new UnityVersion(2018, 3, 0, 'b', 2);
        Assert.That(version.Stage, Is.EqualTo(UnityReleaseStage.Beta));
    }

    [Test]
    public void Unity_version_with_suffix_p_should_have_stage_patch()
    {
        var version = new UnityVersion(2018, 2, 2, 'p', 1);
        Assert.That(version.Stage, Is.EqualTo(UnityReleaseStage.Patch));
    }

    [Test]
    public void Unity_version_with_suffix_f_should_have_stage_final()
    {
        var version = new UnityVersion(2018, 2, 20, 'f', 1);
        Assert.That(version.Stage, Is.EqualTo(UnityReleaseStage.Final));
    }

    [Test]
    public void Unity_version_with_unknown_suffix_should_have_stage_unknown()
    {
        var version = new UnityVersion(2022, 2, 2, 'x', 2);
        Assert.That(version.Stage, Is.EqualTo(UnityReleaseStage.Unknown));
    }

    [Test]
    public void Unity_version_without_suffix_should_have_stage_unknown()
    {
        var version = new UnityVersion(2022, 2, 2);
        Assert.That(version.Stage, Is.EqualTo(UnityReleaseStage.Unknown));
    }

    [Test]
    public void Parse_Unity_version_from_string()
    {
        var str = "2017.4.25f1";

        var unityVersion = UnityVersion.Parse(str);

        Assert.That(unityVersion.Year, Is.EqualTo(2017));
        Assert.That(unityVersion.Stream, Is.EqualTo(4));
        Assert.That(unityVersion.Update, Is.EqualTo(25));
        Assert.That(unityVersion.SuffixCharacter, Is.EqualTo('f'));
        Assert.That(unityVersion.SuffixNumber, Is.EqualTo(1));
    }
}
