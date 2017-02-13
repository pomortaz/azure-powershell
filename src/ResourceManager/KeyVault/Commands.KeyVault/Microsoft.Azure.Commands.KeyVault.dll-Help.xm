<?xml version="1.0" encoding="utf-8"?>
<helpItems schema="maml">

<command:command xmlns:maml="http://schemas.microsoft.com/maml/2004/10" xmlns:command="http://schemas.microsoft.com/maml/dev/command/2004/10" xmlns:dev="http://schemas.microsoft.com/maml/dev/2004/10" xmlns:MSHelp="http://msdn.microsoft.com/mshelp">
<command:details><command:name>Remove-AzureKeyVaultKey</command:name>
<command:verb>Remove</command:verb>
<command:noun>AzureKeyVaultKey</command:noun>
<maml:description><maml:para>Deletes a key in a key vault.
</maml:para>
</maml:description>
</command:details>
<maml:description><maml:para>The Remove-AzureKeyVaultKey cmdlet deletes a key in a key vault. If the key was accidentally deleted the key can be recovered using Undo-AzureKeyVaultKeyRemoval by a user with special 'recover' permissions. This cmdlet has a value of high for the ConfirmImpact property.
</maml:para>
</maml:description>
<command:syntax><command:syntaxItem><maml:name>Remove-AzureKeyVaultKey</maml:name>
<command:parameter required="true" variableLength="true" globbing="false" pipelineInput="True (ByPropertyName)" position="1" aliases="none"><maml:name>VaultName</maml:name>
<maml:Description><maml:para>Specifies the name of the key vault from which to remove the key. This cmdlet constructs the FQDN of a key vault based on the name that this parameter specifies and your current environment.
</maml:para>
</maml:Description>
<command:parameterValue required="true" variableLength="false">String</command:parameterValue>
<dev:type><maml:name>String</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>None</dev:defaultValue>
</command:parameter>
<command:parameter required="true" variableLength="true" globbing="false" pipelineInput="True (ByPropertyName)" position="2" aliases="KeyName"><maml:name>Name</maml:name>
<maml:Description><maml:para>Specifies the name of the key to remove. This cmdlet constructs the fully qualified domain name (FQDN) of a key based on the name that this parameter specifies, the name of the key vault, and your current environment.
</maml:para>
</maml:Description>
<command:parameterValue required="true" variableLength="false">String</command:parameterValue>
<dev:type><maml:name>String</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>None</dev:defaultValue>
</command:parameter>
<command:parameter required="false" variableLength="true" globbing="false" pipelineInput="False" position="named" aliases="none"><maml:name>Force</maml:name>
<maml:Description><maml:para>Forces the command to run without asking for user confirmation.
</maml:para>
</maml:Description>
<dev:type><maml:name>SwitchParameter</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>False</dev:defaultValue>
</command:parameter>
<command:parameter required="false" variableLength="true" globbing="false" pipelineInput="False" position="named" aliases="none"><maml:name>InRemovedState</maml:name>
<maml:Description><maml:para>Remove the previously deleted key permanently.
</maml:para>
</maml:Description>
<dev:type><maml:name>SwitchParameter</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>False</dev:defaultValue>
</command:parameter>
<command:parameter required="false" variableLength="true" globbing="false" pipelineInput="False" position="named" aliases="none"><maml:name>PassThru</maml:name>
<maml:Description><maml:para>Indicates that this cmdlet returns a Microsoft.Azure.Commands.KeyVault.Models.KeyBundle object. By default, this cmdlet does not generate any output.
</maml:para>
</maml:Description>
<dev:type><maml:name>SwitchParameter</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>False</dev:defaultValue>
</command:parameter>
<command:parameter required="false" variableLength="true" globbing="false" pipelineInput="False" position="named" aliases="cf"><maml:name>Confirm</maml:name>
<maml:Description><maml:para>Prompts you for confirmation before running the cmdlet.
</maml:para>
</maml:Description>
<dev:type><maml:name>SwitchParameter</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>False</dev:defaultValue>
</command:parameter>
<command:parameter required="false" variableLength="true" globbing="false" pipelineInput="False" position="named" aliases="wi"><maml:name>WhatIf</maml:name>
<maml:Description><maml:para>Shows what would happen if the cmdlet runs. The cmdlet is not run.Shows what would happen if the cmdlet runs. The cmdlet is not run.
</maml:para>
</maml:Description>
<dev:type><maml:name>SwitchParameter</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>False</dev:defaultValue>
</command:parameter>
</command:syntaxItem>
</command:syntax>
<command:parameters><command:parameter required="false" variableLength="true" globbing="false" pipelineInput="False" position="named" aliases="none"><maml:name>Force</maml:name>
<maml:Description><maml:para>Forces the command to run without asking for user confirmation.
</maml:para>
</maml:Description>
<command:parameterValue required="false" variableLength="false">SwitchParameter</command:parameterValue>
<dev:type><maml:name>SwitchParameter</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>False</dev:defaultValue>
</command:parameter>
<command:parameter required="false" variableLength="true" globbing="false" pipelineInput="False" position="named" aliases="none"><maml:name>InRemovedState</maml:name>
<maml:Description><maml:para>Remove the previously deleted key permanently.
</maml:para>
</maml:Description>
<command:parameterValue required="false" variableLength="false">SwitchParameter</command:parameterValue>
<dev:type><maml:name>SwitchParameter</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>False</dev:defaultValue>
</command:parameter>
<command:parameter required="true" variableLength="true" globbing="false" pipelineInput="True (ByPropertyName)" position="2" aliases="KeyName"><maml:name>Name</maml:name>
<maml:Description><maml:para>Specifies the name of the key to remove. This cmdlet constructs the fully qualified domain name (FQDN) of a key based on the name that this parameter specifies, the name of the key vault, and your current environment.
</maml:para>
</maml:Description>
<command:parameterValue required="true" variableLength="false">String</command:parameterValue>
<dev:type><maml:name>String</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>None</dev:defaultValue>
</command:parameter>
<command:parameter required="false" variableLength="true" globbing="false" pipelineInput="False" position="named" aliases="none"><maml:name>PassThru</maml:name>
<maml:Description><maml:para>Indicates that this cmdlet returns a Microsoft.Azure.Commands.KeyVault.Models.KeyBundle object. By default, this cmdlet does not generate any output.
</maml:para>
</maml:Description>
<command:parameterValue required="false" variableLength="false">SwitchParameter</command:parameterValue>
<dev:type><maml:name>SwitchParameter</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>False</dev:defaultValue>
</command:parameter>
<command:parameter required="true" variableLength="true" globbing="false" pipelineInput="True (ByPropertyName)" position="1" aliases="none"><maml:name>VaultName</maml:name>
<maml:Description><maml:para>Specifies the name of the key vault from which to remove the key. This cmdlet constructs the FQDN of a key vault based on the name that this parameter specifies and your current environment.
</maml:para>
</maml:Description>
<command:parameterValue required="true" variableLength="false">String</command:parameterValue>
<dev:type><maml:name>String</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>None</dev:defaultValue>
</command:parameter>
<command:parameter required="false" variableLength="true" globbing="false" pipelineInput="False" position="named" aliases="cf"><maml:name>Confirm</maml:name>
<maml:Description><maml:para>Prompts you for confirmation before running the cmdlet.
</maml:para>
</maml:Description>
<command:parameterValue required="false" variableLength="false">SwitchParameter</command:parameterValue>
<dev:type><maml:name>SwitchParameter</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>False</dev:defaultValue>
</command:parameter>
<command:parameter required="false" variableLength="true" globbing="false" pipelineInput="False" position="named" aliases="wi"><maml:name>WhatIf</maml:name>
<maml:Description><maml:para>Shows what would happen if the cmdlet runs. The cmdlet is not run.Shows what would happen if the cmdlet runs. The cmdlet is not run.
</maml:para>
</maml:Description>
<command:parameterValue required="false" variableLength="false">SwitchParameter</command:parameterValue>
<dev:type><maml:name>SwitchParameter</maml:name>
<maml:uri /></dev:type>
<dev:defaultValue>False</dev:defaultValue>
</command:parameter>
</command:parameters>
<command:inputTypes><command:inputType><dev:type><maml:name>String</maml:name>
</dev:type>
<maml:description><maml:para>
</maml:para>
</maml:description>
</command:inputType>
</command:inputTypes>
<command:returnValues><command:returnValue><dev:type><maml:name>Microsoft.Azure.Commands.KeyVault.Models.DeletedKeyBundle</maml:name>
</dev:type>
<maml:description><maml:para>This cmdlet returns a value only if you specify the PassThru parameter.
</maml:para>
</maml:description>
</command:returnValue>
</command:returnValues>
<maml:alertSet><maml:alert><maml:para>
</maml:para>
</maml:alert>
</maml:alertSet>
<command:examples><command:example><maml:title>Example 1: Remove a key from a key vault</maml:title>
<dev:code>PS C:\&gt;Remove-AzureKeyVaultKey -VaultName 'Contoso' -Name 'ITSoftware'</dev:code>
<dev:remarks><maml:para>This command removes the key named ITSoftware from the key vault named Contoso.
</maml:para>
</dev:remarks>
</command:example>
<command:example><maml:title>Example 2: Remove a key without user confirmation</maml:title>
<dev:code>PS C:\&gt;Remove-AzureKeyVaultKey -VaultName 'Contoso' -Name 'ITSoftware' -Force -Confirm:$False</dev:code>
<dev:remarks><maml:para>This command removes the key named ITSoftware from the key vault named Contoso. The command specifies the Force and Confirm parameters, and, therefore, the cmdlet does not prompt you for confirmation.
</maml:para>
</dev:remarks>
</command:example>
<command:example><maml:title>Example 3: Purge a deleted key from the key vault permanently</maml:title>
<dev:code>PS C:\&gt;Remove-AzureKeyVaultKey -VaultName 'Contoso' -Name 'ITSoftware' -InRemovedState</dev:code>
<dev:remarks><maml:para>This command removes the key named ITSoftware from the key vault named Contoso permanently. This flag requires the user to have special 'purge' persmissions on the key vault.
</maml:para>
</dev:remarks>
</command:example>
<command:example><maml:title>Example 4: Remove keys by using the pipeline operator</maml:title>
<dev:code>PS C:\&gt;Get-AzureKeyVaultKey -VaultName 'Contoso' | Where-Object {$_.Attributes.Enabled -eq $False} | Remove-AzureKeyVaultKey</dev:code>
<dev:remarks><maml:para>This command gets all the keys in the key vault named Contoso, and passes them to the Where-Object cmdlet by using the pipeline operator. That cmdlet passes the keys that have a value of $False for the Enabled attribute to the current cmdlet. That cmdlet removes those keys.
</maml:para>
</dev:remarks>
</command:example>
</command:examples>
<command:relatedLinks><maml:navigationLink><maml:linkText>Online Version:</maml:linkText>
<maml:uri>http://go.microsoft.com/fwlink/?LinkId=690299</maml:uri>
</maml:navigationLink>
<maml:navigationLink><maml:linkText>Add-AzureKeyVaultKey</maml:linkText>
<maml:uri></maml:uri>
</maml:navigationLink>
<maml:navigationLink><maml:linkText>Get-AzureKeyVaultKey</maml:linkText>
<maml:uri></maml:uri>
</maml:navigationLink>
<maml:navigationLink><maml:linkText>Set-AzureKeyVaultKeyAttribute</maml:linkText>
<maml:uri></maml:uri>
</maml:navigationLink>
<maml:navigationLink><maml:linkText>Undo-AzureKeyVaultKeyRemoval</maml:linkText>
<maml:uri></maml:uri>
</maml:navigationLink>
</command:relatedLinks>
</command:command>
</helpItems>
