using System;
using System.Collections.Generic;
using tattlr.core;
using tattlr.core.Models;
using tattlr.data.Azure;

namespace tattlr.data.Repositories
{
    public class AzureImageRepository : IStore<ReportImage, int>
    {
        private readonly AzureBlobStorageContext _storage;

        public AzureImageRepository(AzureBlobStorageContext storage)
        {
            _storage = storage;
        }
        #region IStore<Image> Members

        public ReportImage Save(ReportImage entity)
        {                       
            var blob = _storage.Add(entity.ByteArray, entity.Name);
            entity.Uri = blob.Uri.AbsoluteUri;
            return entity;
        }

        public ReportImage Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportImage> GetAll()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
