using CodingDojo;
using NUnit.Framework;

namespace Coding_Dojo_Tests
{
    public class SibalaGameTests
    {
        [Test]
        public void when_all_the_same_kind_then_winner_is_Lin()
        {
            var sibalaGame = new SibalaGame();
            var winnerResult = sibalaGame.Play("Amy:1 1 1 1  Lin:4 4 4 4");
            Assert.AreEqual("Lin wins. all the same kind:4", winnerResult);
        }

        [Test]
        public void when_all_the_same_kind_then_winner_is_amy()
        {
            var sibalaGame = new SibalaGame();
            var winnerResult = sibalaGame.Play("Amy:3 3 3 3  Lin:2 2 2 2");
            Assert.AreEqual("Amy wins. all the same kind:3", winnerResult);
        }

        [Test]
        public void when_all_the_same_kind_and_tie()
        {
            var sibalaGame = new SibalaGame();
            var winnerResult = sibalaGame.Play("Amy:1 1 1 1  Lin:1 1 1 1");
            Assert.AreEqual("Tie.", winnerResult);
        }


        [Test]
        public void when_all_the_same_kind_and_no_point()
        {
            var sibalaGame = new SibalaGame();
            var winnerResult = sibalaGame.Play("Amy:1 1 1 1  Lin:4 3 2 1");
            Assert.AreEqual("Amy wins. all the same kind:1", winnerResult);
        }
    }
}