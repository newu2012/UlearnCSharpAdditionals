using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace UlearnSpaceshipGame;

public static class EntityManager
{
    private static List<Entity> entities = new();
    private static bool isUpdating;
    private static List<Entity> entitiesToAdd = new();

    public static int Count => entities.Count;

    public static void Add(Entity entity)
    {
        if (!isUpdating)
            entities.Add(entity);
        else 
            entitiesToAdd.Add(entity);
    }

    public static void Update()
    {
        isUpdating = true;

        foreach (var entity in entities) 
            entity.Update();

        isUpdating = false;

        foreach (var entity in entitiesToAdd) 
            entities.Add(entity);
        entitiesToAdd.Clear();
        
        entities = entities.Where(entity => !entity.IsExpired).ToList();
    }

    public static void Draw(SpriteBatch spriteBatch)
    {
        foreach (var entity in entities) 
            entity.Draw(spriteBatch);
    }
}