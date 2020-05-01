using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CraftRecipeDatabase : MonoBehaviour
{
    public List<CraftRecipe> recipes = new List<CraftRecipe>();
    private ItemDatabase itemDatabase;

    private void Awake()
    {
        itemDatabase = GetComponent<ItemDatabase>();
        BuildCraftRecipeDatabase();

    }

    public Item CheckRecipe(int[] recipe)
    {
        foreach (CraftRecipe craftRecipe in recipes)
        {
            if (craftRecipe.requiredItems.SequenceEqual(recipe))
            {
                return itemDatabase.GetItem(craftRecipe.itemToCraft);
            }
        }
        return null;
    }

    void BuildCraftRecipeDatabase()
    {
        recipes = new List<CraftRecipe>()
        {
            // To craft a Flint Axe
            new CraftRecipe(1,
            new int[] {
                5, 2, 3,
                0, 2, 0,
                0, 2, 0
            }),

            // To craft a Spear
            new CraftRecipe(2,
            new int[] {
                0, 3, 0,
                0, 2, 0,
                0, 2, 0
            }),

            // To craft planks for Raft.
            new CraftRecipe(6,
            new int[] {
                5, 2, 2,
                0, 2, 2,
                5, 2, 2
            }),

            // To craft planks for Sail.
            new CraftRecipe(7,
            new int[] {
                5, 5, 5,
                5, 2, 5,
                5, 2, 5
            }),

            // To craft a raft.
            new CraftRecipe(8,
            new int[] {
                0, 7, 0,
                0, 6, 0,
                6, 6, 6
            })
        };
    }
}