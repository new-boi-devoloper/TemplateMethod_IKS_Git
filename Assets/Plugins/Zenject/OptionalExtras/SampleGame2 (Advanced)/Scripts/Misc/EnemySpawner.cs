using System;
using ModestTree;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Zenject.SpaceFighter
{
    public class EnemySpawner : ITickable, IInitializable
    {
        private readonly EnemyFacade.Factory _enemyFactory;
        private readonly LevelBoundary _levelBoundary;
        private readonly Settings _settings;
        private readonly SignalBus _signalBus;

        private float _desiredNumEnemies;
        private int _enemyCount;
        private float _lastSpawnTime;

        public EnemySpawner(
            Settings settings,
            LevelBoundary levelBoundary,
            SignalBus signalBus,
            EnemyFacade.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _signalBus = signalBus;
            _levelBoundary = levelBoundary;
            _settings = settings;

            _desiredNumEnemies = settings.NumEnemiesStartAmount;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<EnemyKilledSignal>(OnEnemyKilled);
        }

        public void Tick()
        {
            _desiredNumEnemies += _settings.NumEnemiesIncreaseRate * Time.deltaTime;

            if (_enemyCount < (int)_desiredNumEnemies
                && Time.realtimeSinceStartup - _lastSpawnTime > _settings.MinDelayBetweenSpawns)
            {
                SpawnEnemy();
                _enemyCount++;
            }
        }

        private void OnEnemyKilled()
        {
            _enemyCount--;
        }

        private void SpawnEnemy()
        {
            var speed = Random.Range(_settings.SpeedMin, _settings.SpeedMax);
            var accuracy = Random.Range(_settings.AccuracyMin, _settings.AccuracyMax);

            var enemyFacade = _enemyFactory.Create(accuracy, speed);
            enemyFacade.Position = ChooseRandomStartPosition();

            _lastSpawnTime = Time.realtimeSinceStartup;
        }

        private Vector3 ChooseRandomStartPosition()
        {
            var side = Random.Range(0, 3);
            var posOnSide = Random.Range(0, 1.0f);

            var buffer = 2.0f;

            switch (side)
            {
                case 0:
                    // top
                {
                    return new Vector3(
                        _levelBoundary.Left + posOnSide * _levelBoundary.Width,
                        _levelBoundary.Top + buffer, 0);
                }
                case 1:
                    // right
                {
                    return new Vector3(
                        _levelBoundary.Right + buffer,
                        _levelBoundary.Top - posOnSide * _levelBoundary.Height, 0);
                }
                case 2:
                    // bottom
                {
                    return new Vector3(
                        _levelBoundary.Left + posOnSide * _levelBoundary.Width,
                        _levelBoundary.Bottom - buffer, 0);
                }
                case 3:
                    // left
                {
                    return new Vector3(
                        _levelBoundary.Left - buffer,
                        _levelBoundary.Top - posOnSide * _levelBoundary.Height, 0);
                }
            }

            throw Assert.CreateException();
        }

        [Serializable]
        public class Settings
        {
            public float SpeedMin;
            public float SpeedMax;

            public float AccuracyMin;
            public float AccuracyMax;

            public float NumEnemiesIncreaseRate;
            public float NumEnemiesStartAmount;

            public float MinDelayBetweenSpawns = 0.5f;
        }
    }
}