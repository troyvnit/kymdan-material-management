namespace KMM.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private KMMEntities _dataContext;
        public KMMEntities Get()
        {
            return _dataContext ?? (_dataContext = new KMMEntities());
        }
        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}
