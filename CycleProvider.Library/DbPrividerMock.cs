using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleProvider.Library
{
    public class DbPrividerMock : IDisposable //Mock klasa w  testach jednostkowych tworzy cośczego nie ma np. buttona
    {
        private string _dbConnection, _name;

        public DbPrividerMock(string name = null)
        {
            _name = name ?? $"Noname {DateTime.Now:hh:mm:ss:ms}";
            _dbConnection = "Open";
        }

        #region Dispose wzorzec
        private bool _disposed = false; //WZORZEC DISPOSE
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (_disposed) return;

            _disposed = true;
            if (!dispose) Console.WriteLine($"Developer didn't invoke Dispose() by {_name}");

            _dbConnection = "Close";
            Console.WriteLine($"Dispose ({_disposed})invoke by GC at {DateTime.Now:mm:ss:ms}. Status bd {_dbConnection}");

            GC.SuppressFinalize(this);
        }

        ~DbPrividerMock()
        {
            if (!_disposed) Dispose(false);
            else throw new ObjectDisposedException("Don't play with GC");
            Console.WriteLine($"Finalize () [destructor] invoke by GC at {DateTime.Now:mm:ss:ms}. Status bd {_dbConnection}");
        }
        #endregion
    }
}
