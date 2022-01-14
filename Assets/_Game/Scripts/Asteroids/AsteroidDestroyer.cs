using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidSet : ScriptableObject
    {
        private Dictionary<int, Asteroid> _asteroids = new Dictionary<int, Asteroid>();

        private void Awake()
        {
            Clear();
        }

        public void Add(int id, Asteroid asteroid)
        {
            _asteroids.Add(id, asteroid);
        }

        public void Remove(int id)
        {
            _asteroids.Remove(id);
        }

        public Asteroid Get(int id)
        {
            return _asteroids[id];
        }

        private void Clear()
        {
            _asteroids = new Dictionary<int, Asteroid>();
        }
    }
    
    public static class AsteroidDestroyer
    {
        private static AsteroidSet _asteroids = new AsteroidSet();

        public static void OnAsteroidHitByLaser(int asteroidId)
        {
            // Get the asteroid
            Asteroid asteroid = _asteroids.Get(asteroidId);

            // Check if big or small
            if (asteroid.GetSize() > 0.5)
            {
                
            }
            DestroyAsteroid(asteroid);
        }

        public static void RegisterAsteroid(Asteroid asteroid)
        {
            _asteroids.Add(asteroid.GetInstanceID(), asteroid);
        }

        private static void DestroyAsteroid(Asteroid asteroid)
        {
            _asteroids.Remove(asteroid.GetInstanceID());
        }
    }
}
