using Microsoft.Azure.Commands.KeyVault.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    [Cmdlet(VerbsCommon.Undo, "AzureKeyVaultSecretRemoval",
    SupportsShouldProcess = true,
    HelpUri = Constants.KeyVaultHelpUri)]
    [OutputType(typeof(Secret))]
    public class UndoAzureKeyVaultSecretRemoval : KeyVaultCmdletBase
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
            HelpMessage = "Secret name. Cmdlet constructs the FQDN of a secret from vault name, currently selected environment and secret name.")]
        [ValidateNotNullOrEmpty]
        [Alias(Constants.SecretName)]
        public string Name { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.RecoverSecret))
            {
                Secret secret = DataServiceClient.RecoverSecret(VaultName, Name);

                WriteObject(secret);
            }
        }
    }
}
