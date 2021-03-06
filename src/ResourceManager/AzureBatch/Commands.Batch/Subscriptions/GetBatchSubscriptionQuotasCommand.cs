﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Batch.Models;
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.Get, Constants.AzureRmBatchSubscriptionQuotas), OutputType(typeof(PSBatchSubscriptionQuotas))]
    public class GetBatchSubscriptionQuotasCommand : BatchCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, 
            HelpMessage = "The region to get the quotas of the subscription in the Batch Service from.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        protected override void ProcessRecord()
        {
            PSBatchSubscriptionQuotas quotas = BatchClient.GetSubscriptionQuotas(this.Location);
            WriteObject(quotas);
        }
    }
}
