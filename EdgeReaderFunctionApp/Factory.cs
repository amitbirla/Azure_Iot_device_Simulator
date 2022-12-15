using System;
using System.Collections.Generic;
using System.Text;

namespace EdgeReaderFunctionApp
{
    
    public static class Factory
    {
        public static StorageService storageService = null;
        public static object obj = new object();

        public static StorageService GetService()
        {
            if (storageService == null)
            {
                lock (obj)
                {
                    if (storageService == null)
                    {
                        storageService = new StorageService();
                    }
                }
            }
            return storageService;
        }
    }
}
