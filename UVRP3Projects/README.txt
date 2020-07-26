---------------------------
 Repository Contents:
---------------------------

UVRP3Files/ folder - Starting files for each project, as separate .zip files for each chapter
UVRP3Projects/ folder - Completed projects for each chapter, as separate Scenes in a single Unity project

---------------------------
 Installation Notes:
---------------------------
Each chapter in the book has a corresponding folder in the Assets/_UVRP3Assets/ folder. Within that folder may be subfolders for Textures, Materials, Prefabs and other assets, including project Scenes.

As instructed in the book, you may need to convert materials to the current render pipeline, especially ones imported from the Asset Store or other sources. (Select Edit | Render Pipeline | Universal Render Pipeline | Upgrade Project Materials to URP Materials).

---------------------------------------
 Chapter 12 important note:
----------------------------------------
Chapter 12 requires additional assets that must be downloaded separately from the Asset Store, including:

Living Birds: https://assetstore.unity.com/packages/3d/characters/animals/living-birds-15649
DOTween: https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676

After installing these assets, unpack the Chapter12.unitypackage. Also note, per Chapter 12 topic "Living Birds Animator", the imported lb_Bird.cs script may need to be modified slightly to avoid its Null Reference error.
