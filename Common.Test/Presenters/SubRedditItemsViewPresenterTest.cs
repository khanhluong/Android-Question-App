using System;
using Common.IViews;
using Common.Model;
using Common.Presenters;
using Moq;
using NUnit.Framework;

namespace Common.Test.Presenters
{
    [TestFixture]
    public class SubRedditItemsViewPresenterTest
    {

        Mock<SubRedditResponse> mockModel;

        Mock<ISubRedditItemsView> mockView;

        private SubRedditItemsViewPresenter presenter;


        [SetUp]
        public void BeforeEachTest()
        {
            mockModel = new Mock<SubRedditResponse>();
            presenter = new SubRedditItemsViewPresenter((ISubRedditItemsView)mockView);
        }

        [Test]
        public void Constructor_NotNullElements_Success()
        {
            presenter.LoadSubRedditItem2Async("sample");
        }
    }
}
