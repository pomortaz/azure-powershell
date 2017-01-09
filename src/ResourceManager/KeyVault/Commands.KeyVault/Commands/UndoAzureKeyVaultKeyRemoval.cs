using Microsoft.Azure.Commands.KeyVault.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet(VerbsCommon.Undo, "AzureKeyVaultKeyRemoval",
    SupportsShouldProcess = true,
    HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(KeyBundle))]
    public class UndoAzureKeyVaultKeyRemoval : KeyVaultCmdletBase
    {
        #region Input Parameter Definitions

        /// <summary>
        /// Vault name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Vault name. Cmdlet constructs the FQDN of a vault based on the name and currently selected environment.")]
        [ValidateNotNullOrEmpty]
        public string VaultName { get; set; }

        /// <summary>
        /// Secret name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Key name. Cmdlet constructs the FQDN of a key from vault name, currently selected environment and key name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.KeyName)]
        public string Name { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.RecoverKey))
            {
                KeyBundle recoveredKey = DataServiceClient.RecoverKey(VaultName, Name);

                WriteObject(recoveredKey);
            }
        }
    }
}
