using NUnit.Framework;
using BowlingGameKata;

namespace BowlingGameKataTest
{
    [TestFixture]
    public class GameTest
    {
        private Game _g;

        [Test]
        public void TestGutterGame()
        {
            RollMany(20, 0);

            Assert.That(_g.Score(), Is.EqualTo(0));
        }

        [Test]
        public void TestAllOnes()
        {
            RollMany(20, 1);

            Assert.That(_g.Score(), Is.EqualTo(20));
        }

        [Test]
        public void TestOneSpare()
        {
            RollSpare();
            _g.Roll(3);
            RollMany(17, 0);
            
            Assert.That(_g.Score(), Is.EqualTo(16));
        }

        [Test]
        public void TestOneStrike()
        {
            RollStrike();
            _g.Roll(3);
            _g.Roll(4);
            RollMany(16, 0);
            Assert.That(_g.Score(), Is.EqualTo(24));
        }

        [Test]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.That(_g.Score(), Is.EqualTo(300));
        }

        private void RollStrike()
        {
            _g.Roll(10);
        }

        private void RollSpare()
        {
            _g.Roll(5);
            _g.Roll(5);
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                _g.Roll(pins);
            }
        }

        [SetUp]
        public void TestFixtureSetUp()
        {
            _g = new Game();
        }

        [TearDown]
        public void TestFixtureTearDown()
        {
            _g = null;
        }
    }
}
