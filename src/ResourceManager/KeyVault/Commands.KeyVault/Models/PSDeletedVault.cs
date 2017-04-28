// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Management.KeyVault.Models;
using System;
using System.Collections;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSDeletedVault
    {
        internal PSDeletedVault(DeletedVault vault)
        {
            Id = vault.Id;
            VaultName = vault.Name;
            ResourceId = vault.Properties.VaultId;
            DeletedVaultLocation = vault.Properties.Location;
            DeletionDate = vault.Properties.DeletionDate;
            ScheduledPurgeDate = vault.Properties.ScheduledPurgeDate;
            Tags = vault.Properties.Tags?.ConvertToHashtable();
        }

        public string DeletedVaultLocation { get; private set; }

        public string ResourceId { get; protected set; }

        public string VaultName { get; protected set; }

        public string Id { get; private set; }

        public DateTime? DeletionDate { get; private set; }

        public DateTime? ScheduledPurgeDate { get; private set; }

        public Hashtable Tags { get; protected set; }

        public string TagsTable
        {
            get { return ResourcesExtensions.ConstructTagsTable(Tags); }
        }
    }
}