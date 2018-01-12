using System;
using System.Management.Automation;

namespace CoreVC.PSClient.Commands
{
    [Cmdlet(VerbsCommon.Show, "Version")]
    public class GetVersionCommand : Cmdlet
    {
        protected override void ProcessRecord()
        {
            var version = new Version(0, 1, 1);
            WriteObject(version.ToString());
        }
    }
}
