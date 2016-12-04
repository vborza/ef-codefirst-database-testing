using System;

namespace Dal.Tests.Setup
{
    public class TestDbFixture : IDisposable
    {
        public TestDbFixture()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);

            using (var context = new DatabaseContext())
            {
                if (context.Database.Exists())
                {
                    context.Database.Delete();
                }

                context.Database.Create();
            }
        }

        public void Dispose()
        {
            using (var context = new DatabaseContext())
            {
                context.Database.Delete();
            }
        }
    }
}
