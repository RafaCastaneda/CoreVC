using System;
using System.Management.Automation;

namespace CoreVC.PSClient.Commands
{
    using Api;
    using Api.Rest;

    [Cmdlet(VerbsCommon.Show, "Version")]
    public class GetVersionCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Uri Url { get; set; }

        protected override void ProcessRecord()
        {
            var restClient = new RestClient();
            var version = restClient.Request<Version>(Url).Result;

            var sysVersion = new System.Version(version.Major, version.Minor, version.Build);
            WriteObject(version);
        }
    }
}
