using Microsoft.Azure.Management.KeyVault.Models;
using System;
using System.Collections;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSDeletedVault
    {
        
        public PSDeletedVault(DeletedVault vault)
        {
            Id = vault.Id;
            VaultName = vault.Name;
            VaultId = vault.Properties.VaultId;
            Location = vault.Properties.Location;
            DeletionDate = vault.Properties.DeletionDate;
            ScheduledPurgeDate = vault.Properties.ScheduledPurgeDate;
            Tags = vault.Properties.Tags?.ConvertToHashtable();
        }
        public string Id { get; private set; }

        public string VaultName { get; private set; }

        public string VaultId { get; private set; }

        public string Location { get; private set; }

        public DateTime? DeletionDate { get; private set; }

        public DateTime? ScheduledPurgeDate { get; private set; }

        public Hashtable Tags { get; set; }
    }
}