using LiteDB;
using Microsoft.Extensions.Options;
using System;

namespace FileUpload.Dal
{
    public class LiteDbContext
    {
        public readonly LiteDatabase Context;
        public LiteDbContext(IOptions<LiteDbConfig> configs)
        {
            try
            {
                LiteDatabase db = new LiteDatabase(configs.Value.DatabasePath);
                if (db != null)
                {
                    Context = db;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }
    }
}
