using euanon.Model;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace euanon.Services
{
    public class Azure
    {
        private IMobileServiceClient _client;
        private IMobileServiceSyncTable<Post> _table;
        const string dbPath = "postDb";
        private const string serviceUri = "http://euanonimotables.azurewebsites.net";

        public Azure()
        {
            _client = new MobileServiceClient(serviceUri);
            var store = new MobileServiceSQLiteStore(dbPath);
            store.DefineTable<Post>();
            _client.SyncContext.InitializeAsync(store);
            _table = _client.GetSyncTable<Post>();
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var empty = new Post[0];
            try
            {
                if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                    await SyncAsync();

                return await _table.ToEnumerableAsync();
            }
            catch (Exception ex)
            {
                return empty;
            }
        }
        
        public async void AddPost(Post post)
        {
            if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                await _table.InsertAsync(post);
                await SyncAsync();
            }
            else
            {
                await _table.InsertAsync(post);
            }
        }

        public async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;
            try
            {
                await _client.SyncContext.PushAsync();

                await _table.PullAsync("allPosts", _table.CreateQuery());
            }
            catch (MobileServicePushFailedException pushEx)
            {
                if (pushEx.PushResult != null)
                    syncErrors = pushEx.PushResult.Errors;
            }
        }


        public async Task CleanData()
        {
            await _table.PurgeAsync("allPosts", _table.CreateQuery(), new System.Threading.CancellationToken());
        }
    }
}
