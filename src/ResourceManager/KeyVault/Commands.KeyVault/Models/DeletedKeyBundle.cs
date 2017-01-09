using System;
using System.Linq;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class DeletedKeyBundle : KeyBundle
    {
        public DeletedKeyBundle()
        { }

        internal DeletedKeyBundle(Azure.KeyVault.Models.DeletedKeyBundle deletedKeyBundle, VaultUriHelper vaultUriHelper) : base(deletedKeyBundle, vaultUriHelper)
        {
            ScheduledPurgeDate = deletedKeyBundle.ScheduledPurgeDate;
            DeletedDate = deletedKeyBundle.DeletedDate;
        }

        public DateTime? ScheduledPurgeDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
