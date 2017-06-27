using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuDataDb.EF;
using NuDataDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Test
{
    [TestClass]
    public class CGMRemindersnRepoTest : BaseUnitTest<Cgmreminders>
    {
        Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected CGMRemindersRepo repo;

        protected override void SetContextData()
        {
            repo = new CGMRemindersRepo(testCtx);

            var b = new Faker<Cgmreminders>()
                .RuleFor(r => r.ReminderId, f => itrtr32++)
                .RuleFor(r => r.Type, f => f.Lorem.Word())
                .RuleFor(r => r.Enabled, f => f.Random.Bool())
                .RuleFor(r => r.Time, f => f.Lorem.Word())
                .RuleFor(r => r.PumpKeyId, f => f.Random.Uuid())
                .RuleFor(r => r.Date, f => new DateTime(f.Random.Long()));

            var bs = b.Generate(3).OrderBy(o => o.ReminderId).ToList();
            FakeCollection.AddRange(bs);


            testCtx.Cgmreminders.AddRange(bs);
            int added = testCtx.SaveChanges();
        }

        [TestMethod]
        public void GetSingleCGMReminders()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp.ReminderId);

            Assert.AreEqual(fakeApp.ReminderId, single.ReminderId);
            Assert.AreEqual(fakeApp.Type, single.Type);
        }

        public void GetSingleReminderIdNotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void DeleteCGMReminders()
        {
            var currentCnt = testCtx.Cgmreminders.Count();

            var entity = testCtx.Cgmreminders.First();
            repo.Delete(entity.ReminderId);
            repo.Save();

            Assert.IsTrue(testCtx.Cgmreminders.Count() == --currentCnt);
        }

        public void DeleteReminderIdNotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = itrtr32;
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
