using System;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class DeletedKeyIdentityItem : KeyIdentityItem
    {
        internal DeletedKeyIdentityItem(Azure.KeyVault.Models.DeletedKeyItem keyItem, VaultUriHelper vaultUriHelper) : base(keyItem, vaultUriHelper)
        {
            ScheduledPurgeDate = keyItem.ScheduledPurgeDate;
            DeletedDate = keyItem.DeletedDate;
        }

        internal DeletedKeyIdentityItem(DeletedKeyBundle keyBundle) : base(keyBundle)
        {
            ScheduledPurgeDate = keyBundle.ScheduledPurgeDate;
            DeletedDate = keyBundle.DeletedDate;
        }

        public DateTime? ScheduledPurgeDate { get; set; }

        public DateTime? DeletedDate { get; set; }

    }
}
