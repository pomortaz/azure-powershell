using System;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class DeletedSecretIdentityItem : SecretIdentityItem
    {
        internal DeletedSecretIdentityItem(Azure.KeyVault.Models.DeletedSecretItem secretItem, VaultUriHelper vaultUriHelper) : base(secretItem, vaultUriHelper)
        {
            ScheduledPurgeDate = secretItem.ScheduledPurgeDate;
            DeletedDate = secretItem.DeletedDate;
        }

        internal DeletedSecretIdentityItem(DeletedSecret secret) : base(secret)
        {
            ScheduledPurgeDate = secret.ScheduledPurgeDate;
            DeletedDate = secret.DeletedDate;
        }

        public DateTime? ScheduledPurgeDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
