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

using Microsoft.Azure.Management.DataLake.AnalyticsCatalog;
using Microsoft.Azure.Management.DataLake.AnalyticsJob;

namespace Microsoft.Azure.Commands.DataLakeAnalytics.Test.ScenarioTests
{
    using Microsoft.Azure;
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Management.DataLake.Store;
    using Microsoft.Azure.Management.DataLake.Store.Models;
    using Microsoft.Azure.Management.DataLake.Analytics;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using System;
    using System.Net;
    using System.Reflection;

    public abstract class DataLakeAnalyticsTestsBase : TestBase, IDisposable
    {
        internal string resourceGroupName { get; set; }
        internal string dataLakeAnalyticsAccountName { get; set; }
        internal string dataLakeAccountName { get; set; }

        internal const string resourceGroupLocation = "West US";

        private EnvironmentSetupHelper helper;

        private DataLakeAnalyticsManagementClient dataLakeAnalyticsManagementClient;
        private DataLakeAnalyticsJobManagementClient dataLakeAnalyticsJobManagementClient;
        private DataLakeAnalyticsCatalogManagementClient dataLakeAnalyticsCatalogManagementClient;
        private DataLakeStoreManagementClient dataLakeStoreManagementClient;
        private ResourceManagementClient resourceManagementClient;

        protected DataLakeAnalyticsTestsBase()
        {
            helper = new EnvironmentSetupHelper();
            dataLakeAnalyticsManagementClient = GetDataLakeAnalyticsManagementClient();
            dataLakeAnalyticsJobManagementClient = GetDataLakeAnalyticsJobManagementClient();
            dataLakeAnalyticsCatalogManagementClient = GetDataLakeAnalyticsCatalogManagementClient();
            resourceManagementClient = GetResourceManagementClient();
            dataLakeStoreManagementClient = GetDataLakeStoreManagementClient();
            this.resourceGroupName = TestUtilities.GenerateName("abarg1");
            this.dataLakeAnalyticsAccountName = TestUtilities.GenerateName("testaba1");
            this.dataLakeAccountName = TestUtilities.GenerateName("datalake01");
        }

        protected void SetupManagementClients()
        {
            helper.SetupManagementClients(dataLakeAnalyticsManagementClient, dataLakeAnalyticsJobManagementClient,
                dataLakeAnalyticsCatalogManagementClient,
                resourceManagementClient, dataLakeStoreManagementClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));
                SetupManagementClients();

                // Create the resource group
                this.TryRegisterSubscriptionForResource();
                this.TryCreateResourceGroup(this.resourceGroupName, resourceGroupLocation);
                this.TryCreateDataLakeStoreAccount(this.resourceGroupName, this.dataLakeAccountName, resourceGroupLocation);
                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager, "ScenarioTests\\" + this.GetType().Name + ".ps1",
                    helper.RMProfileModule, helper.GetRMModulePath(@"AzureRM.DataLakeAnalytics.psd1"));

                helper.RunPowerShellTest(scripts);
            }
        }

        #region client creation helpers
        protected DataLakeAnalyticsManagementClient GetDataLakeAnalyticsManagementClient()
        {
            return TestBase.GetServiceClient<DataLakeAnalyticsManagementClient>(new CSMTestEnvironmentFactory());
        }

        protected DataLakeAnalyticsJobManagementClient GetDataLakeAnalyticsJobManagementClient()
        {
            return GetDataLakeAnalyticsJobOrCatalogServiceClient<DataLakeAnalyticsJobManagementClient>(new CSMTestEnvironmentFactory());
        }

        protected DataLakeAnalyticsCatalogManagementClient GetDataLakeAnalyticsCatalogManagementClient()
        {
            return GetDataLakeAnalyticsJobOrCatalogServiceClient<DataLakeAnalyticsCatalogManagementClient>(new CSMTestEnvironmentFactory());
        }

        protected DataLakeStoreManagementClient GetDataLakeStoreManagementClient()
        {
            return TestBase.GetServiceClient<DataLakeStoreManagementClient>(new CSMTestEnvironmentFactory());
        }

        protected ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
        }
        #endregion

        #region private helper methods

        /// <summary>
        /// Gets DataLakeAnalytics catalog or job client for the current test environment 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="factory"></param>
        /// <returns></returns>
        private static T GetDataLakeAnalyticsJobOrCatalogServiceClient<T>(
            TestEnvironmentFactory factory)
            where T : class
        {
            TestEnvironment currentEnvironment = factory.GetTestEnvironment();
            T client = null;

            ConstructorInfo constructor = typeof(T).GetConstructor(new Type[] 
                    { 
                        typeof(SubscriptionCloudCredentials), 
                        typeof(string) 
                    });
            client = constructor.Invoke(new object[] 
                    { 
                        currentEnvironment.Credentials as SubscriptionCloudCredentials, 
                        // Have to remove the https:// since this is a suffix
                        currentEnvironment.Endpoints.DataLakeAnalyticsJobAndCatalogServiceUri.OriginalString.Replace("https://","") }) as T;

            return AddMockHandler<T>(ref client);
        }

        private void TryRegisterSubscriptionForResource(string providerName = "Microsoft.DataLakeAnalytics")
        {
            var reg = resourceManagementClient.Providers.Register(providerName);
            ThrowIfTrue(reg == null, "resourceManagementClient.Providers.Register returned null.");
            ThrowIfTrue(reg.StatusCode != HttpStatusCode.OK, string.Format("resourceManagementClient.Providers.Register returned with status code {0}", reg.StatusCode));

            var resultAfterRegister = resourceManagementClient.Providers.Get(providerName);
            ThrowIfTrue(resultAfterRegister == null, "resourceManagementClient.Providers.Get returned null.");
            ThrowIfTrue(string.IsNullOrEmpty(resultAfterRegister.Provider.Id), "Provider.Id is null or empty.");
            ThrowIfTrue(!providerName.Equals(resultAfterRegister.Provider.Namespace), string.Format("Provider name is not equal to {0}.", providerName));
            ThrowIfTrue(ProviderRegistrationState.Registered != resultAfterRegister.Provider.RegistrationState &&
                ProviderRegistrationState.Registering != resultAfterRegister.Provider.RegistrationState,
                string.Format("Provider registration state was not 'Registered' or 'Registering', instead it was '{0}'", resultAfterRegister.Provider.RegistrationState));
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes == null || resultAfterRegister.Provider.ResourceTypes.Count == 0, "Provider.ResourceTypes is empty.");
            ThrowIfTrue(resultAfterRegister.Provider.ResourceTypes[0].Locations == null || resultAfterRegister.Provider.ResourceTypes[0].Locations.Count == 0, "Provider.ResourceTypes[0].Locations is empty.");
        }

        private void TryCreateResourceGroup(string resourceGroupName, string location)
        {
            ResourceGroupCreateOrUpdateResult result = resourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = location });
            var newlyCreatedGroup = resourceManagementClient.ResourceGroups.Get(resourceGroupName);
            ThrowIfTrue(newlyCreatedGroup == null, "resourceManagementClient.ResourceGroups.Get returned null.");
            ThrowIfTrue(!resourceGroupName.Equals(newlyCreatedGroup.ResourceGroup.Name), string.Format("resourceGroupName is not equal to {0}", resourceGroupName));
        }

        private string TryCreateDataLakeStoreAccount(string resourceGroupName, string dataLakeAccountName, string location)
        {
            var dataLakeCreateParameters = new DataLakeStoreAccountCreateOrUpdateParameters
            {
                DataLakeStoreAccount = new DataLakeStoreAccount
                {
                    Location = location,
                    Name = dataLakeAccountName
                }
            };

            var createResponse = dataLakeStoreManagementClient.DataLakeStoreAccount.Create(resourceGroupName, dataLakeCreateParameters);
            ThrowIfTrue(createResponse.Status != OperationStatus.Succeeded, string.Format("Failed to provision a DataLake Store account in the success state. Actual State: {0}", createResponse.Status));
            var dataLakeAccountSuffix = dataLakeStoreManagementClient.DataLakeStoreAccount.Get(resourceGroupName, dataLakeAccountName).DataLakeStoreAccount.Properties.Endpoint.Replace(dataLakeAccountName + ".", "");
            ThrowIfTrue(string.IsNullOrEmpty(dataLakeAccountSuffix), "dataLakeStoreManagementClient.DataLakeStoreAccount.Create did not properly populate the suffix property");
            return dataLakeAccountSuffix;

        }

        private void ThrowIfTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }
        #endregion
        public void Dispose()
        {
        }
    }
}
