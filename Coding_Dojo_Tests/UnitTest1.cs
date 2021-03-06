using CodingDojo;
using NUnit.Framework;

namespace Coding_Dojo_Tests
{
    public class SibalaTests
    {
        private SibalaGame _game;

        [SetUp]
        public void SetUp()
        {
            _game = new SibalaGame();
        }

        [Test]
        public void all_the_same_kind_Amy_win()
        {
            var gameResult = _game.Play("Amy:6 6 6 6  Lin:2 2 2 2");
            Assert.AreEqual("Amy wins.all the same kind:6", gameResult);
        }

        [Test]
        public void all_the_same_kind_Lin_win()
        {
            var gameResult = _game.Play("Amy:1 1 1 1  Lin:2 2 2 2");
            Assert.AreEqual("Lin wins.all the same kind:2", gameResult);
        }

        [Test]
        public void all_the_same_kind_tie()
        {
            var gameResult = _game.Play("Amy:2 2 2 2  Lin:2 2 2 2");
            Assert.AreEqual("Tie.", gameResult);
        }

        [Test]
        public void all_the_same_kind_and_no_points()
        {
            var gameResult = _game.Play("Amy:5 2 3 4  Lin:2 2 2 2");
            Assert.AreEqual("Lin wins.all the same kind:2", gameResult);
        }

        [Test]
        public void normal_points_and_no_points_4()
        {
            var gameResult = _game.Play("Amy:4 4 1 3  Lin:1 2 3 4");
            Assert.AreEqual("Amy wins.normal point:4", gameResult);
        }

        [Test]
        public void normal_points_and_no_points_2()
        {
            var gameResult = _game.Play("Amy:2 2 1 3  Lin:1 2 3 4");
            Assert.AreEqual("Amy wins.normal point:4", gameResult);
        }

        [Test]
        public void normal_points_and_no_points_6()
        {
            var gameResult = _game.Play("Amy:3 3 6 6  Lin:1 2 3 4");
            Assert.AreEqual("Amy wins.normal point:12", gameResult);
        }
    }
}