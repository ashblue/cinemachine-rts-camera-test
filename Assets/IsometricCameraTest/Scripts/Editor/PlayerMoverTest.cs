using NUnit.Framework;
using UnityEngine;

namespace CleverCrow.IsometricCameras.Editor {
    public class PlayerMoverTest {
        private PlayerMover _mover;

        [SetUp]
        public void BeforeEach () {
            var go = new GameObject();
            _mover = go.AddComponent<PlayerMover>();
            _mover.moveQueue.Add(new GameObject().transform);
        }

        [TearDown]
        public void AfterEach () {
            _mover.moveQueue.ForEach(m => Object.DestroyImmediate(m.gameObject));
            Object.DestroyImmediate(_mover.gameObject);
        }
        
        public class GetNextIndexMethod : PlayerMoverTest {
            [Test]
            public void It_should_return_zero_by_default () {
                Assert.AreEqual(0, _mover.GetNextIndex());
            }
            
            [Test]
            public void It_should_return_one_on_second_call () {
                _mover.moveQueue.Add(new GameObject().transform);
                _mover.GetNextIndex();
                
                Assert.AreEqual(1, _mover.GetNextIndex());
            }
            
            [Test]
            public void It_should_return_two_on_third_call () {
                _mover.moveQueue.Add(new GameObject().transform);
                _mover.moveQueue.Add(new GameObject().transform);
                _mover.GetNextIndex();
                _mover.GetNextIndex();

                Assert.AreEqual(2, _mover.GetNextIndex());
            }
                        
            [Test]
            public void It_should_reset_to_zero_when_exceeding_the_array_length () {
                _mover.moveQueue.Add(new GameObject().transform);
                _mover.GetNextIndex();
                _mover.GetNextIndex();

                Assert.AreEqual(0, _mover.GetNextIndex());
            }
        }
    }
}