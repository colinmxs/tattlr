﻿using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;

namespace tattlr.data.Azure
{
    public class AzureBlobStorageContext
    {
        private readonly CloudStorageAccount _account;
        private readonly CloudBlobClient _client;
        public readonly CloudBlobContainer _container;

        public AzureBlobStorageContext(string container = "report-images")
        {
            _account = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            _client = _account.CreateCloudBlobClient();
            _container = _client.GetContainerReference(container);
        }

        #region ICrudService<CloudBlockBlob,string> Members

        public IEnumerable<CloudBlockBlob> GetAll()
        {
            return _container.ListBlobs() as IEnumerable<CloudBlockBlob>;
        }

        public CloudBlockBlob Get(string id)
        {
            return _container.GetBlobReferenceFromServer(id) as CloudBlockBlob;
        }

        public CloudBlockBlob Add(byte[] byteArray, string name)
        {
            
            var blob = _container.GetBlockBlobReference(name);
            using (var stream = new MemoryStream(byteArray))
            {
                blob.UploadFromStream(stream);
            }
            return blob;
        }

        public void Update(CloudBlockBlob entity)
        {
            //TODO: Finish this
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            //TODO: Finish this
            throw new NotImplementedException();
        }

        #endregion
    }
}
