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

using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Resources.Models.ActiveDirectory;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;
using System;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.Resources
{
    /// <summary>
    /// Deletes a given role definition.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmRoleDefinition"), OutputType(typeof(bool))]
    public class RemoveAzureRoleDefinitionCommand : ResourcesBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleDefinitionId,
            HelpMessage = "Role definition id")]
        [ValidateGuidNotEmpty]
        public Guid Id { get; set; }

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.RoleDefinitionName,
            HelpMessage = "Role definition name. For e.g. Reader, Contributor, Virtual Machine Contributor.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            PSRoleDefinition roleDefinition = null;
            Action action = null;
            string confirmMessage = null;

            if(Id != Guid.Empty)
            {
                action = (() => roleDefinition = PoliciesClient.RemoveRoleDefinition(Id, DefaultProfile.Context.Subscription.Id.ToString()));
                confirmMessage = string.Format(ProjectResources.RemoveRoleDefinition, Id);
            }
            else
            {
                action = (() => roleDefinition = PoliciesClient.RemoveRoleDefinition(Name, DefaultProfile.Context.Subscription.Id.ToString()));
                confirmMessage = string.Format(ProjectResources.RemoveRoleDefinitionWithName, Name);
            }

            ConfirmAction(
                Force.IsPresent,
                confirmMessage,
                ProjectResources.RemoveRoleDefinition,
                Id.ToString(),
                action);

            if (PassThru)
            {
                WriteObject(roleDefinition);
            }
        }
    }
}
